using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

public static class HtmlHelpers
{
    public static MvcHtmlString MyCustomTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> helper, System.Linq.Expressions.Expression<Func<TModel,TProperty>> expression)
    {
        return helper.TextAreaFor(expression, new { style = "width:80%; height:100px" });
    }
}