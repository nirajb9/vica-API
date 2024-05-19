using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class StateMa
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public string? StateCode { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
