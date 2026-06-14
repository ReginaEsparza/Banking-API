namespace Banking_API.Models
{
    public class Transfer
    {
        public required Account Origin { get; set; }
        public required Account Destination { get; set; }
    }
}
