namespace AvanceradLabb3.Models.DTO
{
    public record AddInterestReq
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }
    }
}
