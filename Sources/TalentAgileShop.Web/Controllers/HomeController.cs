using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TalentAgileShop.Data;
using TalentAgileShop.Model;
using TalentAgileShop.Web.Models;

namespace TalentAgileShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly TalentAgileShopDataContext dataContext;
        private readonly FeatureSet featureSet;

        public HomeController(ILogger<HomeController> logger, FeatureSet featureSet, TalentAgileShopDataContext dataContext)
        {
            this.logger = logger;
            this.dataContext = dataContext;
            this.featureSet = featureSet;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("catalog")]
        public ActionResult Catalog([FromQuery]string view,[FromQuery]string category)
        {
            var query = this.dataContext.Products.Include(p => p.Category).Include(p => p.Image).AsQueryable();
            if(category != null)
            {
                query = query.Where(p => p.Category.Name == category);
            }

            var products = query.Include(p => p.Origin).OrderBy(p => p.Name).ToList();
            var categories = this.dataContext.Categories.OrderBy(c => c.Name).Select(c => c.Name).ToList();

            var viewModel = new CatalogViewModel(products, categories) {
                ThumbnailViewAvailable = featureSet.ThumbnailViewEnabled,
                ShowCategories = featureSet.CatalogCategoriesEnabled,
                CurrentCategory = category
            };

            if (this.featureSet.ThumbnailViewEnabled && view == "thumbnail")
            {
                viewModel.CurrentViewType = CatalogViewModel.ViewType.Thumbnail;
            }
            else
            {
                viewModel.CurrentViewType = CatalogViewModel.ViewType.List;
            }
        
            return View(viewModel);
        }

        [Route("products/{id}")]
        public IActionResult Product(string id)
        {
            var product =
               this.dataContext.Products.Include(p => p.Category).Include(p => p.Origin).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {                
                return NotFound();
            }

            var viewModel = new ProductViewModel(product);
            return View(viewModel);
        }

        [Route("products/{id}/image")]
        public IActionResult ProductImage(string id)
        {
            var product =
                this.dataContext.Products.Include(p => p.Image).FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return this.File(product.Image.Data, "image/png");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
