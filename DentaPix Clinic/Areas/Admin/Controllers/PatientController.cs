using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models.ViewModels;
using DentaPix_Clinic.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentaPix_Clinic.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
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
        return View();
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        PatientVM patientVM = new()
        {
            Patient = new(),
            DoctorList = _unitOfWork.Doctor.GetAll().Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.DoctorId.ToString()
            }),
        };

        if (id == null || id == 0)
        {
            //create patient
            //ViewBag.DoctorList = DoctorList;
            //ViewData["DoctorList"] = DoctorList;
            return View(patientVM);
        }
        else
        {
            patientVM.Patient = _unitOfWork.Patient.GetFirstOrDefault(u => u.PatientId == id);
            return View(patientVM);
            //update patient
        }
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

                if (obj.Patient.ImageURL != null)
                {
                    var oldImagePath = Path.Combine(wwwRoothPath, obj.Patient.ImageURL.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.Patient.ImageURL = @"\images\patientsDP\" + fileName + extension;
            }

            if (obj.Patient.PatientId == 0)
            {
                _unitOfWork.Patient.Add(obj.Patient);
            }
            else
            {
                _unitOfWork.Patient.Update(obj.Patient);
            }

            _unitOfWork.Save();
            TempData["success"] = "Patient added successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        var patientList = _unitOfWork.Patient.GetAll();
        return Json(new { data = patientList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Patient.GetFirstOrDefault(u => u.PatientId == id);

        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageURL.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        _unitOfWork.Patient.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });
    }

    #endregion API CALLS
}