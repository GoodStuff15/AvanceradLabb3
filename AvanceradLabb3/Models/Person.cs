using System.ComponentModel.DataAnnotations;

namespace AvanceradLabb3.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        public string? Email { get; set; }
        public int? Age { get; set; }

        // Navigation properties
        public ICollection<Interest>? Interests { get; set; }
    }
}
