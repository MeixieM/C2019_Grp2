using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
    public IActionResult Details(int appointmentId)
    {
        AppointmentCart cartObj = new()
        {
            Count = 1,
            AppointmentId = appointmentId,
            Appointment = _unitOfWork.Appointment.GetFirstOrDefault(u => u.AppointmentId == appointmentId)

        };
        return View(cartObj);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult Details(AppointmentCart appointmentCart)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        appointmentCart.ApplicationUserId = claim.Value;

        _unitOfWork.AppointmentCart.Add(appointmentCart);
        _unitOfWork.Save();

        return RedirectToAction(nameof(Insert));

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

            _unitOfWork.Save();
            return RedirectToAction("Details");
        }
        return View(obj);
    }


    ////GET
    //public IActionResult Insert(int? id)
    //{

    //    Appointment appointment = new();
    //    {
    //        if (id == null || id == 0)
    //        {

    //            return View(appointment);

    //        }
    //        else
    //        {
    //            appointment = _unitOfWork.Appointment.GetFirstOrDefault(u => u.AppointmentId == id);
    //            return View(appointment);
    //        }

    //    }   

    //}

    ////POST
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //[Authorize]
    //public IActionResult Insert(Appointment obj, AppointmentCart appointmentCart)
    //{
    //    var claimsIdentity = (ClaimsIdentity)User.Identity;
    //    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
    //    appointmentCart.ApplicationUserId = claim.Value;

    //    _unitOfWork.AppointmentCart.Add(appointmentCart);



    //    if (ModelState.IsValid)
    //    {

    //        if (obj.AppointmentId == 0)
    //        {
    //            _unitOfWork.Appointment.Add(obj);
    //            TempData["success"] = "Appointment created successfully";

    //        }

    //        _unitOfWork.Save();
    //        return RedirectToAction("Details");
    //    }
    //    return View(obj);
    //}


}

