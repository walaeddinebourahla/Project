using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class JournalService : IJournalService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public JournalService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<JournalDto>> GetJournals(bool trackChanges)
    {
        var journals = await _repository.Journal.GetJournals(trackChanges);
        var journalsDto = _mapper.Map<IEnumerable<JournalDto>>(journals);
        return journalsDto;
    }

    public async Task<JournalDto> GetJournal(Guid journalId, bool trackChanges)
    {
        var journal = await _repository.Journal.GetJournal(journalId, trackChanges);

        if (journal is null)
            throw new JournalNotFoundException(journalId);

        var journalDto = _mapper.Map<JournalDto>(journal);
        return journalDto;
    }

    public async Task<JournalDto> CreateJournal(JournalForCreationDto journal)
    {
        var journalEntity = _mapper.Map<Journal>(journal);

        _repository.Journal.CreateJournal(journalEntity);
        await _repository.SaveAsync();

        var journalToReturn = _mapper.Map<JournalDto>(journalEntity);
        return journalToReturn;
    }

    public async Task DeleteJournal(Guid journalId, bool trackChanges)
    {
        var journal = await  _repository.Journal.GetJournal(journalId, trackChanges);
        if (journal is null)
            throw new JournalNotFoundException(journalId);

        _repository.Journal.DeleteJournal(journal);
        await _repository.SaveAsync();
    }

    public async Task UpdateJournal(Guid journalId, JournalForUpdateDto journalForUpdate, bool trackChanges)
    {
        var journalEntity = await _repository.Journal.GetJournal(journalId, trackChanges);
        if (journalEntity is null)
            throw new JournalNotFoundException(journalId);

        _mapper.Map(journalForUpdate, journalEntity);
        await _repository.SaveAsync();
    }
}
