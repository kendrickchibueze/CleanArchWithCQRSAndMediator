using CleanArchWithCQRSAndMediator.Application.Blogs.Queries.GetBlogs;
using MediatR;

namespace CleanArchWithCQRSAndMediator.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<BlogVm>
    {
        public int BlogId { get; set; }
    }
}
