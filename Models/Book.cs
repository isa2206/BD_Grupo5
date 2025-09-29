using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
