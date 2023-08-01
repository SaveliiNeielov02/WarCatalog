using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WarCatalog.Models;

namespace WarCatalog.Controllers
{
    public class VehicleAdditionController : Controller
    {
        private readonly ModelDbContext _context;

        public VehicleAdditionController(ModelDbContext context)
        {
            _context = context;
        }
        public IActionResult VehicleAdditionPage()
        {
            return View();
        }
        [HttpPost]
        public JsonResult VehicleAddButton( [FromBody] string data)
        {
            //Название, Тип, Ссылка, Описание
            var properties = data.Split('\n');
            var query = _context.Vehicles.OrderBy(vehicle => vehicle.ID);
            var newVehicle = new Vehicle()
            {
                ID = query.Last().ID + 1,
                Type = _context.Types.FirstOrDefault(_ => _.TypeName == properties[1]),
                Name = properties[0],
                PhotoURL = properties[2],
                Description = string.Join("\n", properties.Skip(3))
            };
            if (_context.Vehicles.Where(_ => _.TypeID == newVehicle.Type.ID)
                .Select(_ => _.Name.ToLower()).FirstOrDefault(_ => _ == newVehicle.Name.ToLower()) == null)
            {
                _context.Vehicles.Add(newVehicle);
                _context.SaveChanges();
                return Json(new { message = "Данные успешно добавлены!" });
            }
            else return Json(new { message = "Данная техника уже присутсвует в БД!" });
        }
    }
}
