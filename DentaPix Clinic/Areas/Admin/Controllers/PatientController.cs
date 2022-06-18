using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using DentaPix_Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PatientController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Patient> objPatientList = _unitOfWork.Patient.GetAll();
            return View(objPatientList);
        }


        //GET
        public IActionResult Upsert(int? id)
        {
            PatientVM patientVM = new();

            //var patientFromDb = _unitOfWork.Patient.GetFirstOrDefault(u => u.PatientId == id);

            if (id == null || id == 0)
            {
                //create appointment
                //ViewBag.DoctorList = DoctorList;
                //ViewData["DoctorList"] = DoctorList;
                return View(patientVM);
            }
            else
            {
                //update appointment
            }

            return View(patientVM);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PatientVM obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRoothPath, @"images\patientsDP");
                    var extension = Path.GetExtension(file.FileName);

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Patient.ImageURL = @"\images\patientsDP" + fileName + extension;
                }
                _unitOfWork.Patient.Add(obj.Patient);
                _unitOfWork.Save();
                TempData["success"] = "Patient added successfully";
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
