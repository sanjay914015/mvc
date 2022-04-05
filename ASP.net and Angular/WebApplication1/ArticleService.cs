using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class ArticleService : IArticleService
    {
        public readonly ApiContext _context;

        public ArticleService(ApiContext context)
        {
            _context = context;
        }

        public async Task<IResult> GetArticles()
        {
            return Results.Ok(await _context.Articles.ToListAsync());

        }
        public async Task<IResult> GetArticleById(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            return article !=null ? Results.Ok(article) : Results.NotFound();

        }

        public async Task<IResult> CreateArticle(ArticleRequest articleRequest)
        {
            var createdArticle = _context.Articles.Add(new Article
            {
                Title = articleRequest.Title ?? String.Empty,
                Content = articleRequest.Content ?? String.Empty,
                PublishedAt = articleRequest.PublishedAt ?? DateTime.MinValue,
            });

            await _context.SaveChangesAsync();

            return Results.Created($"/articles/" + $"{createdArticle.Entity.Id}", createdArticle.Entity);
        }
        public async Task<IResult> UpdateArticle(int id, ArticleRequest article)
        {
            var articleToUpdate = await _context.Articles.FindAsync(id);

            if(articleToUpdate != null)
            {
                return Results.NotFound();
            }

            if(article.Title != null)
            {
                articleToUpdate.Title = article.Title;
            }
            if(article.Content != null)
            {
                articleToUpdate.Content = article.Content;
            }
            if(article.PublishedAt != null)
            {
                articleToUpdate.PublishedAt = article.PublishedAt;
            }

            await _context.SaveChangesAsync();

            return Results.Ok(articleToUpdate);
        }
        public async Task<IResult> DeleteArticle(int id)
        {
            var articleToDelete = await _context.Articles.FindAsync(id);
            if(articleToDelete == null)
            {
                return Results.NotFound();
            }
            _context.Articles.Remove(articleToDelete);

            await _context.SaveChangesAsync();
            return Results.Ok(articleToDelete);
        }
    }
}
