using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyBlog.MetaData;

namespace MyBlog.Utils
{
    public class PostValidationProvider : AssociatedValidatorProvider
    {
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            var excludeWordsAttributes = attributes.OfType<ExcludeWordsAttribute>();
            foreach (var excludedWordsAttribute in excludeWordsAttributes)
                yield return new ExcludedWordsValidator(metadata, context, excludedWordsAttribute.Words);
        }

        private class ExcludedWordsValidator : ModelValidator
        {
            private readonly string[] excludedWords;
            private const string ErrorMessage = "Don't use the word '{0}'";

            public ExcludedWordsValidator(ModelMetadata metadata, ControllerContext controllerContext, string[] wordsToExclude)
                : base(metadata, controllerContext)
            {
                this.excludedWords = wordsToExclude;
            }

            public override IEnumerable<ModelValidationResult> Validate(object container)
            {
                if (Metadata.Model == null)
                    yield break;

                var model = Metadata.Model.ToString();
                foreach (var word in excludedWords)
                    if (model.Contains(word))
                        yield return new ModelValidationResult
                        {
                            Message = string.Format(ErrorMessage, word)
                        };
            }

            /// <summary>
            /// Called when mvc is building the client side validation rules
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
            {
                var rule = new ModelClientValidationRule
                {
                    ErrorMessage = ErrorMessage,
                    //String that must match the Sys.Mvc.ValidatorRegistry.validatores["ExcludedWords"] = function (rule) {
                    // in you .javascript file
                    ValidationType = "ExcludedWords" 
                };

                //Extra params passed down to the client
                rule.ValidationParameters["words"] = excludedWords;
                yield return rule;
            }
        }
    }
}