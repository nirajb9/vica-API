﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Services.ViewModels;

namespace VICAInsurance.Services.IServices
{
    public interface ILoginService
    {
        Task<UserDetails?> LoginUser(LoginModel loginDto, bool isAdmin);
    }
}
