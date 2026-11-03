using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VMS_Hisham_El_Shiraida.Data;
using VMS_Hisham_El_Shiraida.Models;

namespace VMS_Hisham_El_Shiraida.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _repository;

        public VehiclesController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _repository.GetAllVehiclesAsync();
            return View(vehicles);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _repository.GetVehicleByIdAsync(id.Value);
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
        public async Task<IActionResult> Create([Bind("VehicleId,Make,Type,PurchaseDate,Year,Price")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddVehicleAsync(vehicle);
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

            var vehicle = await _repository.GetVehicleByIdAsync(id.Value);
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
                    await _repository.UpdateVehicleAsync(vehicle);
                }
                catch
                {
                    if (!await _repository.VehicleExistsAsync(vehicle.VehicleId))
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

            var vehicle = await _repository.GetVehicleByIdAsync(id.Value);
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
            await _repository.DeleteVehicleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
