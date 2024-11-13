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
    public class VehicleCubicCapicityService : IVehicleCubicCapicityService
    {
        private readonly Insure247DbContext _context;

        public VehicleCubicCapicityService(Insure247DbContext context)
        {
            _context = context;
        }


        public async Task<List<VehicleCubicCapicity>> GetAllVehicleCubicCapicity()
        {
            return await _context.VehicleCubicCapicities.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<VehicleCubicCapicity> GetVehicleCubicCapicityById(int id)
        {
            return await _context.VehicleCubicCapicities.FindAsync(id);
        }

        public async Task<int> AddVehicleCubicCapicity(VehicleCubicCapicity vehicleCubicCapicity)
        {
            try
            {
                _context.VehicleCubicCapicities.Add(vehicleCubicCapicity);
                await _context.SaveChangesAsync();
                return vehicleCubicCapicity.CubicCapicityId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<string> UpdateVehicleCubicCapicity(VehicleCubicCapicity vehicleCubicCapicity)
        {
            try
            {
                _context.Entry(vehicleCubicCapicity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Sucess";
        }

        public async Task<string> DeleteVehicleCubicCapicity(int id)
        {
            try
            {
                var vehicleCubicCapicity = await _context.VehicleCubicCapicities.FindAsync(id);
                if (vehicleCubicCapicity != null)
                {
                    _context.VehicleCubicCapicities.Remove(vehicleCubicCapicity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Sucess";

        }
        public async Task<List<VehicleCubicCapicity>> GetAllVehicleCubicCapicityByVT(int vehicletypeid)
        {
            return await _context.VehicleCubicCapicities.Where(s => s.IsDeleted == false && s.VehicleTypeId == vehicletypeid).ToListAsync();
        }
    }
}
