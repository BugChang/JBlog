namespace JBlog.Application.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Content { get; set; }
        public string HtmlContent { get; set; }
        public string MarkdownContent { get; set; }
        public bool IsPublished { get; set; }
        public string PublishOn { get; set; }
        public string CreateOn { get; set; }
        public string UpdateOn { get; set; }

    }
}
