namespace JBlog.Core.Entity
{
    public class EntityBase
    {
        public int Id { get; set; }

        public DateTime CreateOn { get; set; }

        public DateTime? UpdateOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
