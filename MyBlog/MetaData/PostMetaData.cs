using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.MetaData;

namespace MyBlog.Models
{

    [MetadataType(typeof(PostMetaData))]
    public partial class Post
    {
        public class PostMetaData
        {
            //Other vaidation attributes:
            //Range
            //RegularExpression

            [Required(ErrorMessage="You have to enter a Title")]
            //My custom validator
            [ExcludeWords("crap", "dagyo")]
            public string Title { get; set; }

            [Required(ErrorMessage="Please enter a message body")]            
            public string Body { get; set; }

            [HiddenInput(DisplayValue = false)]
            public int PostID { get; internal set; }

            [DisplayName("Category (This name is set in the MetaData not the View!)")]
            public int CategoryID { get ; set; }

            
            [DisplayName("Visible To:")]
            [UIHint("RadioEditorTemplate")]
            public bool IsPublic { get; set; }

            [Required(ErrorMessage = "When should this ad be published?")]
            public DateTime CreatedOn { get; set; }
        }
    }
}