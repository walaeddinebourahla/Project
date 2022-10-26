using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace API.Presentation.Controllers;

[Route("api/journals")]
[ApiController]
public class JournalsController : ControllerBase
{
    private readonly IServiceManager _service;

    public JournalsController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetJournals()
    {
        var journals = await _service.JournalService.GetJournals(trackChanges: false);
        return Ok(journals);
    }

    [HttpGet("{journalId:guid}", Name = "GetJournalById")]
    public async Task<IActionResult> GetJournal(Guid journalId)
    {
        var journal = await _service.JournalService.GetJournal(journalId, trackChanges: false);
        return Ok(journal);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJournal([FromBody] JournalForCreationDto journal)
    {
        if (journal is null)
            return BadRequest("JournalForCreationDto is null.");

        var createdJournal = await _service.JournalService.CreateJournal(journal);

        return CreatedAtRoute("GetJournalById", new { journalId = createdJournal.Id }, createdJournal);
    }

    [HttpDelete("{journalId:guid}")]
    public async Task<IActionResult> DeleteJournal(Guid journalId)
    {
        await _service.JournalService.DeleteJournal(journalId, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{journalId:guid}")]
    public async Task<IActionResult> UpdateJournal(Guid journalId, [FromBody] JournalForUpdateDto journalForUpdate)
    {
        if (journalForUpdate is null)
            return BadRequest("JournalForUpdateDto is null.");

        await _service.JournalService.UpdateJournal(journalId, journalForUpdate, trackChanges: true);
        
        return NoContent();
    }
}
