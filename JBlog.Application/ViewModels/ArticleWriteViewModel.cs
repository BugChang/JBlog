namespace JBlog.Application.ViewModels
{
    public class ArticleWriteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
        public string HtmlContent { get; set; }
        public string MarkdownContent { get; set; }
        public bool IsPublish { get; set; }

    }
}
