using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class TpRatesMa
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

    public int? CubicCapicity { get; set; }

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
}
