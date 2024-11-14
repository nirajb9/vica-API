using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.ViewModels
{
    public class TPRequestQuotationDetailsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public long MobileNo { get; set; }
        public string? InsuranceCompany { get; set; }
        public string? VehicleNo { get; set; }
        public decimal PremimumAmount { get; set; }
        public decimal CashbackAmount { get; set; }
        public decimal PACover { get; set; }
        public decimal DACover { get; set; }
        public decimal PessangerCover { get; set; }

        public string? VehicleTypeName { get; set; }
        public string? StateName { get; set; }
        public string? RTO { get; set; }
        public string? Age { get; set; }
        public string? CCGCV { get; set; }
        public string? FuelType { get; set; }

       


        public string? RcFUrlm { get; set; }
        public string? RcBUrlm { get; set; }
        public string? AadharFUrlm { get; set; }
        public string? AadharBUrlm { get; set; }
        public string? PanFUrlm { get; set; }
        public string? PanBUrlm { get; set; }
        public string? DlFUrlm { get; set; }
        public string? DlBUrlm { get; set; }
        public string? OldPolicyUrlm { get; set; }
        public string? RcFUrlw { get; set; }
        public string? RcBUrlw { get; set; }
        public string? AadharFUrlw { get; set; }
        public string? AadharBUrlw { get; set; }
        public string? PanFUrlw { get; set; }
        public string? PanBUrlw { get; set; }
        public string? DlFUrlw { get; set; }
        public string? DlBUrlw { get; set; }
        public string? OldPolicyUrlw { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? PaymentLink { get; set; }
        public bool PaymentLinkAvailable { get; set; }

        public string? PaymentStatus { get; set; }
        public string? PaymentComments { get; set; }
        public DateTime? PaymentExpiryDate { get; set; }
        public string? PolicyType { get; set; }
        public string? UserName { get; set; }



    }

    public class TPRequestQuotationModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public long MobileNo { get; set; }
        public string? InsuranceCompany { get; set; }
        public string? VehicleNo { get; set; }
        public decimal PremimumAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? PaymentLink { get; set; }
        public string? PolicyType { get; set; }
        public bool PaymentLinkAvailable { get; set; }
        public string? UserName { get; set; }
    }
  }
