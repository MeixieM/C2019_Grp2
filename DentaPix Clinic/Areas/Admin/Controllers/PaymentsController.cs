﻿using DentaPix_Clinic.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DentaPix_Clinic.Areas.Admin.Controllers;
[Area("Admin")]
public class PaymentsController : Controller
{
    private readonly AppDbContext _context;

    public PaymentsController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var allPayments = await _context.Payments.ToListAsync();
        return View();
    }
}
