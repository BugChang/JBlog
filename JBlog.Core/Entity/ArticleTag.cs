using System.ComponentModel.DataAnnotations.Schema;

namespace JBlog.Core.Entity
{
    public class ArticleTag : EntityBase
    {
        public int ArticleId { get; set; }

        public int TagId { get; set; }

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
