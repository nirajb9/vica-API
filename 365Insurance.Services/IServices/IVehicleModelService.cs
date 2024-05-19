using _365Insurance.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.IServices
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModel>> GetAllVehicleModel();
        Task<VehicleModel> GetVehicleModelById(int id);
        Task<int> AddVehicleModel(VehicleModel vehicleModel);
        Task<string> UpdateVehicleModel(VehicleModel vehicleModel);
        Task<string> DeleteVehicleModel(int id);
        Task<List<VehicleModel>> GetVehicleModelByCompanyId(int id);
    }
}
