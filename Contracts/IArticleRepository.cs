using Entities.Models;

namespace Contracts;

public interface IArticleRepository
{
    Task<IEnumerable<Article>> GetArticles(Guid journalId, bool trackChanges);
    Task<Article> GetArticle(Guid journalId, Guid articleId, bool trackChanges);
    void CreateArticle(Guid journalId, Article article);
    void DeleteArticle(Article article);
}