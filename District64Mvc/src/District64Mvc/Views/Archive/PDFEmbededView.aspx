<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PDFEmbededView
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    Return to <a href="<%= Url.Action("Index", "Archive") %>">Archive Search</a>
    <br />

   <object width="100%" type="application/pdf" data="<%= Url.Action("PDFView", "Archive", new { archiveId = ViewData["id"] }) %>" height="750">
        <br />
        <p class="missing">If you seeing this message, you need to upgrade your Flash Player</p>
		<br />
		<p></p><br />You may download the Adobe Flash Player <a href="http://get.adobe.com/reader/">here.</a>
		<br />Alternatively, you can download the Archive Document directly from <a href="<%= Url.Action("PDFView", "Archive", new { archiveId = ViewData["id"] }) %>">this location.</a></p>
        
     </object>



</asp:Content>
