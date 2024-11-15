using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class PolicyCashback
{
    public int PolicyCashbackId { get; set; }

    public int? PolicyCashbackRequestId { get; set; }

    public int? UserId { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? TpRatesId { get; set; }

    public int? TpRequestId { get; set; }

    public int? OfflineQuotationId { get; set; }

    public decimal? PremimumAmount { get; set; }

    public decimal? CashbackAmount { get; set; }

    public string? Status { get; set; }

    public string? TransactionDetails { get; set; }

    public string? TransactionProof1 { get; set; }

    public string? TransactionProof2 { get; set; }

    public bool? IsPaid { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
