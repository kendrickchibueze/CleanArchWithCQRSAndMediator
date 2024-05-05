﻿using CleanArchWithCQRSAndMediator.Domain.Entity;

namespace CleanArchWithCQRSAndMediator.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetBlogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<int> UpdateBlogAsync(int id, Blog blog);

        Task<int> DeleteBlogAsync(int id);
    }
}
