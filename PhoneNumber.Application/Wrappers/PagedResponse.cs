using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumber.Application.Wrappers
{
    public class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int CurrentPageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * CurrentPageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * CurrentPageSize, TotalRows); }
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
