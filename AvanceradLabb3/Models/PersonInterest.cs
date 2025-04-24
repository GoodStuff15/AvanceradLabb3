namespace AvanceradLabb3.Models
{
    public class PersonInterest
    {
        public int PersonId { get; set; }
        public int InterestId { get; set; }

        public Person Person { get; set; }
        public Interest Interest { get; set; }

        public ICollection<Hyperlink> Links { get; set; }
    }
}
