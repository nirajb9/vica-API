using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.IServices
{
    public interface ICustomerLeadsService
    {
        string AddLeads(CustomerLead model);
        Task<List<CustomerLead>?> GetCustomerLead(CustomerLeadSearch model);
    }
}
