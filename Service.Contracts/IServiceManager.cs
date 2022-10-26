namespace Service.Contracts;

public interface IServiceManager
{
    IJournalService JournalService { get; }
    IArticleService ArticleService { get; }
}