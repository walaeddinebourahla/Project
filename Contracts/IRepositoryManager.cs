namespace Contracts;

public interface IRepositoryManager
{
    IJournalRepository Journal { get; }
    IArticleRepository Article { get; }
    Task SaveAsync();
}
