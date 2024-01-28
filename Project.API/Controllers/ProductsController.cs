using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.API.Models.Products;
using Project.API.Models.Products.DTOs;

namespace Project.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductsController(IMapper mapper, IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_productService.GetById(id));
    }

    [HttpPost]
    public IActionResult Add(ProductAddDtoRequest request)
    {
        var result = _productService.Add(request);
        return Created("", result);
    }

    [HttpPut]
    public IActionResult Update(int id, ProductDto updatedProductDto)
    {
        _productService.Update(id,updatedProductDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);
        return NoContent();
    }
}