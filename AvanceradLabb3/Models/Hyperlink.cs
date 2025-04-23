using System.ComponentModel.DataAnnotations;

namespace AvanceradLabb3.Models
{
    public class Hyperlink
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        // Navigation properties

        
        public Person Person { get; set; }
        
        public Interest Interest { get; set; }

    }
}
