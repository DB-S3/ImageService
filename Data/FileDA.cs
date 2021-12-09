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
        public async Task AddImage(string id, string path, string ownerId) {
            using (var db = new Database()) {
                db.Files.Add(new Common.File() { Id = id, Owner = ownerId, Path = path });
                db.SaveChanges();
            }
        }

        public async Task<bool> CheckIfFileExists(string id)
        {
            using (var db = new Database())
            {
                if (db.Files.Where(x => x.Path == id).Count() > 0) {
                    return true;
                }
                return false;
            }
        }

        public void DeleteFile(Common.File file)
        {
            using (var db = new Database())
            {
                db.Files.Remove(file);
                db.SaveChanges();
            }
        }

        public async Task<Common.File> GetFile(string id)
        {
            using (var db = new Database())
            {
                return db.Files.Where(x => x.Id == id).FirstOrDefault();
            }
        }
    }
}
