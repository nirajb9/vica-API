using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.ViewModels
{
    public class OfflineQuotationRequestModel
    {
        public int OfflineQuotationId { get; set; }

        public decimal? Idv { get; set; }

        public string? Insurancecompanies { get; set; }

        public string? Status { get; set; }

        public string? RcFUrlm { get; set; }

        public string? RcBUrlm { get; set; }

        public int? AgentCompanyId { get; set; }

        public int? UserId { get; set; }

        public bool? Pacover { get; set; }

        public bool? Dacover { get; set; }

        public bool? Passangercover { get; set; }

        public string? VehicleNo { get; set; }
        public string? UserName { get; set; }
    }

    public class OfflineQuotationRequestDetailsModel
    {
        public int OfflineQuotationDetailsId { get; set; }

        public int? OfflineQuotationId { get; set; }

        public decimal? PremiumAmount { get; set; }

        public decimal? PayoutAmount { get; set; }

        public string? QuotationUrl { get; set; }

        public string? Status { get; set; }
        public string? InsuranceCompanyName { get; set; }
    }
 }
