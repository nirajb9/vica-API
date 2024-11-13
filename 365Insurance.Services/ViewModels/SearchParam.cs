using VICAInsurance.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.ViewModels
{
    public class SearchParam
    {
        public int StateId { get; set; }
        public int RTOId { get; set; }
        public int VehicleTypeId { get; set; }
        public int CCId { get; set; }
        public int FuelTypeId { get; set; }
        public int AgeId { get; set; }
        public int UserId { get; set; }
        public int AgentCompanyId { get; set; }
        public string? UserName { get; set; }
        public string? VehicleRegistration { get; set; }
        public int PolicyTypeId { get; set; }
    }

    public class UploadModel
    {
        public string? Name { get; set; }
        public string? ContentType { get; set; }
        public string? Content { get; set; }
        public long? FileSize { get; set; }
    }

    public class AllMastersModel
    {
        public List<VehicleFueltype>? FuelTypeList { get; set; }
        public List<VehicleType>? VehicleTypeList { get; set; }
        public List<VehicleAge>? VehicleAgeList { get; set; }
        public List<StateMa>? StateList { get; set; }
        public List<RtoMa>? RtoList { get; set; }
        public List<VehicleInsuranceCompany>? VehicleInsuranceCompanyList { get; set; }
        public List<VehicleCubicCapicity>? VehicleCubicCapicityList { get; set; }
        public int GSTValue { get; set; }
    }

    public class ClaimSupportModel
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactNo { get; set; }
    }

    public class MonthlyGridModel
    {
        public int Id { get; set; }
        public string? StateCode { get; set; }
        public string? StateName { get; set; }
        public string? Month { get; set; }
        public string? FileLink { get; set; }
    }

    public class PolicyCopySearch
    {
        public int userid { get; set; }
        public DateTime? startdate { get; set; }
        public DateTime? enddate { get; set; }
    }
}
