using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateTimeParser;

namespace MyBlog.Utils
{
    public class NaturalDatesModelBinder: DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor)
        {
            // Ensure there's some incoming data
            string key = propertyDescriptor.DisplayName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(key);

            if (propertyDescriptor.PropertyType == typeof(DateTime?) && valueProviderResult != null)
            {
                // Now parse
                var rawText = ((string[])valueProviderResult.RawValue)[0];
                if (CanParseText(rawText))
                    propertyDescriptor.SetValue(bindingContext.Model,
                                                DateTimeEnglishParser.ParseRelative(DateTime.Now, rawText));
                else if (rawText != string.Empty) // There was a parsing error
                    bindingContext.ModelState.AddModelError(key, "A valid DateTime is required");
                return;    
            }

            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }

        private bool CanParseText(string rawText)
        {
            // Not very pretty, but DateTimeEnglishParser provides no other way
            // to determine whether parsing was successful
            var sample = new DateTime(2001, 01, 01);
            return sample != DateTimeEnglishParser.ParseRelative(sample, rawText);
        }
        }
    
}
