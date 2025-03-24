using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UserBlogAPI.DTO;
using UserBlogAPI.Models;

namespace UserBlogAPI.Controllers
{
    [Route("api/v1/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly UserBlogDbContext _context;

        public ArticlesController(UserBlogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _context.Articles.Include(a => a.User).ToListAsync();
            List<ArticleDto> articleDtoList = new List<ArticleDto>();
            foreach (var article in articles)
            {
                ArticleDto articleDto = new ArticleDto();

                articleDto.Title = article.Title;
                articleDto.Content = article.Content;
                articleDtoList.Add(articleDto);
            }
            return Ok(articleDtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _context.Articles.Include(a => a.User).FirstOrDefaultAsync(a => a.Id == id);
            if (article == null) return NotFound();

            List<ArticleDto> articleDtoList = new List<ArticleDto>();
            ArticleDto articleDto = new ArticleDto();

            articleDto.Title = article.Title;
            articleDto.Content = article.Content;
            articleDtoList.Add(articleDto);

            return Ok(articleDtoList);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleDto articleDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            if (string.IsNullOrEmpty(userId) && userRole != "User")
                return Unauthorized();


            //var userId = User.FindFirstValue(ClaimTypes.Name);
            int parseUserId = int.TryParse(userId, out int parsedInt) ? parsedInt : 0;

            if (parseUserId > 0)
            {

                Article article = new Article() { Title = articleDto.Title, Content = articleDto.Content, UserId = Convert.ToInt32(userId) };
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();
                //return CreatedAtAction(nameof(GetAllArticles), new { id = article.Id }, article);
                return Ok("Article created successfully.");
            }
            return Ok("Article not created, please try again.");

        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody] ArticleDto articleDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var userRole = User.FindFirstValue(ClaimTypes.Role);

            if (string.IsNullOrEmpty(userId) && userRole != "User")
                return Ok("You are not authorized to delete this Article.");

            var article = await _context.Articles.FindAsync(id);
            //if (article == null || article.UserId != int.Parse(User.FindFirstValue(ClaimTypes.Name)))
            if (article == null || article.UserId != int.Parse(userId))
                return Unauthorized();

            article.Title = articleDto.Title;
            article.Content = articleDto.Content;
            await _context.SaveChangesAsync();
            //return NoContent();
            return Ok("Article updated successfully.");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            var article = await _context.Articles.FindAsync(id);

            if (string.IsNullOrEmpty(userId) || article == null || article.UserId != int.Parse(userId))
                return Unauthorized();

            if (article == null) 
                return NotFound();


            if (article.UserId != int.Parse(userId) && userRole == "User")
                return Forbid();

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            //return NoContent();
            return Ok("Article deleted successfully.");

        }
    }

}
