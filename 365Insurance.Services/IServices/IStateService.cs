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
    }
}
