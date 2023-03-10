namespace JBlog.Core.Entity
{
    public class Comment : EntityBase
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public string Avatar { get; set; }

        public int ArticleId { get; set; }

        public int ReplyId { get; set; }

        public Article Article { get; set; }

    }
}
