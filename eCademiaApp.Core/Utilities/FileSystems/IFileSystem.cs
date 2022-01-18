using Microsoft.AspNetCore.Http;

namespace eCademiaApp.Core.Utilities.FileSystems
{
    // Signiture for FileSystems with add, update and delete funcs.
    public interface IFileSystem
    {
        string Add(IFormFile file, string path);
        string Update(string pathToUpdate, IFormFile file, string path);
        void Delete(string path);
    }
}
