using BitsOrch.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BitsOrch.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IFileService _fileService;
    
    public HomeController(IFileService fileService) => _fileService = fileService;

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken token)
    {
        var rows = await _fileService.GetRowsAsync(token);
        return View(rows);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteRow(string id, CancellationToken token)
    {
        var result = await _fileService.DeleteRowAsync(id, token);
        if (result != null)
            return RedirectToAction("Index");
        throw new FileNotFoundException();
    }


    [HttpPost]
    public async Task<IActionResult> PostFile(IFormFile postedFile, CancellationToken token)
    {
        if (ModelState.IsValid)
            await _fileService.InsertFileAsync(postedFile.OpenReadStream(), token);
        else
            throw new Exception();
        
        return RedirectToAction("Index");
    }

}