using BlazorApp1.Server.Services.Infrastruce;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("SupplierById/{id}")]
        public async Task<ServiceResponse<SupplierDto>> GetSupplierById(Guid id)
        {
            return new ServiceResponse<SupplierDto>()
            {
                Value = await _supplierService.GetSupplierById(id),
            };
        }

        [HttpGet("Suppliers")]
        public async Task<ServiceResponse<List<SupplierDto>>> GetSuppliers()
        {
            return new ServiceResponse<List<SupplierDto>>()
            {
                Value = await _supplierService.GetSuppliers(),
            };
        }

        [HttpPost("CreateSupplier")]
        public async Task<ServiceResponse<SupplierDto>> CreateSupplier(SupplierDto supplier)
        {
            return new ServiceResponse<SupplierDto>()
            {
                Value = await _supplierService.CreateSupplier(supplier),
            };
        }

        [HttpPost]
        public async Task<ServiceResponse<SupplierDto>> UpdateSupplier(SupplierDto supplier)
        {
            return new ServiceResponse<SupplierDto>()
            {
                Value = await _supplierService.UpdateSupplier(supplier),
            };
        }

        [HttpPost("DeleteSupplier")]
        public async Task<BaseResponse> DeleteSupplier([FromBody] Guid supplierId)
        {
            await _supplierService.DeleteSupplier(supplierId);
            return new BaseResponse();
        }

    }
}
