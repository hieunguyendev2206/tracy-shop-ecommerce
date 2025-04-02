using System;
using System.ComponentModel.DataAnnotations;

namespace TracyShop.Models
{
    public class ResponseMessage
    {
        [Key] public int Id { set; get; }
        public DateTime CreatedAt { set; get; } = DateTime.Now;
        public string Response { set; get; }
        public int ChatId { set; get; }

        public virtual Chat Chat { set; get; }
    }
}