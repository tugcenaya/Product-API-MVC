using System.ComponentModel.DataAnnotations;

namespace Project.API.Models.Products.DTOs;

public class ProductAddDtoRequest
{
    [Required(ErrorMessage = "Product name cannot be empty!")]
    public string Name { get; set; } = null!;
    public decimal? Price { get; set; }
    public string Description { get; set; }=null!;
}