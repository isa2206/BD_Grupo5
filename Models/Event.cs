using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public int Capacity { get; set; } = 50;
    }
}
