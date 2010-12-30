using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class PagedResultsViewModel<T>
    {
        public string Query { get; set; }
        public IEnumerable<T> Data { get; set; }

        public int CurrentPage { get; set; }
        public int TotalResults { get; set; }
        public int PageSize { get; set; }

        public int PageCount
        {
            get { return Math.Max(1, (int)Math.Ceiling((double)TotalResults / PageSize)); }
        }

        public int FirstResultIndex
        {
            get { return TotalResults == 0 ? 0 : 1 + PageSize * (CurrentPage - 1); }
        }

        public int LastResultIndex
        {
            get { return Math.Min(TotalResults, PageSize * CurrentPage); }
        }
    }

    public class PagedResultsWithInterface : IPager
    {
        public string Query { get; set; }
        public IEnumerable Data { get; set; }

        public int CurrentPage { get; set; }
        public int TotalResults { get; set; }
        public int PageSize { get; set; }

        public int PageCount
        {
            get { return Math.Max(1, (int)Math.Ceiling((double)TotalResults / PageSize)); }
        }
      
        public int FirstResultIndex
        {
            get { return TotalResults == 0 ? 0 : 1 + PageSize * (CurrentPage - 1); }
        }

        public int LastResultIndex
        {
            get { return Math.Min(TotalResults, PageSize * CurrentPage); }
        }

        public IEnumerable<T> GetDataForPage<T>(int page)
        {            
            return Data.Cast<T>().Skip<T>((page - 1) * PageSize).Take<T>(PageSize);
        }

        
    }
}