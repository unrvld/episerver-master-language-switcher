<%@ Page Language="c#" CodeBehind="LanguageTool.aspx.cs" AutoEventWireup="False" Inherits="LanguageMigration.Tools.LanguageTool" Title="" %>

<%@ Register TagPrefix="EPiServerControls" Assembly="EPiServer.Cms.AspNet" Namespace="EPiServer.Web.WebControls" %>
<%@ Register TagPrefix="EpiserverProperties" Assembly="EPiServer.Cms.AspNet" Namespace="EPiServer.Web.PropertyControls" %>
<%@ Register TagPrefix="EPiServerUI" Assembly="EPiServer.UI" Namespace="EPiServer.UI.WebControls" %>

<form id="form" runat="server">
    <table>
        <tr>
            <td>
                <b>Page to process:</b>
            </td>
            <td id="td_page">
                <EPiServerControls:InputPageReference runat="Server" id="PageSelector" DisableCurrentPageOption="true" />
            </td>
        </tr>
        <tr>
            <td><b>Target Language: <span>Select language</span></b>
            </td>
            <td id="td_lang">
                <EpiserverProperties:PropertyLanguageControl runat="server" ID="InputLanguage2" />
                <asp:placeholder runat="server" id="plhLanguageLontrol"></asp:placeholder>
            </td>
        </tr>
        <tr>
            <td><b>Switch mode: </b><span>Select language</span>
            </td>
            <td id="td2">
                <asp:radiobuttonlist runat="server" id="rbgLanguageSwitchType">
                <asp:ListItem Text="Just switch between existing Language branches making the new one a master language" Selected="True" Value="1"></asp:ListItem>
                <asp:ListItem Text="Convert the current master branch to new Language - the target language may not exist yet." Selected="False" Value="0"></asp:ListItem>
                </asp:radiobuttonlist>
        </tr>
        <tr>
            <td><b>Process children: </b>
            </td>
            <td id="td1">
                <asp:checkbox runat="Server" id="ckbRecursiveReplace" text="Select this option to perform the operation on the page as well as all of its children recursively." />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:button id="btnChangeLanguage" runat="server" text="Change Language" onclick="btnChangeLanguage_Click" />
            </td>
        </tr>
    </table>
</form>