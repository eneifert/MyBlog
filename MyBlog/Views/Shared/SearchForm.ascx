<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="searchForm">
<% using (Html.BeginForm("Index", "Post")) {%>
<h2>
    Search Posts:
    <%=Html.TextBox("query")%>
    <input type="submit" value="Search" />
</h2>
<%}%>

</div>