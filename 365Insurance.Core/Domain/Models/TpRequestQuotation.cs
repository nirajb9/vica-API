using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class TpRequestQuotation
{
    public int TpRequestId { get; set; }

    public string? Name { get; set; }

    public string? MobileNo { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? UserId { get; set; }

    public string? EmailId { get; set; }

    public int? TpId { get; set; }

    public int? CompanyId { get; set; }

    public string? VehicleNo { get; set; }

    public decimal? PremimumAmount { get; set; }

    public decimal? CashbackAmount { get; set; }

    public decimal? PaCoverAmount { get; set; }

    public decimal? DriverCoverAmount { get; set; }

    public decimal? PessangerCoverAmount { get; set; }

    public string? RcFUrlm { get; set; }

    public string? RcBUrlm { get; set; }

    public string? AadharFUrlm { get; set; }

    public string? AadharBUrlm { get; set; }

    public string? PanFUrlm { get; set; }

    public string? PanBUrlm { get; set; }

    public string? DlFUrlm { get; set; }

    public string? DlBUrlm { get; set; }

    public string? OldPolicyUrlm { get; set; }

    public string? RcFUrlw { get; set; }

    public string? RcBUrlw { get; set; }

    public string? AadharFUrlw { get; set; }

    public string? AadharBUrlw { get; set; }

    public string? PanFUrlw { get; set; }

    public string? PanBUrlw { get; set; }

    public string? DlFUrlw { get; set; }

    public string? DlBUrlw { get; set; }

    public string? OldPolicyUrlw { get; set; }

    public bool? IsDeleted { get; set; }

    public string? NomineeName { get; set; }

    public string? NomineeRelationship { get; set; }

    public string? NomineeDob { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
