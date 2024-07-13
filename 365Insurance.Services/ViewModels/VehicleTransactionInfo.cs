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

    public class VT2
    {
        public int tp_rates_id { get; set; }
        public int insurance_company_id { get; set; }
        public string? insurance_company_name { get; set; }
        public string? cc_gcw { get; set; }
        public decimal premimum_amount { get; set; }
        public decimal premimum_gst { get; set; }
        public decimal payout_amount { get; set; }
        public decimal pa_cover { get; set; }
        public decimal driver_cover { get; set; }
        public decimal passengers_cover { get; set; }
        public string? age { get; set; }
        public string? fueltype_name { get; set; }
        public string? rto_code { get; set; }
        public string? state_name { get; set; }
    }
}
