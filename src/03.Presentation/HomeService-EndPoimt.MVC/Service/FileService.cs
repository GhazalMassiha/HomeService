namespace HomeService_EndPoimt.MVC.Service
{
    public class FileService(IWebHostEnvironment env) : IFileService
    {

        public async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
                return string.Empty;

           
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            
            var uploadsFolder = Path.Combine(env.WebRootPath, "uploads", folder);

            
            if (!System.IO.Directory.Exists(uploadsFolder))
                System.IO.Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            
            return $"/uploads/{folder}/{fileName}";
        }

        public Task<bool> DeleteFileAsync(string filePath)
        {
            
            var fullPath = Path.Combine(env.WebRootPath, filePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
