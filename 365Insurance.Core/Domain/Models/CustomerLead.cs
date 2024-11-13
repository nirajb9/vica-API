using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class CustomerLead
{
    public int LeadId { get; set; }

    public string? CustomerName { get; set; }

    public string? MobileNo { get; set; }

    public string? VehicleNo { get; set; }

    public DateTime? PolicyEnddate { get; set; }

    public int? UserId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
