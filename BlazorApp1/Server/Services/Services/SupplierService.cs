using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorApp1.Server.Data.Context;
using BlazorApp1.Server.Data.Models;
using BlazorApp1.Server.Services.Infrastruce;
using BlazorApp1.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly MealOrderingDbContext _context;
        private readonly IMapper _mapper;

        public SupplierService(MealOrderingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SupplierDto>> GetSuppliers()
        {
            var list = await _context.Suppliers
                .ProjectTo<SupplierDto>(_mapper.ConfigurationProvider)
                .OrderBy(i => i.CreateDate)
                .ToListAsync();

            return list;
        }

        #region Post
        public async Task<SupplierDto> CreateSupplier(SupplierDto order)
        {
            var dbSupplier = _mapper.Map<Supplier>(order);
            await _context.AddAsync(dbSupplier);
            await _context.SaveChangesAsync();

            return _mapper.Map<SupplierDto>(dbSupplier);
        }

        public async Task DeleteSupplier(Guid supplierId)
        {
            var Supplier = await _context.Suppliers.FirstOrDefaultAsync(i => i.Id == supplierId);
            if (Supplier == null)
                throw new Exception("supplier not fount");

            int orderCount = await _context.Suppliers.Include(i => i.Orders).Select(i => i.Orders.Count).FirstOrDefaultAsync();

            if (orderCount > 0)
                throw new Exception($"there are {orderCount} sub order for the order you are trying to delete");

            _context.Suppliers.Remove(Supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<SupplierDto> GetSupplierById(Guid id)
        {
            return await _context.Suppliers.Where(i => i.Id == id)
                .ProjectTo<SupplierDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<SupplierDto> UpdateSupplier(SupplierDto order)
        {
            var dbSupplier = await _context.Suppliers.FirstOrDefaultAsync(i => i.Id == order.Id);
            if (dbSupplier == null)
                throw new Exception("supplier not found");

            _mapper.Map(order, dbSupplier);
            await _context.SaveChangesAsync();

            return _mapper.Map<SupplierDto>(dbSupplier);
        }

        #endregion
    }
}
