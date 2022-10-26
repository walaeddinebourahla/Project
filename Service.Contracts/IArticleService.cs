using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IArticleService
{
    Task<IEnumerable<ArticleDto>> GetArticles(Guid journalId, bool trackChanges);
    Task<ArticleDto> GetArticle(Guid journalId, Guid articleId, bool trackChanges);
    Task<ArticleDto> CreateArticle(Guid journalId, ArticleForCreationDto articleForCreation, bool trackChanges);
    Task DeleteArticle(Guid journalId, Guid articleId, bool trackChanges);
    Task UpdateArticle(Guid journalId, Guid articleId,ArticleForUpdateDto articleForUpdate, bool journalTrackChanges, bool articleTrackChanges);
}
