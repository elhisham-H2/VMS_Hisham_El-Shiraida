using System.Collections.Generic;
using System.Threading.Tasks;
using VMS_Hisham_El_Shiraida.Models;

namespace VMS_Hisham_El_Shiraida.Data
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle?> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
        Task<bool> VehicleExistsAsync(int id);
    }
}
