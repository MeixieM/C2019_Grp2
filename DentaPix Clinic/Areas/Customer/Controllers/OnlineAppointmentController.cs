using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Areas.Customer.Controllers;

[Area("Customer")]
public class OnlineAppointmentController : Controller
{

    private readonly IUnitOfWork _unitOfWork;

    public OnlineAppointmentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    //GET
    public IActionResult Insert(int? id)
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
    public IActionResult Insert(Appointment obj)
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
            return RedirectToAction("Insert");
        }
        return View(obj);
    }


}

