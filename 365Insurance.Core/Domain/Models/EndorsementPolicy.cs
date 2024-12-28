using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class EndorsementPolicy
{
    public int EndorsementId { get; set; }

    public int? UserId { get; set; }

    public string? Policycopy { get; set; }

    public string? PolicycopyFinal { get; set; }

    public string? EndorsementType { get; set; }

    public string? RcF { get; set; }

    public string? RcB { get; set; }

    public string? Kyc1 { get; set; }

    public string? Kyc2 { get; set; }

    public string? Kyc3 { get; set; }

    public string? Kyc4 { get; set; }

    public string? Status { get; set; }

    public string? Comments { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
