using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    public record CreateTicketDto
    {
        [Required]
        public string[]? Notes { get; set; }
    }
}
