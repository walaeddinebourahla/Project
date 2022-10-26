using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IJournalService
{
    Task<IEnumerable<JournalDto>> GetJournals(bool trackChanges);
    Task<JournalDto> GetJournal(Guid journalId, bool trackChanges);
    Task<JournalDto> CreateJournal(JournalForCreationDto journal);
    Task DeleteJournal(Guid journalId, bool trackChanges);
    Task UpdateJournal(Guid journalId, JournalForUpdateDto journalForUpdate, bool trackChanges);
}
