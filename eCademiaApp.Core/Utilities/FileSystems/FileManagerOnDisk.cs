using Microsoft.AspNetCore.Http;

namespace eCademiaApp.Core.Utilities.FileSystems
{
    // Saving files on disk manager
    public class FileManagerOnDisk : IFileSystem
    {
        /// <summary>This method saves file(s) to DB.</summary>
        /// <param name="file">file you want to upload</param>
        /// <param name="path">location where you want to place</param>
        public string Add(IFormFile file, string path)
        {
            var sourcepath = Path.GetTempFileName();

            if (file.Length > 0)
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            File.Move(sourcepath, path);
            return path;
        }

        /// <summary>This method updates file(s) from DB.</summary>
        /// <param name="path">former location of file</param>
        /// <param name="file">file you want to update</param>
        /// <param name="path">new location where you want to place</param>
        public string Update(string pathToUpdate, IFormFile file, string path)

        {
            if (path.Length > 0)
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            File.Delete(pathToUpdate);
            return path;
        }

        /// <summary>This method removes file(s) from DB.</summary>
        /// <param name="path">location of file</param>
        public void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
