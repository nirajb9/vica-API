using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class PolicyTypeMapping
{
    public int PolicyTypeMapping1 { get; set; }

    public int? UserId { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? PolicyTypeId { get; set; }

    public int? IsDeleted { get; set; }
}
