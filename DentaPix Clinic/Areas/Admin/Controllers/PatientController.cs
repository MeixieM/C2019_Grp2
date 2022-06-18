using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using DentaPix_Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Patient> objPatientList = _unitOfWork.Patient.GetAll();
            return View(objPatientList);
        }


        //GET
        public IActionResult Upsert(int? id)
        {
            //PatientVM patientVM = new()
            //{
            //    Patient = new(),
            //    AppointmentList = _unitOfWork.Appointment.GetAll().Select(i => new SelectListItem
            //    {
            //        Text = i.AppointmentDa,
            //        Value = i.AppointmendId.ToString()
            //    })
            //};

            if (id == null || id == 0)
            {
                //create appointment
                //ViewBag.DoctorList = DoctorList;
                //ViewData["DoctorList"] = DoctorList;
                return View();
            }
            else
            {
                //update appointment
            }

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PatientVM obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //_unitOfWork.Patient.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Patient updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        ////GET
        //public IActionResult Details(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var doctorFromDb = _db.Doctors.Find(id);

        //    if (doctorFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(doctorFromDb);
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Details(Doctor obj)
        //{
        //    if (obj.FullName == obj.Career.ToString())
        //    {
        //        ModelState.AddModelError("FullName", "Career cannot exactly match the FullName");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _db.Doctors.Update(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);
        //}


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var patientFromDb = _unitOfWork.Patient.GetFirstOrDefault(u => u.PatientId == id);


            if (patientFromDb == null)
            {
                return NotFound();
            }
            return View(patientFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Patient.GetFirstOrDefault(u => u.PatientId == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Patient.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Patient deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
