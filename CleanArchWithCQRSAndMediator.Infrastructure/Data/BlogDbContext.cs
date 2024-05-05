using CleanArchWithCQRSAndMediator.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRSAndMediator.Infrastructure.Data
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions) : base(dbContextOptions)
        {       
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
