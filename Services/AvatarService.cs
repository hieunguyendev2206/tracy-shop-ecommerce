using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace TracyShop.Services
{
    public class AvatarService : IAvatarSevice
    {
        private IHostingEnvironment _hostingEnvironment;

        public AvatarService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async void UploadAvatar(IFormFile file)
        {
            var totalBytes = file.Length;
            var filename = file.FileName.Trim('"');
            filename = EnsureFileName(filename);
            var buffer = new byte[16 * 1024];
            using (var output = File.Create(GetpathAndFileName(filename)))
            {
                using (var input = file.OpenReadStream())
                {
                    int readBytes;
                    while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        await output.WriteAsync(buffer, 0, readBytes);
                        totalBytes += readBytes;
                    }
                }
            }
        }

        private string GetpathAndFileName(string filename)
        {
            var path = _hostingEnvironment.WebRootPath + "\\img\\avatar\\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path + filename;
        }

        private string EnsureFileName(string filename)
        {
            if (filename.Contains("\\")) filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            return filename;
        }
    }
}