using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using DentaPix_Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentaPix_Clinic.Areas.Admin.Controllers;
[Area("Admin")]

public class AppointmentController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Doctor> objDoctorList = _unitOfWork.Doctor.GetAll();
        return View(objDoctorList);
    }


    //GET
    public IActionResult Upsert(int? id)
    {
        AppointmentVM appointmentVM = new()
        {
            Appointment = new(),
            DoctorList = _unitOfWork.Doctor.GetAll().Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.DoctorId.ToString()
            })
        };


        if (id == null || id == 0)
        {
            //create appointment
            //ViewBag.DoctorList = DoctorList;
            //ViewData["DoctorList"] = DoctorList;
            return View(appointmentVM);
        }
        else
        {
            //update appointment
        }

        return View(appointmentVM);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Doctor obj)
    {
        if (obj.FullName == obj.Career.ToString())
        {
            ModelState.AddModelError("FullName", "Career cannot exactly match the FullName");
        }
        if (ModelState.IsValid)
        {
            _unitOfWork.Doctor.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Doctor updated successfully";
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
        var doctorFromDb = _unitOfWork.Doctor.GetFirstOrDefault(u => u.DoctorId == id);


        if (doctorFromDb == null)
        {
            return NotFound();
        }
        return View(doctorFromDb);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.Doctor.GetFirstOrDefault(u => u.DoctorId == id);

        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.Doctor.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Doctor deleted successfully";
        return RedirectToAction("Index");
    }
}
