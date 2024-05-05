using AutoMapper;
using CleanArchWithCQRSAndMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchWithCQRSAndMediator.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRSAndMediator.Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(request.BlogId);
            var result = _mapper.Map<BlogVm>(blog);
            return result;
        }
    }
}
