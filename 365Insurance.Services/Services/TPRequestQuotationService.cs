using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.Services
{
    public class TPRequestQuotationService : ITPRequestQuotationService
    {
        private readonly _247IDbContext _context;
        private readonly IConfiguration _configuration;


        public TPRequestQuotationService(_247IDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public string SaveTPQuotation(TpRequestQuotation model)
        {
            try
            {
                _context.TpRequestQuotations.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return "fail";
            }

            return "success";
        }

        public List<TPRequestQuotationModel> GetRequestedQuotation(int userId)
        {
            List<TPRequestQuotationModel> result = new List<TPRequestQuotationModel>();
            try
            {
                result = (from trq in _context.TpRequestQuotations
                          join tpr in _context.TpRatesMas on trq.TpId equals tpr.TpRatesId
                          join viv in _context.VehicleInsuranceCompanies on tpr.InsuranceCompanyId equals viv.InsuranceCompanyId
                          join ur in _context.UserRegistrations on tpr.UserId equals ur.UserId
                          where trq.UserId == userId
                          select new TPRequestQuotationModel
                          {
                              Id = trq.TpRequestId,
                              Name = trq.Name,
                              MobileNo = Convert.ToInt64(trq.MobileNo),
                              PremimumAmount = trq.PremimumAmount ?? 0,
                              VehicleNo = trq.VehicleNo,
                              CreatedDate = trq.CreatedDate,
                              PolicyType = "TP",
                              InsuranceCompany = viv.InsuranceCompanyName,
                              

                          }).OrderByDescending(s => s.Id).ToList();

                foreach (var x in result)
                {
                    var paymentLink = _context.PaymentLinks.Where(s => s.TpRequestId == x.Id).FirstOrDefault();
                    if (paymentLink != null)
                    {
                        x.PaymentLink = paymentLink.PaymentLink1;
                        x.PaymentLinkAvailable = true;
                    }
                    else
                    {
                        x.PaymentLink = "Not Available";
                        x.PaymentLinkAvailable = false;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<TPRequestQuotationModel> GetRequestedQuotation()
        {
            List<TPRequestQuotationModel> result = new List<TPRequestQuotationModel>();
            try
            {
                result = (from trq in _context.TpRequestQuotations
                          join tpr in _context.TpRatesMas on trq.TpId equals tpr.TpRatesId
                          join viv in _context.VehicleInsuranceCompanies on tpr.InsuranceCompanyId equals viv.InsuranceCompanyId
                          join ur in _context.UserRegistrations on trq.UserId equals ur.UserId
                         
                          select new TPRequestQuotationModel
                          {
                              Id = trq.TpRequestId,
                              Name = trq.Name,
                              MobileNo = Convert.ToInt64(trq.MobileNo),
                              PremimumAmount = trq.PremimumAmount ?? 0,
                              VehicleNo = trq.VehicleNo,
                              CreatedDate = trq.CreatedDate,
                              PolicyType = "TP",
                              InsuranceCompany = viv.InsuranceCompanyName,
                              UserName = ur.Username

                          }).OrderByDescending(s => s.Id).ToList();

                foreach (var x in result)
                {
                    var paymentLink = _context.PaymentLinks.Where(s => s.TpRequestId == x.Id).FirstOrDefault();
                    if (paymentLink != null)
                    {
                        x.PaymentLink = paymentLink.PaymentLink1;
                        x.PaymentLinkAvailable = true;
                    }
                    else
                    {
                        x.PaymentLink = "Not Available";
                        x.PaymentLinkAvailable = false;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public TPRequestQuotationDetailsModel? GetRequestedQuotationById(int id, int userId)
        {
            TPRequestQuotationDetailsModel? result = null;
            try
            {
                result = (from trq in _context.TpRequestQuotations
                          join tpr in _context.TpRatesMas on trq.TpId equals tpr.TpRatesId
                          join tprm in _context.RtoTpratesMappings on tpr.TpRatesId equals tprm.TpRatesId
                          join viv in _context.VehicleInsuranceCompanies on tpr.InsuranceCompanyId equals viv.InsuranceCompanyId
                          join rm in _context.RtoMas on tprm.RtoId equals rm.RtoId
                          join sm in _context.StateMas on tpr.StateId equals sm.StateId
                          join vft in _context.VehicleFueltypes on tpr.FueltypeId equals vft.FueltypeId
                          join va in _context.VehicleAges on tpr.AgeId equals va.AgeId
                          join vcc in _context.VehicleCubicCapicities on tpr.CubicCapicityId equals vcc.CubicCapicityId
                          join vt in _context.VehicleTypes on tpr.VehicleTypeId equals vt.VehicleTypeId
                          where trq.TpRequestId == id && trq.UserId == userId
                          select new TPRequestQuotationDetailsModel
                          {
                              Id = trq.TpRequestId,
                              Name = trq.Name,
                              MobileNo = Convert.ToInt64(trq.MobileNo),
                              PremimumAmount = trq.PremimumAmount ?? 0,
                              CashbackAmount = trq.CashbackAmount ?? 0,
                              PACover = trq.PaCoverAmount ?? 0,
                              DACover = trq.DriverCoverAmount ?? 0,
                              PessangerCover = trq.PessangerCoverAmount ?? 0,

                              RcFUrlm = trq.RcFUrlm,
                              RcBUrlm = trq.RcBUrlm,
                              AadharFUrlm = trq.AadharFUrlm,
                              AadharBUrlm = trq.AadharBUrlm,
                              PanFUrlm = trq.PanFUrlm,
                              PanBUrlm = trq.PanBUrlm,
                              DlFUrlm = trq.DlFUrlm,
                              DlBUrlm = trq.DlBUrlm,
                              OldPolicyUrlm = trq.OldPolicyUrlm,

                              RcFUrlw = trq.RcFUrlw,
                              RcBUrlw = trq.RcBUrlw,
                              AadharFUrlw = trq.AadharFUrlw,
                              AadharBUrlw = trq.AadharBUrlw,
                              PanFUrlw = trq.PanFUrlw,
                              PanBUrlw = trq.PanBUrlw,
                              DlFUrlw = trq.DlFUrlw,
                              DlBUrlw = trq.DlBUrlw,
                              OldPolicyUrlw = trq.OldPolicyUrlw,
                              InsuranceCompany = viv.InsuranceCompanyName,
                              VehicleNo = trq.VehicleNo,
                              CreatedDate = trq.CreatedDate,
                              VehicleTypeName = vt.VehicleTypeName,
                              StateName = sm.StateName + " (" + sm.StateCode + ")",
                              RTO = rm.RtoCode,
                              Age = va.Age,
                              CCGCV = vcc.CubicCapicityName,
                              FuelType = vft.FueltypeName,
                              PolicyType = "TP",

                          }).FirstOrDefault();

                if (result != null)
                {
                    var paymentLink = _context.PaymentLinks.Where(s => s.TpRequestId == result.Id).FirstOrDefault();
                    if (paymentLink != null)
                    {
                        result.PaymentLink = paymentLink.PaymentLink1;
                        result.PaymentComments = paymentLink.Comments;
                        result.PaymentStatus = paymentLink.PaymentStatus;
                        result.PaymentExpiryDate = paymentLink.ExpiredDate;
                        result.PaymentLinkAvailable = true;
                    }
                    else
                    {
                        result.PaymentLink = "Not Available";
                        result.PaymentComments = "";
                        result.PaymentStatus = "";
                        result.PaymentExpiryDate = null;
                        result.PaymentLinkAvailable = false;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public TPRequestQuotationDetailsModel? GetRequestedQuotationById(int id)
        {
            TPRequestQuotationDetailsModel? result = null;
            try
            {
                result = (from trq in _context.TpRequestQuotations
                          join tpr in _context.TpRatesMas on trq.TpId equals tpr.TpRatesId
                          join tprm in _context.RtoTpratesMappings on tpr.TpRatesId equals tprm.TpRatesId
                          join viv in _context.VehicleInsuranceCompanies on tpr.InsuranceCompanyId equals viv.InsuranceCompanyId
                          join rm in _context.RtoMas on tprm.RtoId equals rm.RtoId
                          join sm in _context.StateMas on tpr.StateId equals sm.StateId
                          join vft in _context.VehicleFueltypes on tpr.FueltypeId equals vft.FueltypeId
                          join va in _context.VehicleAges on tpr.AgeId equals va.AgeId
                          join vcc in _context.VehicleCubicCapicities on tpr.CubicCapicityId equals vcc.CubicCapicityId
                          join vt in _context.VehicleTypes on tpr.VehicleTypeId equals vt.VehicleTypeId
                          join ur in _context.UserRegistrations on tpr.UserId equals ur.UserId
                          where trq.TpRequestId == id
                          select new TPRequestQuotationDetailsModel
                          {
                              Id = trq.TpRequestId,
                              Name = trq.Name,
                              MobileNo = Convert.ToInt64(trq.MobileNo),
                              PremimumAmount = trq.PremimumAmount ?? 0,
                              CashbackAmount = trq.CashbackAmount ?? 0,
                              PACover = trq.PaCoverAmount ?? 0,
                              DACover = trq.DriverCoverAmount ?? 0,
                              PessangerCover = trq.PessangerCoverAmount ?? 0,

                              RcFUrlm = trq.RcFUrlm,
                              RcBUrlm = trq.RcBUrlm,
                              AadharFUrlm = trq.AadharFUrlm,
                              AadharBUrlm = trq.AadharBUrlm,
                              PanFUrlm = trq.PanFUrlm,
                              PanBUrlm = trq.PanBUrlm,
                              DlFUrlm = trq.DlFUrlm,
                              DlBUrlm = trq.DlBUrlm,
                              OldPolicyUrlm = trq.OldPolicyUrlm,

                              RcFUrlw = trq.RcFUrlw,
                              RcBUrlw = trq.RcBUrlw,
                              AadharFUrlw = trq.AadharFUrlw,
                              AadharBUrlw = trq.AadharBUrlw,
                              PanFUrlw = trq.PanFUrlw,
                              PanBUrlw = trq.PanBUrlw,
                              DlFUrlw = trq.DlFUrlw,
                              DlBUrlw = trq.DlBUrlw,
                              OldPolicyUrlw = trq.OldPolicyUrlw,
                              InsuranceCompany = viv.InsuranceCompanyName,
                              VehicleNo = trq.VehicleNo,
                              CreatedDate = trq.CreatedDate,
                              VehicleTypeName = vt.VehicleTypeName,
                              StateName = sm.StateName + " (" + sm.StateCode + ")",
                              RTO = rm.RtoCode,
                              Age = va.Age,
                              CCGCV = vcc.CubicCapicityName,
                              FuelType = vft.FueltypeName,
                              PolicyType = "TP",
                              UserName = ur.Username

                          }).FirstOrDefault();

                if (result != null)
                {
                    var paymentLink = _context.PaymentLinks.Where(s => s.TpRequestId == result.Id).FirstOrDefault();
                    if (paymentLink != null)
                    {
                        result.PaymentLink = paymentLink.PaymentLink1;
                        result.PaymentComments = paymentLink.Comments;
                        result.PaymentStatus = paymentLink.PaymentStatus;
                        result.PaymentExpiryDate = paymentLink.ExpiredDate;
                        result.PaymentLinkAvailable = true;
                    }
                    else
                    {
                        result.PaymentLink = "Not Available";
                        result.PaymentComments = "";
                        result.PaymentStatus = "";
                        result.PaymentExpiryDate = null;
                        result.PaymentLinkAvailable = false;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public string AddPaymentLink(PaymentLink pl)
        {
            string msg = "sucess";
            try
            {
                var paymentlnk = GetPaymentLink(pl.TpRequestId);
                if (paymentlnk != null)
                {
                    UpdatePaymentLink(pl);
                }
                else
                {
                    _context.PaymentLinks.Add(pl);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                msg = "error";
            }
            return msg;
        }
        public string UpdatePaymentLink(PaymentLink pl)
        {
            string msg = "sucess";
            try
            {
                var paymentlnk = GetPaymentLink(pl.TpRequestId);
                if (paymentlnk != null)
                {
                    paymentlnk.PaymentLink1 = pl.PaymentLink1;
                    paymentlnk.PaymentStatus = pl.PaymentStatus;
                    paymentlnk.Comments = paymentlnk.Comments + "\n" + pl.Comments;
                    paymentlnk.ExpiredDate = pl.ExpiredDate;
                    _context.PaymentLinks.Update(paymentlnk);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = "error";
            }
            return msg;
        }

        public PaymentLink? GetPaymentLink(int? TPRequestId)
        {
            var paymentLink = _context.PaymentLinks.Where(s => s.TpRequestId == TPRequestId).OrderByDescending(s => s.PaymentLinkId).FirstOrDefault();
            return paymentLink;
        }
    }
}
