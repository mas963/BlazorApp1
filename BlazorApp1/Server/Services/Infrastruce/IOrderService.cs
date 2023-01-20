using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.FilterModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services.Infrastruce
{
    public interface IOrderService
    {
        public Task<OrderDto> CreateOrder(OrderDto order);
        public Task<OrderDto> UpdateOrder(OrderDto order);
        public Task DeleteOrder(Guid orderId);
        public Task<List<OrderDto>> GetOrders(DateTime orderDate);
        public Task<List<OrderDto>> GetOrdersByFilter(OrderListFilterModel filter);
        public Task<OrderDto> GetOrderById(Guid id);

        public Task<OrderItemDto> CreateOrderItem(OrderItemDto orderItem);
        public Task<OrderItemDto> UpdateOrderItem(OrderItemDto orderItem);
        public Task<List<OrderItemDto>> GetOrderItems(Guid orderId);
        public Task<OrderItemDto> GetOrderItemsById(Guid id);
        public Task DeleteOrderItem(Guid orderItemId);
    }
}
