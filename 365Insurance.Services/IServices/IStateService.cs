using _365Insurance.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.IServices
{
    public interface IStateService
    {
        Task<List<StateMa>> GetState();
        Task<bool> DeleteStateAsync(int id);
        Task<StateMa> UpdateStateAsync(StateMa state);
        Task<StateMa> GetStateByIdAsync(int id);
        Task<StateMa> AddStateAsync(StateMa state);
        Task<bool> EnableStateAsync(int id);
    }
}
