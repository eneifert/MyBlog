<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PagedList<MyBlog.Models.Post>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% Html.RenderPartial("SearchForm"); %>

        <div class="results">
        Results: <b><%=Model.FirstResultIndex %> - <%=Model.LastResultIndex %></b> Of: <b><%=Model.TotalCount %></b>       
        </div>

    <% if (TempData["message"] != null) { %>
       <div class="message"><%=TempData["message"] %></div>

    <% }%>
    <table>
        <tr>
            <th></th>
            <th>
                PostID
            </th>
            <th>
                Title
            </th>
            <th>
                Body
            </th>
            <th>
                Category
            </th>
            <th>
                CreatedOn
            </th>
            <th>
                PublishedOn
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { id=item.PostID }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.PostID })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.PostID })%>
            </td>
            <td>
                <%: item.PostID %>
            </td>
            <td>
                <%: item.Title %>
            </td>
            <td>
                <%: item.Body %>
            </td>
            <td>
                <%: item.Category.CategoryName %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.CreatedOn) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.PublishedOn) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

    <% Html.RenderPartial("Paging"); %>    
</asp:Content>

