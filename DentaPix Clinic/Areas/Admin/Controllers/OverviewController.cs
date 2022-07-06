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


            //PatientList = _unitOfWork.Patient.GetAll().Select();



            //OverviewVM overviewVM = new();

            //var PatientList = _unitOfWork.Patient.GetAll().Select(u => u.PatientId == '1');


            return View();

            //var patientFromDb = _unitOfWork.Patient.GetAll(u => u.PatientId == id);

            //// Count how many messages the discussion has 
            //var patientCount = _unitOfWork.Entry(patientFromDb)
            //                      .Collection(d => d.Messages)
            //                      .Query()
            //                      .Count();


        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var patientList = _unitOfWork.Patient.GetAll();

        //    int cnt = patientList.Count();
        //    return Json(new { data = patientList });

        //}
    }
}

