using AutoMapper;
using CleanArchWithCQRSAndMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchWithCQRSAndMediator.Domain.Entity;
using CleanArchWithCQRSAndMediator.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRSAndMediator.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog() { Name = request.Name, Description=request.Description, Author=request.Author };
            var newBlog = await _blogRepository.CreateBlogAsync(blog);
            var result = _mapper.Map<BlogVm>(newBlog);
            return result;
        }
    }
}
