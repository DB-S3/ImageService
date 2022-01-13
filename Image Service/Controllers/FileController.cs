using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Image_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly Logic.File PageLogic;
        public FileController(Data.Database db) {
            PageLogic = new Logic.File(db);
        }
        [HttpPost("upload/{ownerid}")]
        public async Task<string> upload(string ownerid)
        {
            var postedFile = Request.Form.Files[0];
            return await PageLogic.Upload(ownerid, postedFile);
        }

        [HttpGet("delete/{ownerId}/{id}")]
        public async Task<string> Delete(string ownerId, string id)
        {
            PageLogic.Delete(ownerId,id);
            return "succes";
        }

        [HttpGet("GetImage/{id}")]
        public async Task<MemoryStream> GetImage(string id)
        {
            return await PageLogic.GetImage(id);
        }
    }
}
