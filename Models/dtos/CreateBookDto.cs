using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    public record CreateBookDto
    {
        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Range(1000, 2100)]
        public int Year { get; set; }
    }
}
