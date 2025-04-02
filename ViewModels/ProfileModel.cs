using System;
using Microsoft.AspNetCore.Http;

namespace TracyShop.ViewModels
{
    public class ProfileModel
    {
        public string Name { set; get; }

        public string UserName { set; get; }

        public IFormFile AvatarPath { set; get; }
        public DateTime? Birthday { set; get; }

        public string Email { set; get; }

        public string PhoneNumber { set; get; }

        public string Gender { set; get; }
    }
}