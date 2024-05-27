using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class PolicyType
{
    public int PolicyTypeId { get; set; }

    public string? PolicyType1 { get; set; }

    public bool? IsDeleted { get; set; }
}
