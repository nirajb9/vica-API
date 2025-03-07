﻿using VICAInsurance.Services.IServices;
using VICAInsurance.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VICAInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TpRatesController : ControllerBase
    {
        private readonly ITpRatesService  _tpratesService;
        public TpRatesController(ITpRatesService tpratesService)
        {
            _tpratesService = tpratesService;
        }
        [HttpPost("SaveTpRates")]
        public IActionResult SaveTpRates([FromBody] List<TpRatesModel> model)
        {
            var res = _tpratesService.AddTpRates(model);
            return Ok(model);
        }
        [HttpGet("GetTpRates/{stateId}/{vehicleTypeId}")]
        public List<TpRatesModel> GetTpRates(int stateId, int vehicleTypeId)
        {
            return _tpratesService.GetTpDetailsByID(stateId, vehicleTypeId);
        }
       
    }
}
