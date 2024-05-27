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
    }
}
