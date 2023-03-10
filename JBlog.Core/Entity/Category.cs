using System.ComponentModel.DataAnnotations;

namespace JBlog.Core.Entity
{
    public class Category : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
