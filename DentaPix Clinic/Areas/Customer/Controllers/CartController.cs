using DentaPix_Clinic.DataAccess.Repository.IRepository;
using DentaPix_Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentaPix_Clinic.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentCartVM AppointmentCartVM { get; set; }

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            AppointmentCartVM = new AppointmentCartVM()
            {
                ListCart = _unitOfWork.AppointmentCart.GetAll(u => u.ApplicationUserId == claim.Value, includeProperties: "Appointment")
            };


            return View(AppointmentCartVM);
        }



    }
}
