using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WarCatalog.Models;

namespace WarCatalog.Controllers
{
    public class VehiclesCatalogController : Controller
    {
        private readonly ModelDbContext _context;

        public VehiclesCatalogController(ModelDbContext context)
        {
            _context = context;
        }
        public IActionResult TanksCatalogPage()
        {
            return View("~/Views/VehicleCatalog/VehiclesCatalogPage.cshtml", _context.Vehicles.Where(_ => _.Type.TypeName == "Танк").ToList());
        }
        public IActionResult PlanesCatalogPage()
        {
            return View("~/Views/VehicleCatalog/VehiclesCatalogPage.cshtml", _context.Vehicles.Where(_ => _.Type.TypeName == "Самолет").ToList());
        }
        public IActionResult HelicoptersCatalogPage()
        {
            return View("~/Views/VehicleCatalog/VehiclesCatalogPage.cshtml", _context.Vehicles.Where(_ => _.Type.TypeName == "Вертолет").ToList());
        }
        public IActionResult BMPCatalogPage()
        {
            return View("~/Views/VehicleCatalog/VehiclesCatalogPage.cshtml", _context.Vehicles.Where(_ => _.Type.TypeName == "БМП").ToList());
        }

        public IActionResult VehicleViewPage(int id)
        {
            return View("~/Views/VehicleCatalog/VehicleViewPage.cshtml", _context.Vehicles.ToList().Find(_ => _.ID == id));
        }
        public IActionResult DeleteVehicle(int id, int typeID)
        {
            _context.Vehicles.Remove(_context.Vehicles.FirstOrDefault(_ => _.ID == id));
            _context.SaveChanges();
            switch (typeID) 
            {
                case 1:
                    return TanksCatalogPage();
                case 2:
                    return PlanesCatalogPage();
                case 3:
                    return HelicoptersCatalogPage();
                case 4:
                    return BMPCatalogPage();
            }
            return TanksCatalogPage();
        }

    }
}
