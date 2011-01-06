using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.MetaData
{
    public class ExcludeWordsAttribute : Attribute
    {
        public string[] Words { get; set; }

        public ExcludeWordsAttribute(params string[] words)
        {
            Words = words;
        }
    }
}