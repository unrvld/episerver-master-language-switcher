using EPiServer.PlugIn;
using EPiServer.SpecializedProperties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EPiServer;
using EPiServer.Security;
using EPiServer.ServiceLocation;

namespace LanguageMigration.Tools
{
    [GuiPlugIn(DisplayName = "Advanced Language Tool",
        Description = "Advanced Language Tool",
        Area = PlugInArea.AdminMenu,
        Url = "~/Tools/LanguageTool.aspx")]
    public partial class LanguageTool : System.Web.UI.Page
    {
        private readonly string spGetContentHierarchy = "cogGetContentHierarchy";
        private readonly string spGetContentBlocks = "cogGetContentBlocks";
        private readonly string spChangePageBranchMasterLanguage = "cogChangePageBranchMasterLanguage";

        protected override void OnInit(EventArgs e)
        {
            if (!PrincipalInfo.HasAdminAccess)
            {
                Response.Redirect("/", true);
            }

            base.OnInit(e);
            InputLanguage2.PropertyData = new PropertyLanguage();
            InputLanguage2.CreateEditControls();
        }

        protected void btnChangeLanguage_Click(object sender, EventArgs e)
        {
            var contentCacheRemover = ServiceLocator.Current.GetInstance<IContentCacheRemover>();

            InputLanguage2.ApplyEditChanges();

            if (PageSelector.PageLink != null && !string.IsNullOrEmpty((string)InputLanguage2.PropertyData.Value))
            {
                try
                {
                    RunSwitchLanguage(PageSelector.PageLink.ID, (string)InputLanguage2.PropertyData.Value, ckbRecursiveReplace.Checked, rbgLanguageSwitchType.SelectedIndex == 0);

                    RunSwitchBlockLanguage(PageSelector.PageLink.ID, (string)InputLanguage2.PropertyData.Value, ckbRecursiveReplace.Checked, rbgLanguageSwitchType.SelectedIndex == 0);

                    contentCacheRemover.Clear();

                    litMessage.Text = "Page language changed.";
                }
                catch (Exception ex)
                {
                    litMessage.Text = string.Format("Page change unsuccesfull:<br>{0}", ex.Message);
                }
            }

            litMessage.Text = "Page language not changed. No page or language selected.";
        }

        public IEnumerable<int> GetContentHierarchy(int pageId)
        {
            List<int> ids = new List<int>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EPiServerDB"].ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(spGetContentHierarchy, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@page_id", SqlDbType.Int).Value = pageId;

                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ids.Add(int.Parse(reader["pkID"].ToString()));
                    }
                }
                catch (InvalidOperationException ex)
                {
                    //log and/or rethrow or ignore
                }
                catch (SqlException ex)
                {
                    //log and/or rethrow or ignore
                }
                catch (ArgumentException ex)
                {
                    //log and/or rethrow or ignore
                }

                return ids;
            }
        }

        public IEnumerable<int> GetContentBlocks(int pageId)
        {
            List<int> ids = new List<int>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EPiServerDB"].ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(spGetContentBlocks, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@page_id", SqlDbType.Int).Value = pageId;

                    command.Connection.Open();
                    command.ExecuteNonQuery();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ids.Add(int.Parse(reader["pkID"].ToString()));
                    }
                }
                catch (InvalidOperationException ex)
                {
                    //log and/or rethrow or ignore
                }
                catch (SqlException ex)
                {
                    //log and/or rethrow or ignore
                }
                catch (ArgumentException ex)
                {
                    //log and/or rethrow or ignore
                }

                return ids;
            }
        }

        public void RunSwitchBlockLanguage(int contentId, string langBranch, bool recursive, bool switchOnly)
        {
            List<int> ids = new List<int>();

            var pageIds = GetContentHierarchy(contentId);

            foreach (var pageId in pageIds)
            {
                var blockIds = GetContentBlocks(pageId);

                ids.AddRange(blockIds);
            }

            foreach (var id in ids)
            {
                RunSwitchLanguage(id, (string)InputLanguage2.PropertyData.Value, ckbRecursiveReplace.Checked, rbgLanguageSwitchType.SelectedIndex == 0);
            }
        }

        public bool RunSwitchLanguage(int contentId, string langBranch, bool recursive, bool switchOnly)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["EPiServerDB"].ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(spChangePageBranchMasterLanguage, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@page_id", SqlDbType.Int).Value = contentId;
                    command.Parameters.Add("@language_branch", SqlDbType.VarChar, 20).Value = langBranch;
                    command.Parameters.Add("@recursive", SqlDbType.Bit).Value = recursive;
                    command.Parameters.Add("@switch_only", SqlDbType.Bit).Value = switchOnly;

                    command.Connection.Open();
                    command.ExecuteNonQuery();

                    return true;
                }
                catch (InvalidOperationException ex)
                {
                    //log and/or rethrow or ignore
                }
                catch (SqlException ex)
                {
                    //log and/or rethrow or ignore
                }
                catch (ArgumentException ex)
                {
                    //log and/or rethrow or ignore
                }

                return false;
            }
        }
    }
}