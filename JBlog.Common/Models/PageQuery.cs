namespace JBlog.Common.Models
{
    public class PageQuery
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int Skip => (Page - 1) * PageSize;

        public int Take => PageSize;

        public object Extra { get; set; }
    }
}
