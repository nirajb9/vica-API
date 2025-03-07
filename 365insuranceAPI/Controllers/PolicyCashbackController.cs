﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.Services;
using VICAInsurance.Services.ViewModels;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PolicyCashbackController : ControllerBase
    {

        private readonly ICommonService _commonService;
        private readonly IPolicyCashbackService _policyCashbackService;

        public PolicyCashbackController(ICommonService commonService, IPolicyCashbackService policyCashbackService)
        {
            _commonService = commonService;
            _policyCashbackService = policyCashbackService;
        }

        [HttpPost("SavePolicyCashbackRequest")]
        public IActionResult SavePolicyCashbackRequest([FromBody] PolicyCashbackRequest model)
        {
            var data = "";
            try
            {
                data = _policyCashbackService.Save(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            return Ok(data);
        }

        [HttpGet("GetPolicyCashbackRequest/{userid}")]
        public async Task<List<PolicyCashbackRequestModel>> GetPolicyCashbackRequest(int userid)
        {
            var data = await _policyCashbackService.GetPolicyCashbackRequest(userid);
            return data;
        }

        [HttpGet("GetPolicyCashback/{userid}/{id}")]
        public async Task<PolicyCashbackModel> GetPolicyCashback(int userid, int id)
        {
            var data = await _policyCashbackService.GetPolicyCashback(userid,id);
            return data;
        }

        [HttpGet("GetPolicyCashbackRequest")]
        public async Task<List<PolicyCashbackRequestModel>> GetPolicyCashbackRequest()
        {
            var data = await _policyCashbackService.GetPolicyCashbackRequest();
            return data;
        }
        [HttpGet("GetPolicyCashbackDetails/{id}")]
        public async Task<List<PolicyCashbackRequestModel>> GetPolicyCashbackDetails(int id)
        {
            var data = await _policyCashbackService.GetPolicyCashbackDetails(id);
            return data;
        }
        [HttpPost("SaveCashback")]
        public async Task<IActionResult> SaveCashback([FromBody] PolicyCashbackDomainModel model)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                rr = await _policyCashbackService.SaveCashback(model);

            }
            catch (Exception ex)
            {

                return Ok(rr);
            }
            return Ok(rr);          
        }
    }
}
