﻿namespace TracyShop.Models
{
    public class ProductSize
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int Quantity { set; get; } = 0;
    }
}