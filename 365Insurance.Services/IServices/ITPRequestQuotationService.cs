using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.IServices
{
    public interface ITPRequestQuotationService
    {
        string SaveTPQuotation(TpRequestQuotation model);
        List<TPRequestQuotationModel> GetRequestedQuotation(int userId);
        TPRequestQuotationDetailsModel? GetRequestedQuotationById(int id, int userId);
        string AddPaymentLink(PaymentLink pl);

        string UpdatePaymentLink(PaymentLink pl);
        PaymentLink? GetPaymentLink(int? TPRequestId);
    }
}
