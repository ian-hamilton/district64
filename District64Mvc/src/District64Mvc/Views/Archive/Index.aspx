<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<District64.District64Mvc.Models.Archive.Domain.ArchiveSearch>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        District 64 Digital Archives</h2>
    <div style="display:inline; float:left; width:40%; clear:none; padding-left:30px;">
        <% using (Html.BeginForm("Search", "Archive"))
           {%>
        <table class="display" width="300">
            <tr>
                <th colspan="2">
                    Archive Search
                </th>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Description")%>
                </td>
                <td>
                    <%= Html.TextBoxFor(model=>model.Description)%>
                    <%= Html.ValidationMessageFor(model => model.Description)%>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("From Year") %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model=> model.FromYear) %>
                    <%= Html.ValidationMessageFor(model => model.FromYear) %>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("To Year") %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model=> model.ToYear) %>
                    <%= Html.ValidationMessageFor(model => model.ToYear)%>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("District") %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model=> model.District) %>
                    <%= Html.ValidationMessageFor(model => model.District)%>
                </td>
            </tr>
            <tr>
                <td>
                    <%= Html.Label("Archive Type") %>
                </td>
                <td>
                    <%= Html.DropDownListFor(model=> model.ArchiveType, ViewData["typelist"] as SelectList) %>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <input type="submit" value="Search" class="formbutton" />
                    </div>
                </td>
            </tr>
        </table>
        <% } %>
    </div>
    <div style="display:inline; float:left; width:50%; clear:none;">
        <div class="article">
            <h3>Welcome to the new District 64 Archives View Center!</h3>
        </div>
        <div class="article-zebra">
            Please feel free to search the archives with the provided filter box, or browze all current digital archives.
            <br />
            <br />
            Note: Electronic documents are pdf encoded, and will require a reader plugin such as Adobe Reader to view online or you may download them to your pc. 
            <br />
            <br /> 
            Thank you, and enjoy
            <br /> - Web Master
        </div>
    </div>
    <div class="cleaner"></div>
    <div>
        <br />
        <br />
        <% if (ViewData["SearchParams"] != null) Html.RenderPartial("ArchiveTablePartial", ViewData["SearchParams"]); %>
    </div>
</asp:Content>
