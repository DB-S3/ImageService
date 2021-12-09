using Common;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Logic
{
    public class File
    {
        private readonly IFileDA FileDA;

        public async Task<string> Upload(string ownerId, IFormFile file) {
            var newPath = "Images/" + ownerId;
            if (!System.IO.File.Exists(newPath)) {
                System.IO.Directory.CreateDirectory(newPath);
            }
            Console.WriteLine(file.ContentType);
            string id = Guid.NewGuid().ToString();
            var newFileName = id + await GetExtension(file);
            using (FileStream stream = new FileStream(Path.Combine(newPath, newFileName), FileMode.Create))
            {
                file.CopyTo(stream);
            }
  
            await FileDA.AddImage(id, newFileName, ownerId);
            return id;
        }

        public async Task<string> GetExtension(IFormFile file) {
            string extension = "";
            for (int i = file.FileName.Length; i > 0; i--)
            {
                extension = extension + file.FileName[i - 1];
                if (file.FileName[i - 1] == ".".ToCharArray()[0]) {
                    break;
                }
            }
            char[] charArray = extension.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public async Task Delete(string OwnerId, string id)
        {
            var file = await FileDA.GetFile(id);
            System.IO.File.Delete("images/" + OwnerId + "/" + file.Path);
            FileDA.DeleteFile(file);
        }

        public async Task<MemoryStream> GetImage(string id) {
            Common.File file = await FileDA.GetFile(id);
            var dataBytes = System.IO.File.ReadAllBytes("Images/" + file.Owner + "/" + file.Path);
            var dataStream = new MemoryStream(dataBytes);
            return dataStream;
        }

        public File() {
            FileDA = Factory.Factory.GetFileDA();
        }
    }
}
