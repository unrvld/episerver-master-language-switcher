<%@ Page Language="c#" CodeBehind="LanguageTool.aspx.cs" AutoEventWireup="False" Inherits="LanguageMigration.Tools.LanguageTool" Title="" %>

<%@ Register TagPrefix="EPiServerControls" Assembly="EPiServer.Cms.AspNet" Namespace="EPiServer.Web.WebControls" %>
<%@ Register TagPrefix="EpiserverProperties" Assembly="EPiServer.Cms.AspNet" Namespace="EPiServer.Web.PropertyControls" %>
<%@ Register TagPrefix="EPiServerUI" Assembly="EPiServer.UI" Namespace="EPiServer.UI.WebControls" %>

<div class="epi-contentContainer epi-padding">
    <div class="epi-contentArea epi-paddingHorizontal">
        <h1 class="EP-prefix">Master Langugage Switcher</h1>
        <div class="epi-paddingVertical">

            <form id="form" runat="server" class="epi-formArea">
                <fieldset>
                    <legend>Styling form</legend>
                    <div class="epi-size10">
                        Page to process:
                        <EPiServerControls:InputPageReference runat="Server" id="PageSelector" DisableCurrentPageOption="true" CssClass="epi-size3" />
                    </div>
                    <div class="epi-size10">
                        Target Language:
                        <EpiserverProperties:PropertyLanguageControl runat="server" ID="InputLanguage2" CssClass="epi-size15" />
                        <asp:placeholder runat="server" id="plhLanguageLontrol"></asp:placeholder>
                    </div>
                    <div class="epi-size10">
                        Switch mode:
                        <asp:radiobuttonlist runat="server" id="rbgLanguageSwitchType" CssClass="epi-size15">
                            <asp:ListItem Text="Just switch between existing Language branches making the new one a master language" Selected="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Convert the current master branch to new Language - the target language may not exist yet." Selected="False" Value="0"></asp:ListItem>
                        </asp:radiobuttonlist>
                    </div>
                    <div class="epi-size10">
                        Process children:
                        <asp:checkbox runat="Server" id="ckbRecursiveReplace" text="Select this option to perform the operation on the page as well as all of its children recursively." css="epi-size15" />
                    </div>
                </fieldset>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:button id="btnChangeLanguage" runat="server" text="Change Language" onclick="btnChangeLanguage_Click" CssClass="epi-cmsButton-text epi-cmsButton-tools" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
        <p></p>
    </div>
</div>