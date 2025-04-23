namespace AvanceradLabb3.Models
{
    public class PersonInterest
    {
        public int Id { get; set; }

        public ICollection<Hyperlink> Links { get; set; }
    }
}
