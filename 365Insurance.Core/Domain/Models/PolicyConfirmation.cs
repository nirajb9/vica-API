using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class PolicyConfirmation
{
    public int PolicyConfirmationId { get; set; }

    public string? RcCertificate { get; set; }

    public string? AadharCard { get; set; }

    public string? PanCard { get; set; }

    public string? VoterCard { get; set; }

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
