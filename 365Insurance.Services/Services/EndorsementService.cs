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
    public class EndorsementService : IEndorsementService
    {
        private readonly _247IDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICommonService _commonService;

        public EndorsementService(_247IDbContext context, IConfiguration configuration, ICommonService commonService)
        {
            _context = context;
            _configuration = configuration;
            _commonService = commonService;
        }

        public async Task<List<EndorsementModel>> GetEndorsementPolicy()
        {
            List<EndorsementModel> result = new List<EndorsementModel>();
            try
            {
                result = await (from pc in _context.EndorsementPolicies
                                join ur in _context.UserRegistrations on pc.UserId equals ur.UserId
                                where pc.IsDeleted == false
                                select new EndorsementModel
                                {
                                    Comments = pc.Comments,
                                    EndorsementType = pc.EndorsementType,
                                    Kyc1 = pc.Kyc1,
                                    Kyc2 = pc.Kyc2,
                                    Kyc3 = pc.Kyc3,
                                    Kyc4 = pc.Kyc4,
                                    Policycopy = pc.Policycopy,
                                    PolicycopyFinal = pc.PolicycopyFinal,
                                    EndorsementId = pc.EndorsementId,
                                    UserName = ur.Username,
                                    Status = pc.Status,                                    
                                    UserId = pc.UserId

                                }).OrderByDescending(s => s.EndorsementId).ToListAsync();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<EndorsementPolicy?> UpdateEndrosmentPolicy(EndorsementPolicy model)
        {
            var obj = _context.EndorsementPolicies.Where(s => s.EndorsementId == model.EndorsementId).FirstOrDefault();
            if(obj != null)
            {
                string PolicyCopyUrl = "";
                if (model.PolicycopyFinal != null)
                {
                    byte[] fileBytes = Convert.FromBase64String(model.PolicycopyFinal);
                    PolicyCopyUrl = await _commonService.UploadToFtp(fileBytes, model.EndorsementType, model.UserId);
                    obj.PolicycopyFinal = PolicyCopyUrl;
                }
                //obj.PolicycopyFinal = string.IsNullOrEmpty(model.PolicycopyFinal) ? obj.PolicycopyFinal : model.PolicycopyFinal;
                obj.Comments = string.IsNullOrEmpty(model.Comments) ? obj.Comments : model.Comments; 
                obj.Status = string.IsNullOrEmpty(model.Status) ? obj.Status : model.Status; 
                obj.ModifiedDate = DateTime.Now;
                _context.Update(obj);
                _context.SaveChanges();
            }
            return obj;
        }
    }
}
