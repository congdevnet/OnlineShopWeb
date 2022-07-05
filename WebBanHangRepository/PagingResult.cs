using System.Collections.Generic;

namespace EPS.Utils.Repository
{
    public class PagingResult<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<T> Items { get; set; }

        public PagingResult()
        {
            Items = new List<T>();
        }
    }
}