using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.Services
{
    public class VehicleVariantService : IVehicleVariantService
    {
        private readonly _247IDbContext _context;

        public VehicleVariantService(_247IDbContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleVariant>> GetAllVehicleVariant()
        {
            return await _context.VehicleVariants.ToListAsync();
        }

        public async Task<VehicleVariant> GetVehicleVariantById(int id)
        {
            return await _context.VehicleVariants.FindAsync(id);
        }

        public async Task<int> AddVehicleVariant(VehicleVariant vehicleVariant)
        {
            try
            {
                _context.VehicleVariants.Add(vehicleVariant);
                await _context.SaveChangesAsync();
                return vehicleVariant.VehicleVariantId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<string> UpdateVehicleVariant(VehicleVariant vehicleVariant)
        {
            try
            {
                _context.Entry(vehicleVariant).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Sucess";
        }

        public async Task<string> DeleteVehicleVariant(int id)
        {
            try
            {
                var vehicleVariant = await _context.VehicleVariants.FindAsync(id);
                if (vehicleVariant != null)
                {
                    _context.VehicleVariants.Remove(vehicleVariant);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Sucess";

        }
        public async Task<List<VehicleVariant>> GetVehicleVariantByModelId(int id)
        {
            return await _context.VehicleVariants.Where(s => s.ModelId == id).ToListAsync();
        }
    }
}
