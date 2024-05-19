using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.ViewModels
{
    public class VehicleTransactionInfo
    {
        public string InsuranceCompanyName { get; set; }
        public decimal? InsuranceAmount { get; set; }
        public decimal? CashBack { get; set; }
    }

    public class VT1
    {
        public string insurance_company_name { get; set; }
        public string cubic_capicity_name { get; set; }
        public string vehicle_type_name { get; set; }
        public decimal final_premium { get; set; }
        public decimal cash_back { get; set; }
       
    }
}
