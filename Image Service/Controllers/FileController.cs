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
        [HttpPost("upload/{ownerid}")]
        public async Task Get(string ownerid)
        {
            var postedFile = Request.Form.Files[0];
            new Logic.File().Upload(ownerid, postedFile);
            Console.WriteLine(postedFile.FileName);

        }

        [HttpGet("delete/{ownerId}/{id}")]
        public async Task<string> Delete(string ownerId, string id)
        {
            new Logic.File().Delete(ownerId,id);
            return "test";
        }
    }
}
