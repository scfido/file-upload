using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using fileupload.Models;
using Microsoft.AspNetCore.Http;

namespace fileupload.Controllers
{
    public class UploadController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UploadController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Complete(UploadFileInfo fileInfo)
        {
            Console.WriteLine($"{fileInfo.Hash}已完成");

            //合并文件成功后返回true
            return Json(new{Result=true});
        }


        public IActionResult ExistChunks(UploadFileInfo fileInfo)
        {
            Console.WriteLine($"Get[{fileInfo.Hash}] hash");
            return Json(
                new {
                    existChunks= new string[]{
                    "517a7af1baf71961c59df93748883f8c",
                    "8915cffa187536bea69e96087840e24b",
                    "2b242305657669477b394dcbffdad864",
                    "16a7b36a5d83079ed334be306219d5f1",
                    "f617d7db019813e58a17b330f9245b76",
                    "0398043b0a85cd4f61ddfb9c6d9e0a83",
                    "9d2253c714337866393e7cdc0e9cdeca"
                }
            });
        }

        [HttpPost]
        public IActionResult File(IFormFile file, UploadFileInfo fileInfo)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} {file.FileName} Size:{file.Length}/{fileInfo.Size} Chunk:{fileInfo.Chunk}/{fileInfo.Chunks}");

            return Json(new { Result = "OK" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
