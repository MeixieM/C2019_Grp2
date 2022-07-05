using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models;
using DentaPix_Clinic.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentaPix_Clinic.Areas.Customer.Controllers;

[Area("Customer")]
public class ServicesController : Controller
{
    private readonly ILogger<ServicesController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public ServicesController(ILogger<ServicesController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        //this retrieves all treatments from db
        IEnumerable<Treatment> treatmentList = _unitOfWork.Treatment.GetAll();
        return View(treatmentList);
    }


    //GET
    public IActionResult Details(int treatmentId)
    {
        ShoppingCart cartObj = new()
        {
            Count = 1,
            TreatmentId = treatmentId,
            Treatment = _unitOfWork.Treatment.GetFirstOrDefault(u => u.TreatmentId == treatmentId),
        };

        return View(cartObj);
    }


    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult Details(ShoppingCart shoppingCart)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        shoppingCart.ApplicationUserId = claim.Value;


        ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
            u => u.ApplicationUserId == claim.Value && u.TreatmentId == shoppingCart.TreatmentId);


        if (cartFromDb == null)
        {

            _unitOfWork.ShoppingCart.Add(shoppingCart);
            _unitOfWork.Save();
            HttpContext.Session.SetInt32(SD.SessionCart,
                _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count);
        }
        else
        {
            _unitOfWork.ShoppingCart.IncrementCount(cartFromDb, shoppingCart.Count);
            _unitOfWork.Save();
        }


        return RedirectToAction(nameof(Index));
    }







}