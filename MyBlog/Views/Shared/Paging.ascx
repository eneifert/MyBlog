<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div class="pageLinks">
    Page:
    <% for (var i = 1; i <= Model.PageCount; i++) { %>
        <% if (i == Model.PageIndex)
           { %>
            <b><%=i%></b>
            <% } else { %>                                    
                <%=Html.ActionLink(i.ToString(), "Index", new { page = i }) %>
            <% } %>
        <% } %>                
</div>

