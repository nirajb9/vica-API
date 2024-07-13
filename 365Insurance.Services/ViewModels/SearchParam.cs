using _365Insurance.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.ViewModels
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
    }
}
