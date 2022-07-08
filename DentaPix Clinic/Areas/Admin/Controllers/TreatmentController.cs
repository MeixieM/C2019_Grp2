using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using DentaPix_Clinic.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentaPix_Clinic.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class TreatmentController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public TreatmentController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
        Treatment treatment = new();

        if (id == null || id == 0)
        {
            return View(treatment);
        }
        else
        {
            treatment = _unitOfWork.Treatment.GetFirstOrDefault(u => u.TreatmentId == id);
            return View(treatment);
        }
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Treatment obj, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            string wwwRoothPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRoothPath, @"images\treatmentPics");
                var extension = Path.GetExtension(file.FileName);

                if (obj.Image != null)
                {
                    var oldImagePath = Path.Combine(wwwRoothPath, obj.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.Image = @"\images\treatmentPics\" + fileName + extension;
            }

            if (obj.TreatmentId == 0)
            {
                _unitOfWork.Treatment.Add(obj);
            }
            else
            {
                _unitOfWork.Treatment.Update(obj);
            }

            _unitOfWork.Save();
            TempData["success"] = "Treatment added successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        var treatmentList = _unitOfWork.Treatment.GetAll();
        return Json(new { data = treatmentList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Treatment.GetFirstOrDefault(u => u.TreatmentId == id);

        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.Image.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        _unitOfWork.Treatment.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });
    }

    #endregion API CALLS
}