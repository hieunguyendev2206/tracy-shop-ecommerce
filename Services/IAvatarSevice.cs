using Microsoft.AspNetCore.Http;

namespace TracyShop.Services
{
    public interface IAvatarSevice
    {
        public void UploadAvatar(IFormFile file);
    }
}