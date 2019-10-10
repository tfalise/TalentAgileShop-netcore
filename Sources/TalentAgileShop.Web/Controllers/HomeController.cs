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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("catalog")]
        public ActionResult Catalog([FromQuery]string view,[FromQuery]string category)
        {
            // if (!_featureSet.CatalogCategories)
            // {
            //     category = null;
            // }


            // var query = _dataContext.Products.Include(p=> p.Image).Include(p => p.Category);
            // if (category != null)
            // {
            //     query = query.Where(p => p.Category.Name == category);
            // }
            
                
                
            // var products = query.Include(p => p.Origin).OrderBy(p => p.Name).ToList();
            // var categories = _dataContext.Categories.OrderBy(c => c.Name).Select(c => c.Name).ToList();

            // var viewModel = new CatalogViewModel(products, categories)
            // {
            //     ThumbnailViewAvailable = _featureSet.ThumbnailView,
            //     ShowCategories = _featureSet.CatalogCategories,
            //     CurrentCategory = category,
            // };
            // if (_featureSet.ThumbnailView && view == "thumbnail")
            // {
            //     viewModel.CurrentViewType = CatalogViewModel.ViewType.Thumbnail;
            // }
            // else
            // {
            //     viewModel.CurrentViewType = CatalogViewModel.ViewType.List;
            // }
            var products = new List<Product> {
                new Product { Id = "agile-pen", Name = "Agile Pen", Price = 9.90m },
                new Product { Id = "agile-tshirt", Name = "Agile T-Shirt", Price = 19.90m },
            };
            var categories = new List<string>();

            var viewModel = new CatalogViewModel(products, categories) {
                ThumbnailViewAvailable = false,
                ShowCategories = false,
                CurrentCategory = category
            };
        
            return View(viewModel);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
