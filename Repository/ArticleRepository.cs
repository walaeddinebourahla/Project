using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    public ArticleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public async Task<IEnumerable<Article>> GetArticles(Guid journalId, bool trackChanges) =>
        await FindByCondition(a => a.JournalId.Equals(journalId), trackChanges).OrderBy(j => j.Name)
        .ToListAsync();

    public async Task<Article> GetArticle(Guid journalId, Guid articleId, bool trackChanges) =>
        await FindByCondition(j => j.JournalId.Equals(journalId) && j.Id.Equals(articleId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateArticle(Guid journalId, Article article)
    {
        article.JournalId = journalId;
        Create(article);
    }

    public void DeleteArticle(Article article) => Delete(article);
}