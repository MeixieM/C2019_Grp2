using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentaPix_Clinic.Areas.Admin.Controllers;

[Area("Admin")]
public class PaymentController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PaymentController(IUnitOfWork unitOfWork)
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
        PaymentVM paymentVM = new()
        {
            Payment = new(),
            PatientList = _unitOfWork.Patient.GetAll().Select(i => new SelectListItem
            {
                Text = i.FirstName + " " + i.LastName,
                Value = i.PatientId.ToString()
            }),
            TreatmentList = _unitOfWork.Treatment.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name + "   ₱" + i.TreatmentPrice,
                Value = i.TreatmentId.ToString()
            }),
        };

        if (id == null || id == 0)
        {
            return View(paymentVM);
        }
        else
        {
            paymentVM.Payment = _unitOfWork.Payment.GetFirstOrDefault(u => u.PaymentId == id);
            return View(paymentVM);
        }
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(PaymentVM obj)
    {
        if (ModelState.IsValid)
        {
            if (obj.Payment.PaymentId == 0)
            {
                _unitOfWork.Payment.Add(obj.Payment);
                TempData["success"] = "Payment created successfully";
            }
            else
            {
                _unitOfWork.Payment.Update(obj.Payment);
                TempData["success"] = "Payment updated successfully";
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
        var paymentList = _unitOfWork.Payment.GetAll(includeProperties: "Patient,Treatment");
        return Json(new { data = paymentList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Payment.GetFirstOrDefault(u => u.PaymentId == id);

        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        _unitOfWork.Payment.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });
    }

    #endregion API CALLS
}