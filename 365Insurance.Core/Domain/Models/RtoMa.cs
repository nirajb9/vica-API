﻿using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class RtoMa
{
    public int RtoId { get; set; }

    public int StateId { get; set; }

    public string? RtoCode { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
