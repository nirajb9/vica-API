using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class OfflineQuotationRequestDetail
{
    public int OfflineQuotationDetailsId { get; set; }

    public int? OfflineQuotationId { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? UserId { get; set; }

    public decimal? PremiumAmount { get; set; }

    public decimal? PayoutAmount { get; set; }

    public string? QuotationUrl { get; set; }

    public string? Status { get; set; }

    public int? InsuranceCompanyId { get; set; }

    public string? InsuranceCompanyName { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
