using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Areas.Admin.Controllers;
[Area("Admin")]

public class DoctorsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public DoctorsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Doctor> objDoctorList = _unitOfWork.Doctor.GetAll();
        return View(objDoctorList);
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
            _unitOfWork.Doctor.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "New doctor added successfully";
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
        //var doctorFromDb = _db.Doctors.Find(id);
        var doctorFromDb = _unitOfWork.Doctor.GetFirstOrDefault(u => u.DoctorId == id);

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
