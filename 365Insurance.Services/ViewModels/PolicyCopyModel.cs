using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.ViewModels
{
    public class PolicyCopyModel
    {
        public int PolicyCopyId { get; set; }

        public int? UserId { get; set; }

        public string? VehicleNo { get; set; }

        public string? PolicyCopyUrl { get; set; }

        public string? Status { get; set; }

        public bool? IsDeleted { get; set; }
        public string? UserName { get; set; }

        public string? PolicyCopyFileName { get; set; }
        public int? AgentCompanyId { get; set; }

        public int? TpRequestId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
