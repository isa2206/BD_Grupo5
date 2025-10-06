using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    public record CreateGuestDto
    {
        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        public bool Confirmed { get; set; }
    }
}
