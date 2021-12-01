using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Logic
{
    public class File
    {
        public void Upload(string ownerId, IFormFile file) {
            var newPath = "Images/" + ownerId;
            if (!System.IO.File.Exists(newPath)) {
                System.IO.Directory.CreateDirectory(newPath);
            }
            using (FileStream stream = new FileStream(Path.Combine(newPath, file.FileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            new Data.FileDA().AddImage(Guid.NewGuid().ToString(),file.FileName, ownerId);
            
        }


        public void Delete(string OwnerId, string id)
        {
            var file = new Data.FileDA().GetFile(id);
            System.IO.File.Delete("images/" + OwnerId + "/" + file.Path);
            new Data.FileDA().DeleteFile(file);
            Console.WriteLine("images/" + OwnerId + "/" + file.Path);
        }
    }
}
