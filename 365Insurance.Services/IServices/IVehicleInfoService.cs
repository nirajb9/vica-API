using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.IServices
{
    public interface IVehicleInfoService
    {
        Task<VehicleInformation> GetVehicleInformation(VehicleRegistrationSearch vrSearch);
        Task<List<VehicleInfo>> GetAllVehicleInfos();
        Task<VehicleInfo> GetVehicleInfoById(int id);
        Task<int> AddVehicleInfo(VehicleInfo vehicleInfo);
        Task<string> UpdateVehicleInfo(VehicleInfo vehicleInfo);
        Task<string> DeleteVehicleInfo(int id);
        Task<List<VehicleTransactionInfo>> GetInsuranceDetails(int varientId, string stateCode, int level);
        Task<List<VT1>> GetInsuranceDetails(SearchParam searchParam);
        Task<List<VT2>> GetInsuranceDetailsPayout(SearchParam searchParam);
    }

}
