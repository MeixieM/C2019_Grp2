using DentaPix_Clinic.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OverviewController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public OverviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            return View();


        }

    }
}

