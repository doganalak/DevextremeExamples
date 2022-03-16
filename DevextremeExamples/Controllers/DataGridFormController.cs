using DevextremeExamples.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DevextremeExamples.Controllers
{
    public class DataGridFormController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public DataGridFormController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            List<UsersDto> ModelState = new List<UsersDto>();
            ModelState.Add(new UsersDto { Adress = "Adres bla bla", BirthDate = DateTime.Now.AddDays(-500), Email = "mail1@mail.com", Id = 1, Name = "Test", SurName = "Test" });
            ModelState.Add(new UsersDto { Adress = "Adres bla bla", BirthDate = DateTime.Now.AddDays(-700), Email = "mail2@mail.com", Id = 1, Name = "Test1", SurName = "Test" });
            ModelState.Add(new UsersDto { Adress = "Adres bla bla", BirthDate = DateTime.Now.AddDays(-1000), Email = "mail3@mail.com", Id = 1, Name = "Test2", SurName = "Test" });
            ModelState.Add(new UsersDto { Adress = "Adres bla bla", BirthDate = DateTime.Now.AddDays(-1500), Email = "mail4@mail.com", Id = 1, Name = "Test3", SurName = "Test" });
            return View(ModelState);
        }
        [HttpPost]
        public IActionResult RowUpdate(UsersDto models)
        {
            return Json(false);
        }
        public IActionResult RowSelectionGrid()
        {
            var rootPath = _hostingEnvironment.WebRootPath;
            var fullPath = Path.Combine(rootPath, "JsonFile/RowSelectionData.json");
            var jsonData = System.IO.File.ReadAllText(fullPath);
            List<RowSelectionDto> rowSelectionDtos = JsonConvert.DeserializeObject<List<RowSelectionDto>>(jsonData);
            return View(rowSelectionDtos);
        }
    }
}
