using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.ViewModels;

namespace VICAInsurance.Services.IServices
{
    public interface IOfflineQuotationService
    {
        string Save(OfflineQuotationRequest model);
        string SaveOfflinePolicyBuyRequest(OfflinePolicyBuyRequest model);
        Task<List<OfflineQuotationRequestModel>> GetOfflineQuotation(int userId);
        Task<List<OfflineQuotationRequestModel>> GetOfflineQuotation();
        Task<List<OfflineQuotationRequestDetailsModel>> GetOfflineQuotationDetails(int OfflineQuotationId);
        Task<ResponseResult> SaveOfflineQuoteDetails(OfflineQuotationRequestDetailModel1 model);
        Task<List<OfflinePolicyBuyRequest>> GetOfflinePolicyBuyRquest(int userid);
        ResponseResult UpdateOfflinePolicyBuyRequest(OfflinePolicyBuyRequest model);
        Task<List<OfflineQuotationRequestDetailsModel>> GetOfflinePolicyPaymentLink(int userid);
        ResponseResult DeleteOfflineQuoteDetails(int id);
    }
}
