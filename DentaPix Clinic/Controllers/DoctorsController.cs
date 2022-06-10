using DentaPix_Clinic.Data;
using DentaPix_Clinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDbContext _db;

        public DoctorsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Doctor> objDoctorsList = _db.Doctors;
            return View(objDoctorsList);
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }

    }
}
