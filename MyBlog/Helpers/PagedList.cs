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

        int PageIndex
        {
            get;
            set;
        }

        int PageSize
        {
            get;
            set;
        }

        bool IsPreviousPage
        {
            get;
        }

        bool IsNextPage
        {
            get;
        }
    }

    public class PagedList<T> : List<T>, IPagedList
    {
        public PagedList(IQueryable<T> source, int index, int pageSize)
        {
            this.TotalCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
        }

        public PagedList(List<T> source, int index, int pageSize)
        {
            this.TotalCount = source.Count();
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source.Skip(index * pageSize).Take(pageSize).ToList());
        }

        public int FirstResultIndex
        {
            get { return TotalCount == 0 ? 0 : 1 + PageSize * (PageIndex - 1); }
        }

        public int LastResultIndex
        {
            get { return Math.Min(TotalCount, PageSize * PageIndex); }
        }

        public int PageCount
        {
            get { return Math.Max(1, (int)Math.Ceiling((double)TotalCount / PageSize)); }
        }

        public int TotalCount { get;  set; }

        public int PageIndex  { get; set; }

        public int PageSize
        { get; set; }

        public bool IsPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool IsNextPage
        {
            get
            {
                return (PageIndex * PageSize) <= TotalCount;
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
