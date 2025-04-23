namespace AvanceradLabb3.Models
{
    public class LinkCollection
    {

        public int Id { get; set; }

        public ICollection<Hyperlink>? Links { get; set; }
    }
}
