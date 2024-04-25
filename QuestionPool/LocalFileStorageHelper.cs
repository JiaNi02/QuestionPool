namespace QuestionPool
{
    public interface IFileStorageHelper
    {
        Task<string> SaveFileAsync(IFormFile uploadImage, string v);
        Task DeleteFileIfExistsAsync(string filePath);
        Task<Stream> GetFileStreamAsync(string filePath);
    }
    public class LocalFileStorageHelper : IFileStorageHelper
    {
        private readonly IWebHostEnvironment _environment;

        public LocalFileStorageHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, folderName);
            Directory.CreateDirectory(uploadsFolder);  // Create the directory if it does not exist

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var imagePath = Path.Combine("/", folderName, uniqueFileName).Replace("\\", "/");
            return imagePath;
        }

        public Task DeleteFileIfExistsAsync(string filePath)
        {
            var fullPath = Path.Combine(_environment.WebRootPath, "uploads", filePath);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            return Task.CompletedTask;
        }

        public Task<Stream> GetFileStreamAsync(string filePath)
        {
            var fullPath = Path.Combine(_environment.WebRootPath, "uploads", filePath);
            if (File.Exists(fullPath))
            {
                return Task.FromResult<Stream>(new FileStream(fullPath, FileMode.Open, FileAccess.Read));
            }

            return Task.FromResult<Stream>(Stream.Null);
        }
    }
}
