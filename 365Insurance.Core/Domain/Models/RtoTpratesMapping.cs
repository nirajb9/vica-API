using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class RtoTpratesMapping
{
    public int RtoTpratesId { get; set; }

    public int? TpRatesId { get; set; }

    public int? StateId { get; set; }

    public int? RtoId { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? UserId { get; set; }

    public int? CompanyId { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
