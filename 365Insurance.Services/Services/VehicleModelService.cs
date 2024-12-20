﻿using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly _247IDbContext _context;

        public VehicleModelService(_247IDbContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleModel>> GetAllVehicleModel()
        {
            return await _context.VehicleModels.ToListAsync();
        }

        public async Task<VehicleModel> GetVehicleModelById(int id)
        {
            return await _context.VehicleModels.FindAsync(id);
        }

        public async Task<int> AddVehicleModel(VehicleModel vehicleModel)
        {
            try
            {
                _context.VehicleModels.Add(vehicleModel);
                await _context.SaveChangesAsync();
                return vehicleModel.ModelId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<string> UpdateVehicleModel(VehicleModel vehicleModel)
        {
            try
            {
                _context.Entry(vehicleModel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Sucess";
        }

        public async Task<string> DeleteVehicleModel(int id)
        {
            try
            {
                var vehicleModel = await _context.VehicleModels.FindAsync(id);
                if (vehicleModel != null)
                {
                    _context.VehicleModels.Remove(vehicleModel);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Sucess";

        }
        public async Task<List<VehicleModel>> GetVehicleModelByCompanyId(int id)
        {
            return await _context.VehicleModels.Where(s => s.CompanyId == id).ToListAsync();
        }
    }
}
