using Client.Models;
using Client.Repositories.Data;
using Client.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;

namespace Client.Controllers;

public class VendorController : Controller
{
    private readonly IVendorRepository repository;
    public VendorController(IVendorRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var result = await repository.Get();
        var vendors = new List<Vendor>();

        if (result.Data != null)
        {
            vendors = result.Data.Select(e => new Vendor
            {
                Guid = e.Guid,
                CompanyName = e.CompanyName,
                Address = e.Address,
                CompanyEmail = e.CompanyEmail,
                Phone = e.Phone,
                Photo = e.Photo,
                Password = e.Password,
                CreateDate = e.CreateDate,
                IsApproved = e.IsApproved,
                ApprovedBy = e.ApprovedBy,
                IsDeleted = e.IsDeleted,
                BusinessField = e.BusinessField,
                BusinessType = e.BusinessType,

            }).ToList();
        }

        return View(vendors);
    }

    [HttpPost]
    public async Task<IActionResult> Register(Vendor vendor)
    {
        var result = await repository.Post(vendor);

        if (result.IsSuccess)
        {
            return RedirectToAction("Index");
        }
        else
        {

            ModelState.AddModelError(string.Empty, "An error occurred while registering the vendor.");
            return View(vendor);
        }
    }

}