using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult<object> UploadFile( IFormFile file)
        {
           // var file = Request.Form.Files.FirstOrDefault();
            if(file!=null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);
                using (var stream= new FileStream(path,FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok(new { size=file.Length});
            }else
                return Ok(new { size = 0 });
        }
        public ActionResult<object> UploadFiles(IList<IFormFile> files)
        {
            var returnLst = new List<Object>(); 
           // var files = Request.Form.Files;
            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {

                    var file = files[i];
                    var path = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    returnLst.Add(new { size = file.Length, fileSequenceId=i });
                }
                return Ok(returnLst);
            }
            else
                return Ok(returnLst);
        }
    }
}