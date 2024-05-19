using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace _365Insurance.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly Insure247DbContext _context;

        public CompanyService(Insure247DbContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleCompany>> GetAllVehicleCompany(int id)
        {
            return await _context.VehicleCompanies.Where(s => s.VehicleType == id).ToListAsync();
        }

        public async Task<VehicleCompany> GetVehicleCompanyById(int id)
        {
            return await _context.VehicleCompanies.FindAsync(id);
        }

        public async Task<int> AddVehicleCompany(VehicleCompany vehicleCompany)
        {
            try
            {
                _context.VehicleCompanies.Add(vehicleCompany);
                await _context.SaveChangesAsync();
                return vehicleCompany.CompanyId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateVehicleCompany(VehicleCompany vehicleCompany)
        {
            try
            {
                _context.Entry(vehicleCompany).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Sucess";
        }

        public async Task<string> DeleteVehicleCompany(int id)
        {
            try
            {
                var vehicleCompany = await _context.VehicleCompanies.FindAsync(id);
                if (vehicleCompany != null)
                {
                    _context.VehicleCompanies.Remove(vehicleCompany);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Sucess";

        }
    }
}
