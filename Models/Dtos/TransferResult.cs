namespace Banking_API.Models.Dtos
{
    public class TransferResult
    {
        public required Account Origin { get; set; }
        public required Account Destination { get; set; }
    }
}
