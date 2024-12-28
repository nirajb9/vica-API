using Microsoft.EntityFrameworkCore;
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
    public class EndorsementPolicyService : IEndorsementPolicyService
    {
        private readonly _247IDbContext _context;
        public EndorsementPolicyService(_247IDbContext context)
        {
            _context = context;
        }
        public Task<List<EndorsementPolicy>> GetEndorsementPolicy(int userid)
        {
            return _context.EndorsementPolicies.Where(s => s.UserId == userid && s.IsDeleted == false).ToListAsync(); 
        }
        public ResponseResult AddEndorsementPolicyAsync(EndorsementPolicy endorsementPolicy)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                _context.EndorsementPolicies.Add(endorsementPolicy);
                _context.SaveChanges();
                rr.Message = "sucess";
                rr.StatusCode = 200;
            }
            catch(Exception ex)
            {
                rr.Message = "error";
                rr.StatusCode = 500;
            }
            return rr;
        }
        public async Task<bool> DeleteEndorsementPolicyAsync(int id)
       {
            try
            {
                var ep = _context.EndorsementPolicies.Where(s => s.EndorsementId == id).FirstOrDefault();
                if(ep != null)
                {
                    ep.IsDeleted = true;
                    _context.Update(ep);
                    _context.SaveChanges();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
       }
    }
}
