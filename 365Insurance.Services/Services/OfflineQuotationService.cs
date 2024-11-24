﻿using Microsoft.EntityFrameworkCore;
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
    public class OfflineQuotationService : IOfflineQuotationService
    {
        private readonly _247IDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ICommonService _commonService;


        public OfflineQuotationService(_247IDbContext context, IConfiguration configuration, ICommonService commonService)
        {
            _context = context;
            _configuration = configuration;
            _commonService = commonService;
        }

        public string Save(OfflineQuotationRequest model)
        {
            try
            {
                _context.OfflineQuotationRequests.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return "fail";
            }

            return "success";
        }

        public string SaveOfflinePolicyBuyRequest(OfflinePolicyBuyRequest model)
        {
            try
            {
                _context.OfflinePolicyBuyRequests.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return "fail";
            }

            return "success";
        }

        public async Task<List<OfflineQuotationRequestModel>> GetOfflineQuotation(int userId)
        {
            List<OfflineQuotationRequestModel> result = new List<OfflineQuotationRequestModel>();
            try
            {
                result = await (from oqr in _context.OfflineQuotationRequests                       
                          join ur in _context.UserRegistrations on oqr.UserId equals ur.UserId
                          where oqr.UserId == userId && oqr.IsDeleted == false
                          select new OfflineQuotationRequestModel
                          {
                              AgentCompanyId = oqr.AgentCompanyId,
                              OfflineQuotationId = oqr.OfflineQuotationId,
                              Dacover = oqr.Dacover,
                              Idv = oqr.Idv,
                              Insurancecompanies = oqr.Insurancecompanies,
                              Pacover = oqr.Pacover,
                              Passangercover = oqr.Passangercover,
                              RcBUrlm = oqr.RcBUrlm,
                              RcFUrlm = oqr.RcFUrlm,
                              Status = oqr.Status,
                              UserName = ur.Username,
                              VehicleNo = oqr.VehicleNo,
                              UserId = oqr.UserId

                          }).OrderByDescending(s => s.OfflineQuotationId).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return  result;
        }

        public async Task<List<OfflineQuotationRequestModel>> GetOfflineQuotation()
        {
            List<OfflineQuotationRequestModel> result = new List<OfflineQuotationRequestModel>();
            try
            {
                result = await (from oqr in _context.OfflineQuotationRequests
                                join ur in _context.UserRegistrations on oqr.UserId equals ur.UserId
                                where oqr.IsDeleted == false
                                select new OfflineQuotationRequestModel
                                {
                                    AgentCompanyId = oqr.AgentCompanyId,
                                    OfflineQuotationId = oqr.OfflineQuotationId,
                                    Dacover = oqr.Dacover,
                                    Idv = oqr.Idv,
                                    Insurancecompanies = oqr.Insurancecompanies,
                                    Pacover = oqr.Pacover,
                                    Passangercover = oqr.Passangercover,
                                    RcBUrlm = oqr.RcBUrlm,
                                    RcFUrlm = oqr.RcFUrlm,
                                    Status = oqr.Status,
                                    UserName = ur.Username,
                                    VehicleNo = oqr.VehicleNo,
                                    UserId = oqr.UserId

                                }).OrderByDescending(s => s.OfflineQuotationId).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<List<OfflineQuotationRequestDetailsModel>> GetOfflineQuotationDetails(int OfflineQuotationId)
        {
            List<OfflineQuotationRequestDetailsModel> result = new List<OfflineQuotationRequestDetailsModel>();
            try
            {
                result = await (from oqrd in _context.OfflineQuotationRequestDetails                         
                          where oqrd.OfflineQuotationId == OfflineQuotationId && oqrd.IsDeleted == false
                          select new OfflineQuotationRequestDetailsModel
                          {
                              OfflineQuotationId = oqrd.OfflineQuotationId,
                              OfflineQuotationDetailsId = oqrd.OfflineQuotationDetailsId,
                              PayoutAmount = oqrd.PayoutAmount,
                              PremiumAmount = oqrd.PremiumAmount,
                              QuotationUrl = oqrd.QuotationUrl,
                              Status = oqrd.Status,
                              InsuranceCompanyName =oqrd.InsuranceCompanyName                             

                          }).OrderByDescending(s => s.OfflineQuotationId).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<string> SaveOfflineQuoteDetails(OfflineQuotationRequestDetailModel1 model)
        {
            try
            {
                string fileUrl = "";
               
                if(model.FileData != null)
                {
                    byte[] fileBytes = Convert.FromBase64String(model.FileData);
                    fileUrl = await _commonService.UploadToFtp(fileBytes, model.FileName, model.UserId);
                }
              
                OfflineQuotationRequestDetail offlineQuotationRequestDetail = new OfflineQuotationRequestDetail();
                offlineQuotationRequestDetail.OfflineQuotationId = model.OfflineQuotationId;
                offlineQuotationRequestDetail.OfflineQuotationDetailsId = model.OfflineQuotationDetailsId;
                offlineQuotationRequestDetail.QuotationUrl = fileUrl;
                offlineQuotationRequestDetail.AgentCompanyId = model.AgentCompanyId;
                offlineQuotationRequestDetail.CreatedBy = model.CreatedBy;
                offlineQuotationRequestDetail.CreatedDate = model.CreatedDate;
                offlineQuotationRequestDetail.ModifiedDate = model.ModifiedDate;
                offlineQuotationRequestDetail.ModifiedBy = model.ModifiedBy;
                offlineQuotationRequestDetail.InsuranceCompanyId = model.InsuranceCompanyId;
                offlineQuotationRequestDetail.InsuranceCompanyName = model.InsuranceCompanyName;
                offlineQuotationRequestDetail.Status = model.Status;
                offlineQuotationRequestDetail.PayoutAmount = model.PayoutAmount;
                offlineQuotationRequestDetail.PremiumAmount = model.PremiumAmount;
                offlineQuotationRequestDetail.UserId = model.UserId;
                offlineQuotationRequestDetail.IsDeleted = false;
                

                _context.OfflineQuotationRequestDetails.Add(offlineQuotationRequestDetail);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return "fail";
            }

            return "success";
        }



    }
}
