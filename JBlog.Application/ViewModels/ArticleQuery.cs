using JBlog.Common.Models;

namespace JBlog.Application.ViewModels
{
    public class ArticleQuery : PageQuery
    {
        /// <summary>
        /// 仅发布状态
        /// </summary>
        public bool OnlyPublished { get; set; } = true;

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 分类标识
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public List<int> TagIds { get; set; } = new List<int>();

        /// <summary>
        /// 忽略置顶
        /// </summary>
        public bool IgnoreTop { get; set; }

    }
}
