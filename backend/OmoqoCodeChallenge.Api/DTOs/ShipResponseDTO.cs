namespace OmoqoCodeChallenge.Api.DTOs
{
    public class ShipResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public string Code { get; set; } = string.Empty;
    }
}
