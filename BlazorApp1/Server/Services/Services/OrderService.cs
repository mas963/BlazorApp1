﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorApp1.Server.Data.Context;
using BlazorApp1.Server.Data.Models;
using BlazorApp1.Server.Services.Infrastruce;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.FilterModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly MealOrderingDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;

        public OrderService(MealOrderingDbContext context, IMapper mapper, IValidationService validationService)
        {
            _context = context;
            _mapper = mapper;
            _validationService = validationService;
        }

        #region Order Methods

        #region Get
        public async Task<List<OrderDto>> GetOrdersByFilter(OrderListFilterModel filter)
        {
            var query = _context.Orders.Include(i => i.Supplier).AsQueryable();

            if (filter.CreatedUserId != Guid.Empty)
                query = query.Where(i => i.CreatedUserId == filter.CreatedUserId);

            if (filter.CreateDateFirst.HasValue)
                query = query.Where(i => i.CreateDate >= filter.CreateDateFirst);

            if (filter.CreateDateLast > DateTime.MinValue)
                query = query.Where(i => i.CreateDate <= filter.CreateDateLast);

            var list = await query
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .OrderBy(i => i.CreateDate)
                .ToListAsync();

            return list;
        }

        public async Task<List<OrderDto>> GetOrders(DateTime OrderDate)
        {
            var list = await _context.Orders.Include(i => i.Supplier)
                      .Where(i => i.CreateDate.Date == OrderDate.Date)
                      .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                      .OrderBy(i => i.CreateDate)
                      .ToListAsync();

            return list;
        }

        public async Task<OrderDto> GetOrderById(Guid id)
        {
            return await _context.Orders.Where(i => i.Id == id)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Post
        public async Task<OrderDto> CreateOrder(OrderDto order)
        {
            var dbOrder = _mapper.Map<Order>(order);
            await _context.AddAsync(dbOrder);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(dbOrder);
        }

        public async Task<OrderDto> UpdateOrder(OrderDto order)
        {
            var dbOrder = await _context.Orders.FirstOrDefaultAsync(i => i.Id == order.Id);
            if (dbOrder == null)
                throw new Exception("order not found");

            if (!_validationService.HasPermission(dbOrder.CreatedUserId))
                throw new Exception("you cannot change the order unless you created");

            _mapper.Map(order, dbOrder);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(dbOrder);
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var detailCount = await _context.OrderItems.Where(i => i.OrderId == orderId).CountAsync();

            if (detailCount > 0)
                throw new Exception($"There are {detailCount} sub items for the order you are trying to delete");

            var order = await _context.Orders.FirstOrDefaultAsync(i => i.Id == orderId);
            if (order == null)
                throw new Exception("order not found");

            if (!_validationService.HasPermission(order.CreatedUserId))
                throw new Exception("you cannot change the order unless you created");

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
        #endregion

        #endregion

        #region OrderItem Methods
        #region Get
        public async Task<List<OrderItemDto>> GetOrderItems(Guid orderId)
        {
            return await _context.OrderItems.Where(i => i.OrderId == orderId)
                .ProjectTo<OrderItemDto>(_mapper.ConfigurationProvider)
                .OrderBy(i => i.CreateDate)
                .ToListAsync();
        }

        public async Task<OrderItemDto> GetOrderItemsById(Guid id)
        {
            return await _context.OrderItems.Include(i => i.Order).Where(i => i.Id == id)
                .ProjectTo<OrderItemDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Post
        public async Task<OrderItemDto> CreateOrderItem(OrderItemDto orderItem)
        {
            var order = await _context.Orders
                .Where(i => i.Id == orderItem.OrderId)
                .Select(i => i.ExpireDate)
                .FirstOrDefaultAsync();

            if (order == null)
                throw new Exception("the main order not found");

            if (order <= DateTime.Now)
                throw new Exception("you cannot create sub order. it is expired");

            var dbOrder = _mapper.Map<OrderItem>(orderItem);
            await _context.AddAsync(dbOrder);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderItemDto>(dbOrder);
        }

        public async Task<OrderItemDto> UpdateOrderItem(OrderItemDto orderItem)
        {
            var dbOrder = await _context.OrderItems.FirstOrDefaultAsync(i => i.Id == orderItem.Id);
            if (dbOrder == null)
                throw new Exception("order not found");

            _mapper.Map(orderItem, dbOrder);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderItemDto>(dbOrder);
        }

        public async Task DeleteOrderItem(Guid OrderItemId)
        {
            var orderItem = await _context.OrderItems.FirstOrDefaultAsync(i => i.Id == OrderItemId);
            if (orderItem == null)
                throw new Exception("Sub order not found");

            _context.OrderItems.Remove(orderItem);

            await _context.SaveChangesAsync();
        }
        #endregion
        #endregion
    }
}
