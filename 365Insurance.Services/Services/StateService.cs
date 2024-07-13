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
    public class StateService : IStateService
    {

        private readonly Insure247DbContext _context;

        public StateService(Insure247DbContext context)
        {
            _context = context;
        }
        public async Task<List<StateMa>> GetState()
        {
            return await _context.StateMas.ToListAsync();
        }

        // Create
        public async Task<StateMa> AddStateAsync(StateMa state)
        {
            _context.StateMas.Add(state);
            await _context.SaveChangesAsync();
            return state;
        }

        // Read
        public async Task<StateMa> GetStateByIdAsync(int id)
        {
            return await _context.StateMas.FindAsync(id);
        }


        // Update
        public async Task<StateMa> UpdateStateAsync(StateMa state)
        {
            var existingState = await _context.StateMas.FindAsync(state.StateId);
            if (existingState == null) return null;

            existingState.StateName = state.StateName;
            existingState.StateCode = state.StateCode;
            existingState.IsDeleted = state.IsDeleted;
            existingState.CreatedBy = state.CreatedBy;
            existingState.CreatedDate = state.CreatedDate;
            existingState.ModifiedBy = state.ModifiedBy;
            existingState.ModifiedDate = state.ModifiedDate;

            await _context.SaveChangesAsync();
            return existingState;
        }

        // Delete
        public async Task<bool> DeleteStateAsync(int id)
        {
            var state = await _context.StateMas.FindAsync(id);
            if (state == null) return false;

            _context.StateMas.Remove(state);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
