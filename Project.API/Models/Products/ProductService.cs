using AutoMapper;
using Project.API.Models.Products.DTOs;
using Project.API.Models.Shared;

namespace Project.API.Models.Products;
public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public ResponseDto<ProductDto> Update(int id, ProductDto updatedProductDto)
    {
        var existingProduct = _productRepository.GetById(id);
        if (existingProduct == null)
        {
            return ResponseDto<ProductDto>.Fail("Product not found");
        }
        existingProduct.Name = updatedProductDto.Name;
        existingProduct.Price = updatedProductDto.Price;
        _productRepository.Update(existingProduct);
        var updatedProductDtoResult = _mapper.Map<ProductDto>(existingProduct);

        return ResponseDto<ProductDto>.Success(updatedProductDtoResult);
    }

    public ResponseDto<bool> Delete(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return ResponseDto<bool>.Fail("Product not found");
        }
        _productRepository.Delete(id);

        return ResponseDto<bool>.Success(true);
    }

    public ResponseDto<List<ProductDto>> GetAll()
    {
        var products = _productRepository.GetAll();
        var productDtos = _mapper.Map<List<ProductDto>>(products);

        return ResponseDto<List<ProductDto>>.Success(productDtos);
    }

    public ResponseDto<int> Add(ProductAddDtoRequest request)
    {
        var id = new Random().Next(1, 1000);
        var product = new Product
        {
            Id = id,
            Name = request.Name,
            Price = request.Price!.Value
        };
        _productRepository.Add(product);

        return ResponseDto<int>.Success(id);
    }

    public ResponseDto<ProductDto> GetById(int id)
    {
        var product = _productRepository.GetById(id);
        var productDto = _mapper.Map<ProductDto>(product);

        return ResponseDto<ProductDto>.Success(productDto);
    }
}