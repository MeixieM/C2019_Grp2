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

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var doctorFromDb = _db.Doctors.Find(id);

            if (doctorFromDb == null)
            {
                return NotFound();
            }
            return View(doctorFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Doctor obj)
        {
            if (obj.FullName == obj.Career.ToString())
            {
                ModelState.AddModelError("FullName", "Career cannot exactly match the FullName");
            }
            if (ModelState.IsValid)
            {
                _db.Doctors.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var doctorFromDb = _db.Doctors.Find(id);

            if (doctorFromDb == null)
            {
                return NotFound();
            }
            return View(doctorFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Doctor obj)
        {
            if (obj.FullName == obj.Career.ToString())
            {
                ModelState.AddModelError("FullName", "Career cannot exactly match the FullName");
            }
            if (ModelState.IsValid)
            {
                _db.Doctors.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var doctorFromDb = _db.Doctors.Find(id);

            if (doctorFromDb == null)
            {
                return NotFound();
            }
            return View(doctorFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Doctor obj)
        {
            if (obj.FullName == obj.Career.ToString())
            {
                ModelState.AddModelError("FullName", "Career cannot exactly match the FullName");
            }
            if (ModelState.IsValid)
            {
                _db.Doctors.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



    }
}
