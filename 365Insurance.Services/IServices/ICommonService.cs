using _365Insurance.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.IServices
{
    public interface ICommonService
    {
        Task<List<VehicleFueltype>> GetVehicleFueltypes();
        Task<List<VehicleType>> GetVehicleType();
        Task<List<VehicleAge>> GetVehicleAge();
        Task<List<StateMa>> GetState();
        Task<List<RtoMa>> GetRTODetails(int stateId);
    }
}
