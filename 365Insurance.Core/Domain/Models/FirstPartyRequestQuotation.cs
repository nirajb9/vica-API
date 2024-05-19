using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class FirstPartyRequestQuotation
{
    public int FpReqQuotationId { get; set; }

    public int? AgentCodeId { get; set; }

    public string? RcFront { get; set; }

    public string? RcBack { get; set; }

    public string? PreviousInsurance { get; set; }

    public decimal? IdvValue { get; set; }

    public string? Name { get; set; }

    public string? MobileNo { get; set; }

    public string? Email { get; set; }

    public string? Comments { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
