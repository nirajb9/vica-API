using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.Services;
using VICAInsurance.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Net.WebSockets;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestQuotationController : ControllerBase
    {
        private readonly ICommonService _commonService;
        private readonly ITPRequestQuotationService _tpRequestQuotationService;

        public RequestQuotationController(ICommonService commonService, ITPRequestQuotationService tpRequestQuotationService)
        {
            _commonService = commonService;
            _tpRequestQuotationService = tpRequestQuotationService;
        }
        [HttpPost("SaveFPQuotation")]
        public IActionResult SaveFPQuotation([FromBody] RequestQuotationModel model)
        {
            var data = "";
            try
            {
                string filecontent = model.PreviousInsurance.Content.Replace("data:image/png;base64,", "");
                var file = Convert.FromBase64String(filecontent);
                var folderName = "FPQuotation"; //Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = "test1"; //ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    // var dbPath = Path.Combine(folderName, fileName);
                    // using (var stream = new FileStream(fullPath, FileMode.Create))
                    //using (var memoryStream = new MemoryStream(file))
                    //{
                    //    file.CopyTo(memoryStream);
                    //}
                    using (var fileStream = System.IO.File.Create(fullPath))
                    {
                         fileStream.Write(file);
                    }
                    return Ok("");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            return Ok(data);
        }

        [HttpPost("SaveTPRequestQuotation")]
        public IActionResult SaveTPRequestQuotation([FromBody] TpRequestQuotation model)
        {
            var data = "";
            try
            {
                data = _tpRequestQuotationService.SaveTPQuotation(model);
                
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            return Ok(data);
        
        }

        [HttpGet("GetTPRequestQuotation/{userid}")]
        public List<TPRequestQuotationModel> GetTPRequestQuotation(int userId)
        {
            var data = _tpRequestQuotationService.GetRequestedQuotation(userId);
            return data;
        }

        [HttpGet("GetRequestedQuotationById/{userid}/{id}")]
        public TPRequestQuotationDetailsModel? GetRequestedQuotationById(int userId,int id)
        {
            var data = _tpRequestQuotationService.GetRequestedQuotationById(id, userId);
            return data;
        }

        [HttpGet("GetPaymentLink/{TPRequestId}")]
        public PaymentLink? GetPaymentLink(int TPRequestId)
        {
            var data = _tpRequestQuotationService.GetPaymentLink(TPRequestId);
            return data;
        }
        [HttpPost("AddPaymentLink")]
        public string AddPaymentLink([FromBody] PaymentLink model)
        {
            var result = _tpRequestQuotationService.AddPaymentLink(model);
            return result;
        }
        [HttpPost("UpdatePaymentLink")]
        public string UpdatePaymentLink([FromBody] PaymentLink model)
        {
            var result = _tpRequestQuotationService.UpdatePaymentLink(model);
            return result;
        }

    }
}
