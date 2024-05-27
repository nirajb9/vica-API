using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class PolicyCashback
{
    public int CashbackAmountId { get; set; }

    public int? UserId { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? TpRatesId { get; set; }

    public int? TpRequestId { get; set; }

    public decimal? PremimumAmount { get; set; }

    public decimal? CashbackAmount { get; set; }

    public bool? IsPaid { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
