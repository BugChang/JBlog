using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBlog.Core.Entity
{
    public class Article : EntityBase
    {
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public string HtmlContent { get; set; }

        public string MarkdownContent { get; set; }

        public int CategoryId { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? PublishOn { get; set; }

        public bool IsTop { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public List<ArticleTag> ArticleTags { get; set; }
    }
}
