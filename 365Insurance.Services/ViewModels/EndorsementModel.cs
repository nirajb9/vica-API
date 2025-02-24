using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Core.Domain.Models;

namespace VICAInsurance.Services.ViewModels
{
    public class EndorsementModel : EndorsementPolicy
    {
        public string? UserName { get; set; }

    }
}
