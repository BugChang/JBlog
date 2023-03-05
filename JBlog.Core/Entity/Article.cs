namespace JBlog.Core.Entity
{
    public class Article : EntityBase
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public string HtmlContent { get; set; }

        public string MarkdownContent { get; set; }

        public int CategoryId { get; set; }

        public bool IsPublished { get; set; }

        public DateTime PublishTime { get; set; }
    }
}
