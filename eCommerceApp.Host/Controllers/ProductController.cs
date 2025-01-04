﻿using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApp.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await productService.GetAllAsync();
            return data.Any() ? Ok(data) : NotFound(data);
        }

        [HttpGet("single/{id}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var data = await productService.GetByIdAsync(id);
            return data != null ? Ok(data) : NotFound(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProduct createProduct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await productService.AddAsync(createProduct);
            return result.Success ? StatusCode(201, result) : BadRequest(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateProduct updateProduct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await productService.UpdateAsync(updateProduct);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await productService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
