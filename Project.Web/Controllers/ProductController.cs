using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Project.Web.Hubs;
using Project.API.Models.Products;
using Project.API.Models.Products.DTOs;

namespace Project.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHubContext<SignalServer> _hubContext;
        private readonly IProductRepository _productRepository; 

        public ProductController(IHubContext<SignalServer> hubContext, IProductRepository productRepository)
        {
            _hubContext = hubContext;
            _productRepository= productRepository;
        }

        public IActionResult Index()
        {
            _productRepository.GetAll();
            _hubContext.Clients.All.SendAsync("ReceiveProductUpdate", "New product saved");
            return View();
        }

        public IActionResult Save(ProductAddDtoRequest request)
        {
            // Replace this part with your actual save logic
            var newProduct = new Product
            {
                Name = request.Name,
                Price = request.Price!.Value
            };
            
            _productRepository.Add(newProduct);
            _hubContext.Clients.All.SendAsync("ReceiveProductUpdate", "New product saved");

            return View();
        }
        
        public IActionResult Update()
        {
            return View();
        }

    }
}