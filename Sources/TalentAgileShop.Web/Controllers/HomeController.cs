using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TalentAgileShop.Model;
using TalentAgileShop.Web.Models;

namespace TalentAgileShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FeatureSet featureSet;

        public HomeController(ILogger<HomeController> logger, FeatureSet featureSet)
        {
            _logger = logger;
            this.featureSet = featureSet;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("catalog")]
        public ActionResult Catalog([FromQuery]string view,[FromQuery]string category)
        {
            var products = new List<Product> {
                new Product { Id = "agile-pen", Name = "Agile Pen", Price = 9.90m },
                new Product { Id = "agile-tshirt", Name = "Agile T-Shirt", Price = 19.90m },
            };
            var categories = new List<string> { "pens" };

            var viewModel = new CatalogViewModel(products, categories) {
                ThumbnailViewAvailable = featureSet.ThumbnailViewEnabled,
                ShowCategories = featureSet.CatalogCategoriesEnabled,
                CurrentCategory = category
            };
        
            return View(viewModel);
        }

        [Route("products/{id}")]
        public IActionResult Product(string id)
        {
            var product = new Product {
                Id = "agile-pen",
                Name = "Agile Pen",
                Description = "A set of 10 agile pens",
                Category = new Category { Id = "pens", Name = "Pens" },
                Origin = new Country { Id = "fr", Name = "France" },
                Size = ProductSize.Small,
                Price = 9.9m
            };

            var viewModel = new ProductViewModel(product);

            return View(viewModel);
        }

        [Route("products/{id}/image")]
        public IActionResult ProductImage(string id)
        {
            return this.File("~/img/image.png", "image/png");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
