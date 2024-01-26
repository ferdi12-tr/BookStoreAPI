using BookStoreWebAPI.DTOs;

namespace BookStoreWebAPI.Models.Interfaces
{
	public interface IOrderService
	{
		public Task AddOrderAsync(OrderDTO order);
		public Task UpdateOrderAsync(OrderDTO order);
		public Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(int userId);
		public Task<Address> AddAddressAsync(Address address);
		public Task<Address> GetAddressByUserIdAsync(int userId);
		public Task<Address> UpdateAddressAsync(Address address);

	}
}
