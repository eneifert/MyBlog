<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MyBlog.Models.Post>" %>
          
     <%= Html.HiddenFor(model => model.PostID) %>
    <div class="editor-label">
    <%: Html.LabelFor(model => model.Title) %>
    </div>
    <div class="editor-field">
    <%: Html.TextBoxFor(model => model.Title) %>
    <%: Html.ValidationMessageFor(model => model.Title) %>
    </div>
            
    <div class="editor-label">
    <%: Html.LabelFor(model => model.Body) %>
    </div>
    <div class="editor-field">
    <%: Html.MyCustomTextAreaFor(model => model.Body) %>
    <%: Html.ValidationMessageFor(model => model.Body) %>
    </div>
    <div class="editor-label">
    <%: Html.LabelFor(model => model.CreatedOn) %>
    </div>
    <div class="editor-field">
    <%: Html.EditorFor(model => model.CreatedOn) %>
    <%: Html.ValidationMessageFor(model => model.CreatedOn) %>
    </div>
    <div class="editor-label">
    <%: Html.LabelFor(model => model.CategoryID) %>
    </div>
    <div class="editor-field">
    <%: Html.DropDownListFor(model => Model.CategoryID, (SelectList)ViewData["Categories"]) %>
    <%: Html.ValidationMessageFor(model => model.CategoryID) %>
    </div>
     <div class="editor-label">
    <%: Html.LabelFor(model => model.IsPublic) %>
    </div>
    <div class="editor-field">
    <%--This uses the MetaData to tell it to render using RadioEditorTemplate. But you could also just pass that in to EditorFor. So MetaData might not be worth the complexity--%>
    <%: Html.EditorFor(model => model.IsPublic) %>
    <%: Html.ValidationMessageFor(model => model.IsPublic) %>
    </div>
    
          

