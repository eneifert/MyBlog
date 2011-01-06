<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IPagedList>" %>
<div class="pageLinks">
    Page:
    <% for (var i = 1; i <= Model.PageCount; i++) { %>
        <% if (i - 1 == Model.CurrentPage)
           { %>
            <b><%=i%></b>
            <% } else { %>                                    
                <%=Html.ActionLink(i.ToString(), "Index", new { page = i }) %>
            <% } %>
        <% } %>                      
</div>

