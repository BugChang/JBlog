namespace JBlog.Common.Models
{
    public class PageResult<T> where T : class
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public IList<T> Records { get; set; }
    }
}
