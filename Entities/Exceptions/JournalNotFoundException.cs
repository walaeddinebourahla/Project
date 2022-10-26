namespace Entities.Exceptions;

public sealed class JournalNotFoundException : NotFoundException
{
    public JournalNotFoundException(Guid journalId)
        : base($"The journal with id: {journalId} does not exist in the database")
    { }
}
