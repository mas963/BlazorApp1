using BlazorApp1.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services.Infrastruce
{
    public interface ISupplierService
    {
        public Task<List<SupplierDto>> GetSuppliers();
        public Task<SupplierDto> CreateSupplier(SupplierDto order);
        public Task<SupplierDto> UpdateSupplier(SupplierDto order);
        public Task DeleteSupplier(Guid supplierId);
        public Task<SupplierDto> GetSupplierById(Guid id);
    }
}
