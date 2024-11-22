using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.ViewModels;

namespace VICAInsurance.Services.Services
{
    public class PolicyCashbackService : IPolicyCashbackService
    {
        private readonly _247IDbContext _context;
        private readonly IConfiguration _configuration;

        public PolicyCashbackService(_247IDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public string Save(PolicyCashbackRequest model)
        {       
            try
            {
                _context.PolicyCashbackRequests.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return "fail";
            }

            return "success";
        }

        public async Task<List<PolicyCashbackRequestModel>> GetPolicyCashbackRequest(int userId)
        {
            List<PolicyCashbackRequestModel> result = new List<PolicyCashbackRequestModel>();
            try
            {
                result = await (from pc in _context.PolicyCashbackRequests
                                join ur in _context.UserRegistrations on pc.UserId equals ur.UserId
                                where pc.UserId == userId && pc.IsDeleted == false
                                select new PolicyCashbackRequestModel
                                {
                                    AgentCompanyId = pc.AgentCompanyId,
                                    PolicyCashbackRequestId = pc.PolicyCashbackRequestId,
                                    PolicyUrlM = pc.PolicyUrlM,
                                    VehicleNo = pc.VehicleNo,
                                    UserName = ur.Username,
                                    Status = pc.Status,
                                    
                                }).OrderByDescending(s => s.PolicyCashbackRequestId).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<PolicyCashbackModel?> GetPolicyCashback(int userId, int id)
        {
            PolicyCashbackModel? result = new PolicyCashbackModel();
            try
            {
                result = await (from pc in _context.PolicyCashbacks
                                join ur in _context.UserRegistrations on pc.UserId equals ur.UserId
                                where pc.UserId == userId && pc.IsDeleted == false && pc.PolicyCashbackRequestId == id
                                select new PolicyCashbackModel
                                {
                                    AgentCompanyId = pc.AgentCompanyId,
                                    OfflineQuotationId = pc.OfflineQuotationId,
                                    CashbackAmount = pc.CashbackAmount,
                                    PolicyCashbackId = pc.PolicyCashbackId,
                                    PremimumAmount = pc.PremimumAmount,
                                    TransactionProof1 = pc.TransactionProof1,
                                    TransactionProof2 = pc.TransactionProof2,
                                    TransactionDetails = pc.TransactionDetails,
                                    Status = pc.Status,
                                    IsPaid = pc.IsPaid
                                }).FirstOrDefaultAsync();  

            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
