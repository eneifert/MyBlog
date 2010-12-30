<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyBlog.Models.Post>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>        
        
        <div class="display-label">Title</div>
        <div class="display-field"><%: Model.Title %></div>
        
        <div class="display-label">Body</div>
        <div class="display-field"><%: Model.Body %></div>
        
        <div class="display-label">CreatedOn</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.CreatedOn) %></div>
        
        <div class="display-label">PublishedOn</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.PublishedOn) %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.PostID }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

