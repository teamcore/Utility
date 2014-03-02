using System.Collections.Generic;
using Ns.Utility.Framework.Mvc;

namespace Ns.Utility.Web.Framework.Mvc
{
    public class PagedListModel<T> where T : BaseEntityModel
    {
        
        public PagedListModel()
        {
            Value = new List<T>();
            TotalCount = Value.Count;
            TotalPages = TotalCount / 10;

            if (TotalCount % 10 > 0)
                TotalPages++;

            PageSize = 10;
            PageIndex = 0;
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="total">The total.</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        public PagedListModel(IEnumerable<T> source, int total, int pageIndex, int pageSize)
        {
            Value = new List<T>();
            TotalCount = total;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
                TotalPages++;

            PageSize = pageSize;
            PageIndex = pageIndex;
            Value.AddRange(source);
        }

        public List<T> Value { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }
        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }
    }
}
