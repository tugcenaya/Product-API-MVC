using AutoMapper;
using Project.API.Models.Products.DTOs;
using Project.API.Models.Shared;

namespace Project.API.Models.Products;
public class ProductServiceWithSqlServer(IProductRepository productRepository,IMapper mapper) : IProductService
{
	private IProductRepository _productRepository = productRepository;
	private IMapper _mapper = mapper;

	public ResponseDto<List<ProductDto>> GetAll()
	{
		var productList = _productRepository.GetAll();
		var productListWithDto= _mapper.Map<List<ProductDto>>(productList);

		return ResponseDto<List<ProductDto>>.Success(productListWithDto);
	}

	public ResponseDto<ProductDto> GetById(int id)
	{
		var product = _productRepository.GetById(id);
		if (product == null)
    	{
        	return ResponseDto<ProductDto>.Fail("Product not found");
    	}
		var productDto = _mapper.Map<ProductDto>(product);

    	return ResponseDto<ProductDto>.Success(productDto);
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

	public ResponseDto<int> Add(ProductAddDtoRequest request)
	{
		var product = new Product
		{
			Name = request.Name,
			Price = request.Price!.Value,
			Description = request.Description
		};
		_productRepository.Add(product);

		return ResponseDto<int>.Success(product.Id);
	}
	public ResponseDto<ProductDto> Update(int id, ProductDto updatedProductDto)
	{
    	var existingProduct = _productRepository.GetById(id);
    	if (existingProduct == null)
    	{
        	return ResponseDto<ProductDto>.Fail("Product not found");
    	}
    	_mapper.Map(updatedProductDto, existingProduct);
    	_productRepository.Update(existingProduct);
    	var updatedProductDtoResult = _mapper.Map<ProductDto>(existingProduct);

    	return ResponseDto<ProductDto>.Success(updatedProductDtoResult);
	}
}