namespace Banking_API.Models.Dtos
{
    public class EventRequest
    {
        public required string Type { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public decimal Amount { get; set; }
    }
}
