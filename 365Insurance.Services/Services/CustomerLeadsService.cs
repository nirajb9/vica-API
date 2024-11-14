using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.Services
{
    public class CustomerLeadsService : ICustomerLeadsService
    {
        private readonly _247IDbContext _context;
        public CustomerLeadsService(_247IDbContext context) { 
            _context = context;
        
        }

        public string AddLeads(CustomerLead model)
        {
            string msg = "";
            try
            {
                _context.CustomerLeads.Add(model);
                _context.SaveChanges();
                msg = "sucess";
            }
            catch (Exception ex)
            {
                msg = "error";
            }
            return msg;
        }

        public async Task<List<CustomerLead>?> GetCustomerLead(CustomerLeadSearch model)
        {
            List<CustomerLead>? result = null;
            try
            {
                DateTime? sdate = model.startdate == null ? DateTime.Now.AddDays(-10) : model.startdate.Value;
                DateTime? edate = model.enddate == null ? DateTime.Now.AddDays(1) : model.enddate.Value;
                result = await _context.CustomerLeads.Where(s => s.UserId == model.userid && s.CreatedDate >= sdate.Value.Date.AddDays(-1) && s.CreatedDate <= edate.Value.Date.AddDays(1) && s.IsDeleted == false).ToListAsync();

            }
            catch(Exception ex)
            {
                return result;
            }

            return result;
        }
    }
}
