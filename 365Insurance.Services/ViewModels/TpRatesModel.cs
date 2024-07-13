using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.ViewModels
{
    public class TpRatesModel
    {
        public int TpRatesId { get; set; }
        public int? StateId { get; set; }
        public int? RtoId { get; set; }
        public int? RtoName { get; set; }
        public int? AgentCompanyId { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }
        public int? VehicleVariantId { get; set; }
        public int? FueltypeId { get; set; }
        public int? GcvGvw { get; set; }
        public int? CubicCapicityId { get; set; }
        public int? AgeId { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public decimal? PaCover { get; set; }
        public decimal? DriverCover { get; set; }
        public decimal? PassengersCover { get; set; }
        public decimal? PremimumAmount { get; set; }
        public decimal? PremimumGst { get; set; }
        public decimal? PayoutAmount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsDeleted { get; set; }
        public List<Multiselect> RtoList1 { get; set; }
        public object FueltypeList { get; set; }
        public List<Multiselect> CCList { get; set; }
        public object AgeList { get; set; }
        public object InsuranceCompanyList { get; set; }
        public int? VehicleTypeId { get; set; }
        public List<int> lsRtoId { get; set; }
    }

    public class Multiselect
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool isselect { get; set; }
    }
}
