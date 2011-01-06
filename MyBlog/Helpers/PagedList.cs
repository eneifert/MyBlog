using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public interface IPagedList
    {
        int TotalCount
        {
            get;
            set;
        }

        int CurrentPage
        {
            get;
            set;
        }

        int PageSize
        {
            get;
            set;
        }

        bool HasPreviousPage
        {
            get;
        }

        bool HasNextPage
        {
            get;
        }

        int FirstResultIndex
        {
            get;
        }

        int LastResultIndex
        {
            get ; 
        }

        int PageCount
        { 
            get;
        }
    }

    public class PagedList<T> : List<T>, IPagedList
    {
        public PagedList(IEnumerable<T> source, int index, int pageSize)
        {
            index--;
            this.TotalCount = source.Count();
            this.PageSize = pageSize;
            this.CurrentPage = index;
            this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
        }          

        public int FirstResultIndex
        {
            get { return CurrentPage == 0 ? 1 : 1 + PageSize * (CurrentPage); }
        }

        public int LastResultIndex
        {
            get { return Math.Min(TotalCount, PageSize * (CurrentPage + 1)); }
        }

        public int PageCount
        {
            get { return Math.Max(1, (int)Math.Ceiling((double)TotalCount / PageSize)); }
        }

        public int TotalCount { get;  set; }

        public int CurrentPage  { get; set; }

        public int PageSize
        { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage * PageSize) <= TotalCount;
            }
        }
    }

    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index)
        {
            return new PagedList<T>(source, index, 10);
        }
    }
}
