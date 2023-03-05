using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBlog.Core.Interfaces;

namespace JBlog.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly JBlogDbContext _dbContext;

        public UnitOfWork(JBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CommitAsync()
        {
            return  await _dbContext.SaveChangesAsync();
        }
    }
}
