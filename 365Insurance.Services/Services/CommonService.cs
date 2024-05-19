using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.Services
{
    public class CommonService : ICommonService
    {
        private readonly Insure247DbContext _context;

        public CommonService(Insure247DbContext context)
        {
            _context = context;
        }
        public async Task<List<VehicleFueltype>> GetVehicleFueltypes()
        {
            return await _context.VehicleFueltypes.Where(s => s.IsDeleted == false) .ToListAsync();
        }

        public async Task<List<VehicleType>> GetVehicleType()
        {
            return await _context.VehicleTypes.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<List<VehicleAge>> GetVehicleAge()
        {
            return await _context.VehicleAges.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<List<StateMa>> GetState()
        {
            return await _context.StateMas.Where(s => s.IsDeleted == false).ToListAsync();
        }
        public async Task<List<RtoMa>> GetRTODetails(int stateId)
        {
            return await _context.RtoMas.Where(s => s.IsDeleted == false && s.StateId == stateId).ToListAsync();
        }

    }
}
