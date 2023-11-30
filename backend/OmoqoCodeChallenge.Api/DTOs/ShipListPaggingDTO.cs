namespace OmoqoCodeChallenge.Api.DTOs
{
    public class ShipListPaggingDTO
    {
        public int? Page { get; set; }

        public int? Limit { get; set; }

        public long Count { get; set; }

        public List<ShipResponseDTO>? Data { get; set; }
    }
}
