using Entities.Models;

namespace Contracts;

public interface IJournalRepository
{
    Task<IEnumerable<Journal>> GetJournals(bool trackChanges);
    Task<Journal> GetJournal(Guid journalId, bool trackChanges);
    void CreateJournal(Journal journal);
    void DeleteJournal(Journal journal);
}
