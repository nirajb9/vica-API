using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class MonthlyGridMa
{
    public int GridId { get; set; }

    public string? Month { get; set; }

    public int? StateId { get; set; }

    public string? FileLink { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
