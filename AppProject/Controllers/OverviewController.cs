using Microsoft.AspNetCore.Mvc;

namespace AppProject.Controllers;

    public class OverviewController : Controller
    {
        [Route("admin/overview")]
        public ActionResult Index()
        {
            return View();
        }

    }

