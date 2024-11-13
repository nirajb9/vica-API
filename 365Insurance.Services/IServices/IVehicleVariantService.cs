using VICAInsurance.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.IServices
{
    public interface IVehicleVariantService
    {
        Task<List<VehicleVariant>> GetAllVehicleVariant();
        Task<VehicleVariant> GetVehicleVariantById(int id);
        Task<int> AddVehicleVariant(VehicleVariant vehicleVariant);
        Task<string> UpdateVehicleVariant(VehicleVariant vehicleVariant);
        Task<string> DeleteVehicleVariant(int id);
        Task<List<VehicleVariant>> GetVehicleVariantByModelId(int id);
    }
}
