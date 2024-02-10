namespace Entities.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public int  ZipCode { get; set; }
        public string? Street { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
