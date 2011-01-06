<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<bool?>" %>
<label><%= Html.RadioButton("", false, !Model) %>Everyone</label>
<br/>
<label><%= Html.RadioButton("", false, Model) %>Members Only</label>

