using VICAInsurance.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.IServices
{
    public interface IVehicleCubicCapicityService
    {
        Task<List<VehicleCubicCapicity>> GetAllVehicleCubicCapicity();
        Task<VehicleCubicCapicity> GetVehicleCubicCapicityById(int id);
        Task<int> AddVehicleCubicCapicity(VehicleCubicCapicity vehicleCubicCapicity);
        Task<string> UpdateVehicleCubicCapicity(VehicleCubicCapicity vehicleCubicCapicity);
        Task<string> DeleteVehicleCubicCapicity(int id);
        Task<List<VehicleCubicCapicity>> GetAllVehicleCubicCapicityByVT(int vehicletypeid);
    }
}
