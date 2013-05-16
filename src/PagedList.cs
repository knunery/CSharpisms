using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpisms
{
    public interface IPagedList
    {
        int PageNumber { get; } // 1 based index
        int PageIndex { get; }  // 0 based index       
        int PageSize { get; }
        int TotalItems { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
    }

    public interface IPagedList<T> : IList<T>, IPagedList{ }

    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be less than 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");

            this.TotalItems = source.Count();
            this.PageSize = pageSize;
            this.PageNumber = pageNumber;
            this.TotalPages = TotalItems > 0
                            ? (int)Math.Ceiling(TotalItems / (double)PageSize)
                            : 0;
            this.AddRange(source.Skip(PageIndex * pageSize).Take(pageSize).ToList());
        }

        public PagedList(List<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be less than 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");

            this.TotalItems = source.Count();
            this.PageSize = pageSize;
            this.PageNumber = pageNumber;
            this.TotalPages = TotalItems > 0
                            ? (int)Math.Ceiling(TotalItems / (double)PageSize)
                            : 0;
            this.AddRange(source.Skip(PageIndex * pageSize).Take(pageSize).ToList());
        }

        public int PageNumber { get; private set; }
        public int PageIndex { get { return PageNumber - 1; } }
        public int PageSize { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage { get { return (PageNumber > 1); } }
        public bool HasNextPage { get { return (PageNumber * PageSize) < TotalItems; } }
        public bool IsFirstPage { get { return PageNumber == 1; } }
        public bool IsLastPage { get { return PageNumber >= TotalPages; } }
    }

    public static class PagedListExtensions
    {
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageNumber, int pageSize = 10)
        {

            return new PagedList<T>(source, pageNumber, pageSize);
        }
    }
}
