using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Core.Domain.Models;

namespace VICAInsurance.Services.ViewModels
{
    public class PolicyCashbackModel
    {
        public int PolicyCashbackId { get; set; }

        public int? PolicyCashbackRequestId { get; set; }

        public int? UserId { get; set; }

        public int? AgentCompanyId { get; set; }

        public int? TpRatesId { get; set; }

        public int? TpRequestId { get; set; }

        public int? OfflineQuotationId { get; set; }

        public decimal? PremimumAmount { get; set; }

        public decimal? CashbackAmount { get; set; }

        public string? Status { get; set; }

        public string? TransactionDetails { get; set; }

        public string? TransactionProof1 { get; set; }

        public string? TransactionProof2 { get; set; }

        public bool? IsPaid { get; set; }

        public string? UserName { get; set; }
    }

    public class PolicyCashbackRequestModel
    {
        public int PolicyCashbackRequestId { get; set; }

        public int? UserId { get; set; }

        public string? VehicleNo { get; set; }

        public string? PolicyUrlM { get; set; }

        public int? AgentCompanyId { get; set; }

        public string? Status { get; set; }
        public string? UserName { get; set; }
        public decimal? PremimumAmount { get; set; }

        public decimal? CashbackAmount { get; set; }

        public string? TransactionDetails { get; set; }

        public string? TransactionProof1 { get; set; }

        public string? TransactionProof2 { get; set; }
    }

    public class PolicyCashbackDomainModel:PolicyCashback
    {
        public string? FileNameProof1 { get; set; }
        public string? FileNameProof2 { get; set; }
    }
  }
