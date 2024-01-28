using Project.API.Models.Products.DTOs;
using Project.API.Models.Shared;

namespace Project.API.Models.Products;

public interface IProductService
{
    ResponseDto<List<ProductDto>> GetAll();
    ResponseDto<ProductDto> GetById(int id);
    ResponseDto<bool> Delete(int id);
    ResponseDto<int> Add(ProductAddDtoRequest request);
    ResponseDto<ProductDto> Update(int id, ProductDto updatedProductDto);
}