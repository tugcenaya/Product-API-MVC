namespace Project.API.Models.Products;

public class ProductRepositoryWithSqlServer(AppDbContext context) : IProductRepository
{
	private readonly AppDbContext _context = context;

	public List<Product> GetAll()
	{
		var products= _context.Products.ToList();
		_context.SaveChanges();

		return products;
	}

	public Product Add(Product product)
	{
		_context.Products.Add(product);
		_context.SaveChanges();

		return product;
	}

	public void Update(Product product)
	{
		_context.Products.Update(product);
		_context.SaveChanges();
	}

	public void Delete(int id)
	{
		var product = _context.Products.Find(id);
		_context.Remove(product!);
		_context.SaveChanges();
	}

	public Product? GetById(int id)
	{
		return _context.Products.Find(id);
	}
}