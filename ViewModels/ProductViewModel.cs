using System.Collections.Generic;
using TracyShop.Models;

namespace TracyShop.ViewModels
{
    public class ProductViewModel
    {
        public List<Category> Categories { set; get; }
        public List<Product> Products { set; get; }
    }
}