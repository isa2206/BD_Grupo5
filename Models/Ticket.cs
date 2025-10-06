namespace apiwithdb.Models
{
    public record Ticket(
        Guid Id,
        string[]? Notes
    );
}
