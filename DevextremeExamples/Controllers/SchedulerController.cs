using DevextremeExamples.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DevextremeExamples.Controllers
{
    public class SchedulerController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public SchedulerController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var rootPath = _hostingEnvironment.WebRootPath;
            var fullPath = Path.Combine(rootPath, "JsonFile/Data.json");
            var jsonData = System.IO.File.ReadAllText(fullPath);
            List<SchedulerDto> testDtos = JsonConvert.DeserializeObject<List<SchedulerDto>>(jsonData);
            return View(testDtos);
        }
        [HttpPost]
        public IActionResult Update(string models)
        {
            return Json(false);
        }
    }
}
