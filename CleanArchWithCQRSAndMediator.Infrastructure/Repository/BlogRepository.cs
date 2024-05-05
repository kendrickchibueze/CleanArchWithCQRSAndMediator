using CleanArchWithCQRSAndMediator.Domain.Entity;
using CleanArchWithCQRSAndMediator.Domain.Repository;
using CleanArchWithCQRSAndMediator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRSAndMediator.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await _blogDbContext.Blogs.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
            return await _blogDbContext.Blogs.Where(model=>model.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _blogDbContext.Blogs.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> UpdateBlogAsync(int id, Blog blog)
        {
            return await _blogDbContext.Blogs
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.Id, blog.Id)
                .SetProperty(m => m.Name, blog.Name)
                .SetProperty(m => m.Description, blog.Description)
                .SetProperty(m => m.Author, blog.Author)
                );
        }
    }
}
