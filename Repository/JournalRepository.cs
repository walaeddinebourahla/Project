using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class JournalRepository : RepositoryBase<Journal>, IJournalRepository
{
    public JournalRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Journal>> GetJournals(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(j => j.Name)
        .ToListAsync();

    public async Task<Journal> GetJournal(Guid journalId, bool trackChanges) =>
        await FindByCondition(j => j.Id.Equals(journalId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateJournal(Journal journal) => Create(journal);
    public void DeleteJournal(Journal journal) => Delete(journal);
}
