using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class PaymentLink
{
    public int PaymentLinkId { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? UserId { get; set; }

    public int? TpRequestId { get; set; }

    public string? PaymentLink1 { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? ExpiredDate { get; set; }

    public string? Comments { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
