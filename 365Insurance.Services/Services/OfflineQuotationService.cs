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
                                join x in _context.OfflineQuotationRequests on oqrd.OfflineQuotationId equals x.OfflineQuotationId
                                where oqrd.OfflineQuotationId == OfflineQuotationId && oqrd.IsDeleted == false
                          select new OfflineQuotationRequestDetailsModel
                          {
                              OfflineQuotationId = oqrd.OfflineQuotationId,
                              OfflineQuotationDetailsId = oqrd.OfflineQuotationDetailsId,
                              PayoutAmount = oqrd.PayoutAmount,
                              PremiumAmount = oqrd.PremiumAmount,
                              QuotationUrl = oqrd.QuotationUrl,
                              Status = oqrd.Status,
                              InsuranceCompanyName =oqrd.InsuranceCompanyName,
                              VehicleNo = x.VehicleNo

                          }).OrderByDescending(s => s.OfflineQuotationId).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<ResponseResult> SaveOfflineQuoteDetails(OfflineQuotationRequestDetailModel1 model)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                string fileUrl = "";
                
                if (model.FileData != null)
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

        public async  Task<List<OfflinePolicyBuyRequest>> GetOfflinePolicyBuyRquest(int userid)
        {
            List<OfflinePolicyBuyRequest> result = new List<OfflinePolicyBuyRequest>();
            try
            {
                if(userid ==0)
                {
                    result = await _context.OfflinePolicyBuyRequests.Where(s => s.IsDeleted == false).OrderByDescending(s=> s.OfflinePolicyBuyRequestId).ToListAsync();
                }
                else
                {
                    result = await _context.OfflinePolicyBuyRequests.Where(s => s.UserId == userid && s.IsDeleted == false).OrderByDescending(s => s.OfflinePolicyBuyRequestId).ToListAsync();
                }
                
            }
            catch(Exception ex)
            {

            }

            return result;

        }

        public ResponseResult UpdateOfflinePolicyBuyRequest(OfflinePolicyBuyRequest model)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                if(model.OfflinePolicyBuyRequestId>0)
                {
                    var objUpdate = _context.OfflinePolicyBuyRequests.Where(s => s.OfflinePolicyBuyRequestId == model.OfflinePolicyBuyRequestId).FirstOrDefault();
                    if(objUpdate != null)
                    {
                        objUpdate.PaymentLink = model.PaymentLink;
                        objUpdate.ModifiedDate = DateTime.Now;
                        objUpdate.IsDeleted = model.IsDeleted;
                        objUpdate.Remark = model.Remark;
                        _context.OfflinePolicyBuyRequests.Update(objUpdate);
                        _context.SaveChanges();
                        rr.Message = "success";
                        rr.StatusCode = 200;
                    }
                }              
            }
            catch (Exception ex)
            {
                rr.Message = "error";
                rr.StatusCode = 400;
                return rr;
            }
           
            return rr;
        }

        public async Task<List<OfflineQuotationRequestDetailsModel>> GetOfflinePolicyPaymentLink(int userid)
        {
            List<OfflineQuotationRequestDetailsModel> result = new List<OfflineQuotationRequestDetailsModel>();
            try
            {
                result = await (from oqrd in _context.OfflineQuotationRequestDetails
                                join opb in _context.OfflinePolicyBuyRequests on oqrd.OfflineQuotationDetailsId equals opb.OfflineQuotationId
                                where oqrd.UserId == userid && oqrd.IsDeleted == false && opb.IsDeleted == false
                                select new OfflineQuotationRequestDetailsModel
                                {
                                    OfflineQuotationId = oqrd.OfflineQuotationId,
                                    OfflineQuotationDetailsId = oqrd.OfflineQuotationDetailsId,
                                    PayoutAmount = oqrd.PayoutAmount,
                                    PremiumAmount = oqrd.PremiumAmount,
                                    QuotationUrl = oqrd.QuotationUrl,
                                    Status = oqrd.Status,
                                    InsuranceCompanyName = oqrd.InsuranceCompanyName,
                                    PaymentLink = opb.PaymentLink,
                                    Remark = opb.Remark,
                                    PaymentStatus = opb.Status,
                                    OfflinePolicyBuyRequestId = opb.OfflinePolicyBuyRequestId,
                                    VehicleNo = opb.VehicleNo

                                }).OrderByDescending(s => s.OfflinePolicyBuyRequestId).ToListAsync();

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public ResponseResult DeleteOfflineQuoteDetails(int id)
        {
            ResponseResult rr =  new ResponseResult();
            try
            {
                if (id > 0)
                {
                    var objUpdate = _context.OfflineQuotationRequestDetails.Where(s => s.OfflineQuotationDetailsId == id).FirstOrDefault();
                    if (objUpdate != null)
                    {                     
                        objUpdate.ModifiedDate = DateTime.Now;
                        objUpdate.IsDeleted = true;                   
                        _context.OfflineQuotationRequestDetails.Update(objUpdate);
                        _context.SaveChanges();
                        rr.Message = "success";
                        rr.StatusCode = 200;
                    }
                }
            }
            catch (Exception ex)
            {
                rr.Message = "error";
                rr.StatusCode = 400;
                return  rr;
            }
           
            return rr;
        }
    }
}
