using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IJournalService> _journalService;
    private readonly Lazy<IArticleService> _articleService;
    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _journalService = new Lazy<IJournalService>(() => new JournalService(repositoryManager, logger, mapper));
        _articleService = new Lazy<IArticleService>(() => new ArticleService(repositoryManager, logger, mapper));
    }
    public IJournalService JournalService => _journalService.Value;
    public IArticleService ArticleService => _articleService.Value;
}