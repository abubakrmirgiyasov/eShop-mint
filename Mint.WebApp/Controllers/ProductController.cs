﻿using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = $"{Constants.SELLER},{Constants.ADMIN}")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _product;

    public ProductController(IProductRepository product)
    {
        _product = product;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var products = await _product.GetProductsAsync();
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSellerProductsById(Guid id)
    {
        try
        {
            var products = await _product.GetSellerProductsByIdAsync(id);
            return Ok(products);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("{name}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSellerProductsByName(string name)
    {
        try
        {
            var products = await _product.GetSellerProductsByNameAsync(name);
            return Ok(products);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        try
        {
            var product = await _product.GetProductByIdAsync(id);
            return Ok(product);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetProductsByCategory(string name)
    {
        try
        {
            var products = await _product.GetProductsByCategoryAsync(name);
            return Ok(products);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductInfoBindingModel model)
    {
        try
        {
            await _product.CreateProductAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductInfo([FromBody] ProductInfoBindingModel model)
    {
        try
        {
            await _product.UpdateProductInfo(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductCharacteristic([FromBody] CommonCharacteristicFullBindingModel model)
    {
        try
        {
            await _product.UpdateProductCharacteristicAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductPrice([FromBody] ProductPriceBindingModel model)
    {
        try
        {
            await _product.UpdateProductPriceAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductPictures([FromForm] ProductPicturesBindingModel model)
    {
        try
        {
            model.Files = Request.Form.Files;

            await _product.UpdateProductPicturesAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> CategoryMappings([FromBody] ProductCategoryMappingsBindingModel model)
    {
        try
        {
            await _product.CategoryMappingsAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> ManufactureMappings([FromBody] ProductManufactureMappingsBindingModel model)
    {
        try
        {
            await _product.ManufactureMappingsAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Promotions([FromBody] ProductPromotionsBindingModel model)
    {
        try
        {
            await _product.PromotionsAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        try
        {
            await _product.DeleteProductAsync(id);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
