using CleanArchWithCQRSAndMediator.Domain.Entity;
using CleanArchWithCQRSAndMediator.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRSAndMediator.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateBlog = new Blog()
            {
                Id = request.Id,
                Author = request.Author,
                Description = request.Description,
                Name = request.Name
            };
            var result = await  _blogRepository.UpdateBlogAsync(request.Id, updateBlog);
            return result;
        }
    }
}
