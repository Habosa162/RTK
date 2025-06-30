namespace RetailEcommerce.Services.Interfaces
{
    public interface ICloudService
    {
        public Task<string> UploadFileAsync(IFormFile file, string folderName);
        public Task<bool> DeleteFileAsync(string fileKey); 
    }
}
