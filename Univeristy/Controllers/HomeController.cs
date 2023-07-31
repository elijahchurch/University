using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VendorApp.Models;

namespace VendorApp.Controllers;

public class HomeController : Controller
{
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
        Vendor vendor1 = new("Jammoma's Jerk");
        Vendor vendor2 = new("O-Keto Do-Keto");
        Vendor vendor3 = new("Durpy's Slurpies");
        Order order1 = new("BBQ Sauce");
        Order order2 = new("Chicken");
        Order order3 = new("Rice");
        vendor1.AddOrder(order1);
        vendor1.AddOrder(order2);
        vendor1.AddOrder(order3);
        List<Vendor> allVendors = Vendor.GetAll();
        return View(allVendors);
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Vendor selectedVendor = Vendor.Find(id);
        List<Order> vendorOrders = selectedVendor.VendorOrderList;
        model.Add("vendor", selectedVendor);
        model.Add("orders", vendorOrders);
        return View("Orders", model);
    }

}
