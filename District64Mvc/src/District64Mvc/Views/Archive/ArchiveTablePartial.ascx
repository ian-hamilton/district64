<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<District64.District64Mvc.Models.Archive.Domain.ArchiveSearch>" %>
<%@ Import Namespace="MVC.Controls" %>
<%@ Import Namespace="MVC.Controls.Grid" %>


<div class="article-zebra">Click on a particular line item to view, or click on the Header to sort.</div>

<% using (Html.BeginForm("PDFEmbededView", "Archive"))
   {%>
<%= Html.Grid(new GridControl()
        .SetName("grid")
        .SetPageSize(15)
        .SetIsAutoSize(true)
        .SetListUrl( Url.Action("List", "Archive") + Html.BuildQuery(ViewData["SearchParams"], "search"))
        .SetHeight("300")
        .SetOnSelectedRowEvent("doViewServer")
        .SetColumns<District64.District64Mvc.Models.Archive.Domain.ArchiveItem>(cs=>
            {
                cs.Add(x => x.ArchiveReposIdField).SetAsPrimaryKey().SetHidden(true);
                cs.Add(x => x.ArchiveReposLongDescField).SetCaption("Long Desc");
                cs.Add(x => x.ArchiveReposShortDescField).SetCaption("Short Desc");
                cs.Add(x => x.ArchiveTypeName).SetCaption("Archive Type");
                cs.Add(x => x.DistrictNumberField).SetCaption("District");
                cs.Add(x => x.YearField).SetCaption("Year");
            }))
%>

<% } %>

<script language="javascript" type="text/javascript">
    function doViewServer(e) {
       /*  alert("id =" + e.ArchiveReposIdField); */
        document.forms["form1"].action = document.forms["form1"].action + "?archiveId=" + e.ArchiveReposIdField;
        document.forms["form1"].submit();
        
    }
</script>
