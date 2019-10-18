using TalentAgileShop.Model;
using TalentAgileShop.Data;
using System;
using System.IO;
using System.Linq;

namespace TalentAgileShop.Web.Data 
{
    public static class DbInitializer
    {
        public static void Initialize(TalentAgileShopDataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any product
            if(context.Products.Any())
            {
                return;
            }

            // Initialize seed data
            var france = new Country { Id = "france", Name = "France" };
            var china = new Country { Id = "china", Name = "China" };
            var uk = new Country { Id = "uk", Name = "United Kingdom" };
            var us = new Country { Id = "us", Name = "United States" };
            var countries = new Country[] { france, china, uk, us };
            foreach (var country in countries)
            {
                context.Countries.Add(country);
            }
            context.SaveChanges();

            var apparelCategory = new Category { Id = "apparel", Name = "Apparels" };
            var boardCategory = new Category { Id = "board", Name = "Boards" };
            var penCategory = new Category { Id = "pen", Name = "Pens" };
            var toolsCategory = new Category { Id = "tools", Name = "Tools" };
            var categories = new Category[] { apparelCategory, boardCategory, penCategory, toolsCategory };
            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var products = new Product[] {
                new Product { Id="pen-8", Name="8 whiteboard pens", Size=ProductSize.Small, Price=30, Description="For whiteboard rainbows", Category=penCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\8-pens.png") }, Origin=china },
                new Product { Id="pen-simple", Name="3 whiteboard pens", Size=ProductSize.Small, Price=10, Description="Red, Black, Blue: the basics", Category=penCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\3-pens.png") }, Origin=china },
                new Product { Id="post-it", Name="Post-it set", Size=ProductSize.Small, Price=6, Description="Don't leave home without it", Category=toolsCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\post-it.png") }, Origin=china },
                new Product { Id="post-it-box", Name="THE Post-it Box", Size=ProductSize.Small, Price=15, Description="Enough to share", Category=toolsCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\post-it-box.png") }, Origin=china },
                new Product { Id="tshirt-standup-meeting-l", Name="Standup TShirt Size L", Size=ProductSize.Medium, Price=20, Description="No comment.", Category=apparelCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\tshirt.png") }, Origin=china },
                new Product { Id="tshirt-standup-meeting-M", Name="Standup TShirt Size M", Size=ProductSize.Medium, Price=20, Description="No comment.", Category=apparelCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\tshirt.png") }, Origin=china },
                new Product { Id="tshirt-standup-meeting-s", Name="Standup TShirt Size S", Size=ProductSize.Medium, Price=20, Description="No comment.", Category=apparelCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\tshirt.png") }, Origin=china },
                new Product { Id="tshirt-standup-meeting-xl", Name="Standup TShirt Size XL", Size=ProductSize.Medium, Price=20, Description="No comment.", Category=apparelCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\tshirt.png") }, Origin=china },
                new Product { Id="whiteboard-100-50", Name="Whiteboard 100x50", Size=ProductSize.Large, Price=99, Description="Nice board for small rooms", Category=boardCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\whiteboard.png") }, Origin=france },
                new Product { Id="whiteboard-200-100", Name="Whiteboard 200x100", Size=ProductSize.Medium, Price=20, Description="Big board for bid ideas", Category=boardCategory, Image=new ProductImage { Data = File.ReadAllBytes(@".\wwwroot\img\whiteboard.png") }, Origin=france },
            };
            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}