using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using TracyShop.Models;

namespace TracyShop.ViewModels
{
    public class UploadImagesOfProduct
    {
        public List<IFormFile> Images { set; get; }
        public List<Product> Product { set; get; }
        public int Selected { set; get; }
    }
}