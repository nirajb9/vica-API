using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using _365Insurance.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.Services
{
    public class CustomerLeadsService : ICustomerLeadsService
    {
        private readonly Insure247DbContext _context;
        public CustomerLeadsService(Insure247DbContext context) { 
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
                DateTime? sdate = model.startdate == null ? DateTime.Now : model.startdate;
                DateTime? edate = model.enddate == null ? DateTime.Now : model.enddate;
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
