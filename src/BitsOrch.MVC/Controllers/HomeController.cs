using BitsOrch.ApplicationCore.Interfaces;
using BitsOrch.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using BitsOrch.MVC.Models;
using CsvHelper;

namespace BitsOrch.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IFileService _fileService;
    
    private List<FieldDTO> _list = new();

    public HomeController(IFileService fileService) => _fileService = fileService;
    
    public IActionResult Index(List<FieldDTO> list)
    {
        foreach (var r in list)
        {
            _list.Add(r);
        }
        return View(_list);
    }

    [HttpPost]
    public IActionResult Index(IFormFile postedFile, [FromServices] IHostEnvironment hostEnvironment)
    {
        string fileName = $"{hostEnvironment.ContentRootPath}\\files\\{postedFile.FileName}";

        return Index(CreateList(fileName));
    }

    [HttpPost]
    public IActionResult DeleteRow(string id)
    {
        throw new NotImplementedException();
    }

    private List<FieldDTO> CreateList(string fileName)
    {
        var list = new List<FieldDTO>();
        using (var streamReader = new StreamReader(fileName))
        {
            using (var csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture))
            {
                csvReader.Read();
                csvReader.ReadHeader();
                while (csvReader.Read())
                {
                    list.Add(csvReader.GetRecord<FieldDTO>());
                }
            }
            
        }
        return list;
    }
    
}