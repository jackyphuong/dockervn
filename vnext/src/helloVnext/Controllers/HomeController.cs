using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace helloVnext.Controllers
{
    public class HomeController : Controller
    {
        [FromServices]
        public HelloVnextContext DbContext { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        public IActionResult Environment()
        {          
            ViewBag.Message = "Your application description page.";
            var environments = System.Environment.GetEnvironmentVariables();
            return View(environments);
        }

        public async Task<IActionResult> TopSellingAlbums()
        {
            var albums = await DbContext.Albums
                .OrderByDescending(x=>x.Price)
                .Take(10)
                .ToListAsync();
            return View(albums);
        }
    }
}
