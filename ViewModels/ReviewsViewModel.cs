using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using TracyShop.Models;

namespace TracyShop.ViewModels
{
    public class ReviewsViewModel
    {
        public int Id { set; get; }
        [Required] public int Rate { set; get; } = 0;
        [Required] public string Content { set; get; }
        public IFormFile Image { set; get; }
        public string Avatar { set; get; }
        public string ImageProduct { set; get; }
        public string ProductName { set; get; }
        public string SelectedSize { set; get; }
        public int Size { set; get; }
        public List<Size> Sizes { set; get; }

        public int ProductId { set; get; }
        public string UserId { set; get; }
    }
}