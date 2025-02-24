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
    public class PolicyCopyService : IPolicyCopyService
    {
        private readonly _247IDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICommonService _commonService;

        public PolicyCopyService(_247IDbContext context, IConfiguration configuration, ICommonService commonService)
        {
            _context = context;
            _configuration = configuration;
            _commonService = commonService;
        }

        public async Task<List<PolicyCopyModel>> GetPolicyCopy()
        {
            List<PolicyCopyModel> result = new List<PolicyCopyModel>();
            try
            {
                result = await (from pc in _context.PolicyCopies
                                join ur in _context.UserRegistrations on pc.UserId equals ur.UserId
                                where pc.IsDeleted == false
                                select new PolicyCopyModel
                                {                                
                                    VehicleNo = pc.VehicleNo,
                                    UserName = ur.Username,
                                    Status = pc.Status,
                                    PolicyCopyId = pc.PolicyCopyId,
                                    PolicyCopyUrl = pc.PolicyCopyUrl,
                                    UserId = pc.UserId

                                }).OrderByDescending(s => s.PolicyCopyId).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<ResponseResult> SavePolicyCopy(PolicyCopyModel model)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                string PolicyCopyUrl = ""; 
                if (model.PolicyCopyUrl != null)
                {
                    byte[] fileBytes = Convert.FromBase64String(model.PolicyCopyUrl);
                    PolicyCopyUrl = await _commonService.UploadToFtp(fileBytes, model.PolicyCopyFileName, model.UserId);
                }

                PolicyCopy pc = new PolicyCopy();
                pc.PolicyCopyId = 0;
                pc.PolicyCopyUrl = PolicyCopyUrl;
                pc.CreatedBy = model.CreatedBy;
                pc.CreatedDate = DateTime.Now;
                pc.ModifiedDate = DateTime.Now;
                pc.ModifiedBy = model.ModifiedBy;
                pc.Status = model.Status;
                pc.AgentCompanyId = model.AgentCompanyId;
                pc.IsDeleted = false;
                pc.TpRequestId = model.TpRequestId;
                pc.UserId = model.UserId;
                pc.VehicleNo = model.VehicleNo;               
                _context.PolicyCopies.Add(pc);
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
    }
}
