using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Models
{
    public interface IPager
    {
        IEnumerable Data { get; set; }
        IEnumerable<T> GetDataForPage<T>(int page);
       
        int CurrentPage { get; set; }
        int TotalResults { get; set; }
        int PageSize { get; set; }

        int PageCount { get; }

        int FirstResultIndex { get; }
        int LastResultIndex { get; }
    }
}
