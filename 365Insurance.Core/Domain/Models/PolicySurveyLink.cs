using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class PolicySurveyLink
{
    public int SurveyLinkId { get; set; }

    public int? UserId { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? TpRatesId { get; set; }

    public int? TpRequestId { get; set; }

    public string? SurveyLinkUrl { get; set; }

    public DateTime? LinkExpireryDate { get; set; }

    public bool? IsSurveyCompleted { get; set; }

    public string? Comments { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
