using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}