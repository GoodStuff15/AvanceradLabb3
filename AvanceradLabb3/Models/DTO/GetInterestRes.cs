using System.ComponentModel.DataAnnotations;

namespace AvanceradLabb3.Models.DTO
{
    public record GetInterestRes
    {
        public string Title { get; init; }

        public string Description { get; init; }
    }
}
