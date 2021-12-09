using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IFileDA
    {
        Task AddImage(string id, string path, string ownerId);
        Task<bool> CheckIfFileExists(string id);
        void DeleteFile(Common.File file);
        Task<Common.File> GetFile(string id);

    }
}
