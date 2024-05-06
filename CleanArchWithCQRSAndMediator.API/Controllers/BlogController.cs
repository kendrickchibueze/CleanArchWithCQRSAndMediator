using CleanArchWithCQRSAndMediator.Application.Blogs.Commands.CreateBlog;
using CleanArchWithCQRSAndMediator.Application.Blogs.Commands.DeleteBlog;
using CleanArchWithCQRSAndMediator.Application.Blogs.Commands.UpdateBlog;
using CleanArchWithCQRSAndMediator.Application.Blogs.Queries.GetBlogById;
using CleanArchWithCQRSAndMediator.Application.Blogs.Queries.GetBlogs;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var blog = await Mediator.Send(new GetBlogByIdQuery() { BlogId = id });
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            var createdBlog =  await Mediator.Send(command);
            // return CreatedAtAction(nameof(GetByIdAsync), new { id = createdBlog.Id }, createdBlog);
            return Ok(createdBlog);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, UpdateBlogCommand command)
        {
            if (id != command.Id) return BadRequest();
             await Mediator.Send(command);
             return NoContent();
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {         
           var result =  await Mediator.Send(new DeleteBlogCommand { Id = id});
            if (result == 0) return BadRequest();
            return NoContent();

        }

    }
}
