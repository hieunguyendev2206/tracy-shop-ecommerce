using System.ComponentModel.DataAnnotations;

namespace TracyShop.ViewModels
{
    public class PaymentModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Địa chỉ email đã đăng ký")]
        public string Email { get; set; }

        public bool IsPay { get; set; }
        public bool EmailSent { get; set; }
    }
}