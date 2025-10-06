using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    public class CreateEventDto
    {
        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Range(1, 1000)]
        public int Capacity { get; set; } = 50;
    }
}
