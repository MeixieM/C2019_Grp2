using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DentaPix_Clinic.Areas.Customer.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        //this retrieves all patients from db
        //IEnumerable<Patient> patientList = _unitOfWork.Patient.GetAll(includeProperties: "Doctor");

        //this retrieves all doctors from db
        IEnumerable<Doctor> doctorList = _unitOfWork.Doctor.GetAll();
        return View(doctorList);
    }

    //    public IActionResult Details(int id)
    //    {
    //        MyAppointment appObj = new()
    //        {
    //            Count = 1,
    //            Appointment = _unitOfWork.Appointment.GetFirstOrDefault(u => u.AppointmendId == id);

    //    }
    //        return View(appObj);
    //}



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}