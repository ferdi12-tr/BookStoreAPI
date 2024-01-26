namespace BookStoreWebAPI.DTOs
{
	public class OrderDTO
	{
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int AddressId { get; set; }
    }
}
