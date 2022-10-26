using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IJournalRepository> _journalRepository;
    private readonly Lazy<IArticleRepository> _articleRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _journalRepository = new Lazy<IJournalRepository>(() => 
            new JournalRepository(_repositoryContext));
        _articleRepository = new Lazy<IArticleRepository>(() => 
            new ArticleRepository(_repositoryContext));
    }
    public IJournalRepository Journal => _journalRepository.Value;
    public IArticleRepository Article => _articleRepository.Value;
    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
