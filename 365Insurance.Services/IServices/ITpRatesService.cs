using _365Insurance.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.IServices
{
    public interface ITpRatesService
    {
        int AddTpRates(List<TpRatesModel> tpRate);
        List<TpRatesModel> GetTpDetailsByID(int stateId, int vehicleTypeId);
    }
}
