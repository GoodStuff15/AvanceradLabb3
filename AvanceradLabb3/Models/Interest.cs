using System.ComponentModel.DataAnnotations;

namespace AvanceradLabb3.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title {  get; set; }
        [Required]
        public string Description { get; set; }

        // Navigation properties
        public ICollection<Person>? People { get; set; }

        public ICollection<Hyperlink>? Links { get; set; }
    }
}
