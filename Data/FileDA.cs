using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FileDA : IFileDA
    {
        private readonly Data.Database db;
        public FileDA(Data.Database _db) {
            db = _db;
        } 
        public async Task AddImage(string id, string path, string ownerId) {
            db.Files.Add(new Common.File() { Id = id, Owner = ownerId, Path = path });
            db.SaveChanges();
        }

        public async Task<bool> CheckIfFileExists(string id)
        {
            if (db.Files.Where(x => x.Path == id).Count() > 0) {
                return true;
            }
            return false;
        }

        public void DeleteFile(Common.File file)
        {
            db.Files.Remove(file);
            db.SaveChanges();
        }

        public async Task<Common.File> GetFile(string id)
        {
            return db.Files.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
