﻿using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class UserRegistration
{
    public int UserId { get; set; }

    public int? AgentCompanyId { get; set; }

    public int? SubUserId { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? MobileNo { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? Isapproved { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }
}
