using DevextremeExamples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevextremeExamples.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            List<DoughnutDto> doughnutDtos = new List<DoughnutDto> { 
            new DoughnutDto{ City="Ankara",Ratio=38250000},
            new DoughnutDto{ City="İstanbul",Ratio=38250000},
            new DoughnutDto{ City="İzmir",Ratio=52820000},
            new DoughnutDto{ City="Adana",Ratio=38420000},
            new DoughnutDto{ City="Muğla",Ratio=38420000},
            };
            return View(doughnutDtos);
        }
        public IActionResult ColorBar()
        {
            List<ColorBarChartDto> colorBarChartDto = new List<ColorBarChartDto> { 
            new ColorBarChartDto{ Nufus=5900000,Yas="13-17"},
            new ColorBarChartDto{ Nufus=38250000,Yas="18-24"},
            new ColorBarChartDto{ Nufus=52820000,Yas="25-34"},
            new ColorBarChartDto{ Nufus=38420000,Yas="35-44"},
            new ColorBarChartDto{ Nufus=32340000,Yas="45-54"},
            new ColorBarChartDto{ Nufus=14060000,Yas="55-64"},
            new ColorBarChartDto{ Nufus=20020000,Yas="65+"},
            };
            return View(colorBarChartDto);
        }
    }
}
