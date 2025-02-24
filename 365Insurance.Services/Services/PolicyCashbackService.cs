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
        private readonly ICommonService _commonService;

        public PolicyCashbackService(_247IDbContext context, IConfiguration configuration, ICommonService commonService)
        {
            _context = context;
            _configuration = configuration;
            _commonService = commonService;
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

        public async Task<List<PolicyCashbackRequestModel>> GetPolicyCashbackRequest()
        {
            List<PolicyCashbackRequestModel> result = new List<PolicyCashbackRequestModel>();
            try
            {
                result = await (from pc in _context.PolicyCashbackRequests
                                join ur in _context.UserRegistrations on pc.UserId equals ur.UserId
                                where pc.IsDeleted == false
                                select new PolicyCashbackRequestModel
                                {
                                    AgentCompanyId = pc.AgentCompanyId,
                                    PolicyCashbackRequestId = pc.PolicyCashbackRequestId,
                                    PolicyUrlM = pc.PolicyUrlM,
                                    VehicleNo = pc.VehicleNo,
                                    UserName = ur.Username,
                                    Status = pc.Status,
                                    UserId = ur.UserId

                                }).OrderByDescending(s => s.PolicyCashbackRequestId).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public async Task<ResponseResult> SaveCashback(PolicyCashbackDomainModel model)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                string Proof1 = ""; string Proof2 = "";
                if (model.TransactionProof1 != null)
                {
                    byte[] fileBytes = Convert.FromBase64String(model.TransactionProof1);
                    Proof1 = await _commonService.UploadToFtp(fileBytes, model.FileNameProof1, model.UserId);
                }
                if (model.TransactionProof2 != null)
                {
                    byte[] fileBytes = Convert.FromBase64String(model.TransactionProof2);
                    Proof2 = await _commonService.UploadToFtp(fileBytes, model.FileNameProof2, model.UserId);
                }
                model.TransactionProof1 = Proof1;
                model.TransactionProof2 = Proof2;
                _context.PolicyCashbacks.Add(model);
                _context.SaveChanges();
                rr.Message = "success";
                rr.StatusCode = 200;
            }
            catch (Exception ex)
            {
                rr.Message = "error";
                rr.StatusCode = 400;
                return rr;
            }
            return rr;
        }

        public async Task<List<PolicyCashbackRequestModel>> GetPolicyCashbackDetails(int id)
        {
            List<PolicyCashbackRequestModel> result = new List<PolicyCashbackRequestModel>();
            try
            {
                result = await (from pc in _context.PolicyCashbackRequests
                                join pcn in _context.PolicyCashbacks on pc.PolicyCashbackRequestId equals pcn.PolicyCashbackRequestId
                                join ur in _context.UserRegistrations on pc.UserId equals ur.UserId
                                where pc.IsDeleted == false && pc.PolicyCashbackRequestId == id
                                select new PolicyCashbackRequestModel
                                {
                                    AgentCompanyId = pc.AgentCompanyId,
                                    PolicyCashbackRequestId = pc.PolicyCashbackRequestId,
                                    PolicyUrlM = pc.PolicyUrlM,
                                    VehicleNo = pc.VehicleNo,
                                    UserName = ur.Username,
                                    Status = pcn.Status,
                                    UserId = ur.UserId,
                                    CashbackAmount = pcn.CashbackAmount,
                                    TransactionDetails = pcn.TransactionDetails,
                                    PremimumAmount = pcn.PremimumAmount,
                                    TransactionProof1 = pcn.TransactionProof1,
                                    TransactionProof2 = pcn.TransactionProof2

                                }).OrderByDescending(s => s.PolicyCashbackRequestId).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
