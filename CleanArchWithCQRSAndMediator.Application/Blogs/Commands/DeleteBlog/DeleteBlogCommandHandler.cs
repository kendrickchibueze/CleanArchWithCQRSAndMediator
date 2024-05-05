using CleanArchWithCQRSAndMediator.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRSAndMediator.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public DeleteBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var deleteBlog = await _blogRepository.DeleteBlogAsync(request.Id);
            return deleteBlog;
        }
    }
}
