using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class InsuranceCompanyTransaction
{
    public int InsuranceCompanyTrancId { get; set; }

    public int? InsuranceCompanyId { get; set; }

    public int? CubicCapicityId { get; set; }

    public int? AgeId { get; set; }

    public int? TppId { get; set; }

    public decimal? InsuranceAmount { get; set; }

    public decimal? CashBack { get; set; }

    public int? CashbackPercent { get; set; }

    public int? VehicleTypeId { get; set; }

    public int? AgentCodeId { get; set; }

    public int? StateId { get; set; }

    public int? RtoId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
