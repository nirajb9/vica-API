using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VICAInsurance.Services.ViewModels
{
    internal class CommonModel
    {
    }

    public class ResponseResult
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public dynamic? ModelValue { get; set; }
    }
}
