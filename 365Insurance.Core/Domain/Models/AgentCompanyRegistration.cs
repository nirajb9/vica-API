using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class AgentCompanyRegistration
{
    public int AgentCompanyId { get; set; }

    public string? AgentCompanyName { get; set; }

    public string? AgentCompanyLogoUrl { get; set; }

    public string? Email { get; set; }

    public bool? IsDeleted { get; set; }
}
