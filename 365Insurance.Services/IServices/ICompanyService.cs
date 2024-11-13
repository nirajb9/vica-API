using VICAInsurance.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace VICAInsurance.Services.IServices
{
    public interface ICompanyService
    {
        Task<List<VehicleCompany>> GetAllVehicleCompany(int id);
        Task<VehicleCompany> GetVehicleCompanyById(int id);
        Task<int> AddVehicleCompany(VehicleCompany vehicleCompany);
        Task<string> UpdateVehicleCompany(VehicleCompany vehicleCompany);
        Task<string> DeleteVehicleCompany(int id);
        
    }
}
