using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class CompanySlider
{
    public int TopSliderId { get; set; }

    public int? UserId { get; set; }

    public int? AgentCompanyId { get; set; }

    public string? Slider1 { get; set; }

    public string? Slider2 { get; set; }

    public string? Slider3 { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
