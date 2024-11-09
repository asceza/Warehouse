using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using Warehouse.DAL.Abstract;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Services;
using Warehouse.Domain.Services.Abstract;
using Warehouse.WebUI.Models;


namespace Warehouse.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService _productService;
        private IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IProductRepository productRepository)
        {
            _logger = logger;
            _productService = productService;
            _productRepository = productRepository;
        }



        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _productService.GetAllProducts();
            return View(products);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
