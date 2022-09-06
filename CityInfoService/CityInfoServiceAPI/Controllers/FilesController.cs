using Microsoft.AspNetCore.Mvc;

namespace CityInfoServiceAPI.Controllers;

[Route("api/files")]
[ApiController]
public class FilesController : ControllerBase
{
    [HttpGet("{fileId}")]
    public ActionResult GetFile(string fileId)
    {
        var pathToFile = "image1.jpg";
        if (!System.IO.File.Exists(pathToFile))
        {
            return NotFound();
        }

        var bytes = System.IO.File.ReadAllBytes(pathToFile);
        return File(bytes, "text/plain", Path.GetFileName(pathToFile));
    }
}