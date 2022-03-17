using DevextremeExamples.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DevextremeExamples.Controllers
{
    public class DiagramController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private string rootPath = string.Empty;
        public DiagramController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            rootPath = _hostingEnvironment.WebRootPath;
        }
        public IActionResult Index()
        {
            NodeandEdgeArraysDto nodeandEdgeArraysDto = new NodeandEdgeArraysDto();
            nodeandEdgeArraysDto.flowEdges = GetFlowEdgesJson(Path.Combine(rootPath, "JsonFile/flowEdges.json"));
            nodeandEdgeArraysDto.flowNodes = GetFlowNodesJson(Path.Combine(rootPath, "JsonFile/flowNodes.json"));
            return View(nodeandEdgeArraysDto);
        }
        private List<FlowEdgesDto> GetFlowEdgesJson(string path)
        {
            var jsonData = System.IO.File.ReadAllText(path);
            List<FlowEdgesDto> rowSelectionDtos = JsonConvert.DeserializeObject<List<FlowEdgesDto>>(jsonData);
            return rowSelectionDtos;
        }
        private List<FlowNodesDto> GetFlowNodesJson(string path)
        {
            var jsonData = System.IO.File.ReadAllText(path);
            List<FlowNodesDto> rowSelectionDtos = JsonConvert.DeserializeObject<List<FlowNodesDto>>(jsonData);
            return rowSelectionDtos;
        }
        [HttpPost]
        public IActionResult Update(string EdgesOption, string NodesOption)
        {
            if (!string.IsNullOrEmpty(EdgesOption))
            {
                List<FlowEdgesDto> _EdgesOption = JsonConvert.DeserializeObject<List<FlowEdgesDto>>(EdgesOption);
                var EdgesOptionPath = Path.Combine(rootPath, "JsonFile/flowEdges.json");
                System.IO.File.WriteAllText(EdgesOptionPath, "");
                System.IO.File.WriteAllText(EdgesOptionPath, JsonConvert.SerializeObject(_EdgesOption));
            }
            if (!string.IsNullOrEmpty(NodesOption))
            {
                List<FlowNodesDto> _NodesOption = JsonConvert.DeserializeObject<List<FlowNodesDto>>(NodesOption);
                var NodesOptionPath = Path.Combine(rootPath, "JsonFile/flowNodes.json");
                System.IO.File.WriteAllText(NodesOptionPath, "");
                System.IO.File.WriteAllText(NodesOptionPath, JsonConvert.SerializeObject(_NodesOption));
            }
            return Json(true);
        }
    }
}
