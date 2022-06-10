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


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor obj)
        {
            if (obj.FullName == obj.Career.ToString())
            {
                ModelState.AddModelError("FullName", "Career cannot exactly match the FullName");
            }
            if (ModelState.IsValid)
            {
                _db.Doctors.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
