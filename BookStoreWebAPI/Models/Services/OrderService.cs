using BookStoreWebAPI.DTOs;
using BookStoreWebAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStoreWebAPI.Models.Services
{
	public class OrderService : IOrderService
	{
		private readonly DataContext dataContext;
		public OrderService()
		{
			dataContext = new DataContext();
		}

		public async Task AddOrderAsync(OrderDTO order)
		{
			try
			{
				var orderItem = new Order
				{
					Date = order.Date,
					AddressId = order.AddressId,
					UserId = order.UserId,
					Quantity = order.Quantity,
					ProductId = order.ProductId,
				};
				dataContext.Order?.Add(orderItem);
				await dataContext.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<IEnumerable<OrderDTO>> GetOrdersByUserIdAsync(int userId)
		{
			try
			{
				var orders = await dataContext.Order
					.Where(x => x.UserId == userId)
					.Select(y => new OrderDTO
					{
						UserId = userId,
						AddressId = y.AddressId,
						Date = y.Date,
						OrderId = y.Id,
						ProductId = y.ProductId,
						Quantity = y.Quantity
					})
					.ToListAsync();
				return orders;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task UpdateOrderAsync(OrderDTO order)
		{
			try
			{
				var updatedOrder = await dataContext.Order.FindAsync(order.OrderId);
				updatedOrder.AddressId = order.AddressId;
				updatedOrder.UserId = order.UserId;
				updatedOrder.Date = order.Date;
				updatedOrder.Quantity = order.Quantity;
				updatedOrder.ProductId = order.ProductId;
				dataContext.Update(updatedOrder);
				await dataContext.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<Address> AddAddressAsync(Address address)
		{
			try
			{
				var result = dataContext.Address?.Add(address);
				await dataContext.SaveChangesAsync();
				return result.Entity;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<Address> GetAddressByUserIdAsync(int userId)
		{
			try
			{
				var address = await dataContext.Address.FirstOrDefaultAsync(x => x.UserId == userId);
				return address;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<Address> UpdateAddressAsync(Address address)
		{
			try
			{
				var result = dataContext.Update(address);
				await dataContext.SaveChangesAsync();
				return result.Entity;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
