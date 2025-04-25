using System.ComponentModel.DataAnnotations;

namespace AvanceradLabb3.Models.DTO
{
    public record GetPersonRes
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public string? Email { get; init; }
        public int? Age { get; init; }

        public ICollection<InterestDTO>? Interests { get; init; } 
        public ICollection<LinkDTO>? Links { get; init; } 
    }
}
