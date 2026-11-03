using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VMS_Hisham_El_Shiraida.Data;
using VMS_Hisham_El_Shiraida.Models;

namespace VMS_Hisham_El_Shiraida.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly AppDbContext _context;

        public VehiclesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return View(vehicles);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.VehicleId == id.Value);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Make,Type,PurchaseDate,Year,Price")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,Make,Type,PurchaseDate,Year,Price")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.VehicleId == id.Value);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Filter(VehicleType? selectedType)
        {
            ViewBag.SelectedType = selectedType;

            if (selectedType.HasValue)
            {
                var matchingVehicles = await _context.Vehicles
                    .Where(v => v.Type == selectedType.Value)
                    .OrderBy(v => v.Make)
                    .ToListAsync();

                return View(matchingVehicles);
            }

            return View(new List<Vehicle>());
        }

        public async Task<IActionResult> PriceSearch(decimal? minPrice)
        {
            ViewBag.MinPrice = minPrice;

            if (minPrice.HasValue)
            {
                var query = _context.Vehicles
                    .Where(v => v.Price > minPrice.Value);

                List<Vehicle> matchingVehicles;

                if (_context.Database.IsSqlite())
                {
                    var list = await query.ToListAsync();
                    matchingVehicles = list.OrderByDescending(v => v.Price).ToList();
                }
                else
                {
                    matchingVehicles = await query.OrderByDescending(v => v.Price).ToListAsync();
                }

                return View(matchingVehicles);
            }

            return View(null);
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleId == id);
        }
    }
}
