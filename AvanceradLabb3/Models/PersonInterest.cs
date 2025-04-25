using Microsoft.EntityFrameworkCore;

namespace AvanceradLabb3.Models
{
    [PrimaryKey(nameof(PersonId), nameof(InterestId))]
    public class PersonInterest
    {
        public int PersonId { get; set; }
        public int InterestId { get; set; }

        public ICollection<Hyperlink>? Links { get; set; }
    }
}
