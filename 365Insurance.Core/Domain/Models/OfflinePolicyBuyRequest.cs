using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class OfflinePolicyBuyRequest
{
    public int OfflinePolicyRequestId { get; set; }

    public int? OfflineQuotationId { get; set; }

    public string? RcFUrlm { get; set; }

    public string? RcBUrlm { get; set; }

    public string? AadharFUrlm { get; set; }

    public string? AadharBUrlm { get; set; }

    public string? PanFUrlm { get; set; }

    public string? PanBUrlm { get; set; }

    public string? Quotation { get; set; }

    public string? Remark { get; set; }

    public string? PaymentLink { get; set; }

    public string? Status { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
