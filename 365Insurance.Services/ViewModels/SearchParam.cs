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
        public string UserName { get; set; }
    }

    public class UploadModel
    {
        public string? Name { get; set; }
        public string? ContentType { get; set; }
        public string? Content { get; set; }
        public long? FileSize { get; set; }
    }
}
