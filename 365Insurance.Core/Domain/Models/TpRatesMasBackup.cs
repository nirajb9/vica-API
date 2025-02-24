using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class TpRatesMasBackup
{
    public int TpRatesId { get; set; }

    public int? StateId { get; set; }

    public int? RtoId { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? UserId { get; set; }

    public int? CompanyId { get; set; }

    public int? VehicleVariantId { get; set; }

    public int? FueltypeId { get; set; }

    public int? GcvGvw { get; set; }

    public int? CubicCapicityId { get; set; }

    public int? VehicleTypeId { get; set; }

    public int? AgeId { get; set; }

    public int? InsuranceCompanyId { get; set; }

    public decimal? PaCover { get; set; }

    public decimal? DriverCover { get; set; }

    public decimal? PassengersCover { get; set; }

    public decimal? PremimumAmount { get; set; }

    public decimal? PremimumGst { get; set; }

    public decimal? PayoutAmount { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? AgeRangeMin { get; set; }

    public int? AgeRangeMax { get; set; }

    public string? RtoIds { get; set; }

    public decimal? ActualPayoutAmount { get; set; }
}
