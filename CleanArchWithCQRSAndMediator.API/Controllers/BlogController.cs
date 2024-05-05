using CleanArchWithCQRSAndMediator.Application.Blogs.Queries.GetBlogs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRSAndMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : APIControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogs = await Mediator.Send(new GetBlogQuery());
            return Ok(blogs);
        }
    }
}
