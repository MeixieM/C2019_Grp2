using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using DentaPix_Clinic.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class AppointmentController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View();
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        Appointment appointment = new();

        if (id == null || id == 0)
        {
            return View(appointment);
        }
        else
        {
            appointment = _unitOfWork.Appointment.GetFirstOrDefault(u => u.AppointmentId == id);
            return View(appointment);
        }
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Appointment obj)
    {
        if (ModelState.IsValid)
        {
            if (obj.AppointmentId == 0)
            {
                _unitOfWork.Appointment.Add(obj);
                TempData["success"] = "Appointment created successfully";
            }
            else
            {
                _unitOfWork.Appointment.Update(obj);
                TempData["success"] = "Appointment updated successfully";
            }

            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        var appointmentList = _unitOfWork.Appointment.GetAll();
        return Json(new { data = appointmentList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Appointment.GetFirstOrDefault(u => u.AppointmentId == id);

        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        _unitOfWork.Appointment.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });
    }

    #endregion API CALLS
}