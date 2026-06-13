namespace Banking_API.Models
{
    public class EventRequest
    {
        public required string Type { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public decimal Amount { get; set; }

        public int? OriginId => int.TryParse(Origin, out var originId) ? originId : null;
        public int? DestinationId => int.TryParse(Destination, out var destinationId) ? destinationId : null;
    }
}
