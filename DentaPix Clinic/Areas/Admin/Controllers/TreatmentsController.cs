using DentaPix_Clinic.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Areas.Admin.Controllers
{
    public class TreatmentsController : Controller
    {
        private readonly AppDbContext _context;

        public TreatmentsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Treatments.ToList();
            return View();
        }
    }
}
