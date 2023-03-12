namespace JBlog.Common.Models
{
    public class PageQuery
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public int Skip => (Page - 1) * PageSize;

        public int Take => PageSize;

        public object Extra { get; set; }
    }
}
