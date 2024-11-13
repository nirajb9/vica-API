using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.ViewModels
{
    public class RequestQuotationModel
    {
        public decimal? IdvValue { get; set; }

        public string? Name { get; set; }

        public string? MobileNo { get; set; }

        public string? Email { get; set; }

        public string? Comments { get; set; }
        public UploadModel? RcFront { get; set; }
        public UploadModel? RcBack { get; set; }
        public UploadModel? PreviousInsurance { get; set; }

    }
}
