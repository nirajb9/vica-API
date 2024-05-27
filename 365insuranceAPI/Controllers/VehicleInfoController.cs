using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using _365Insurance.Services.Services;
using _365Insurance.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace _365insuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleInfoController : ControllerBase
    {
        private readonly IVehicleInfoService _vehicleInfoService;

        public VehicleInfoController(IVehicleInfoService vehicleInfoService)
        {
            _vehicleInfoService = vehicleInfoService;
        }

        [HttpGet]
        public Task<List<VehicleInfo>> GetAllVehicleInfos()
        {
            return _vehicleInfoService.GetAllVehicleInfos();
        }

        [HttpPost("GetVehicleInformation")]
        public Task<VehicleInformation> GetVehicleInformation([FromBody] VehicleRegistrationSearch vrSearch)
        {
            return _vehicleInfoService.GetVehicleInformation(vrSearch);
        }

        [HttpGet("GetVehicleInfoById/{id}")]
        public Task<VehicleInfo> GetVehicleInfoById(int id)
        {
            return _vehicleInfoService.GetVehicleInfoById(id);
        }

        [HttpPost]
        public async Task<int> AddVehicleInfo([FromBody] VehicleInfo vehicleInfo)
        {
           return  await _vehicleInfoService.AddVehicleInfo(vehicleInfo);
        }

        [HttpPut]
        public void UpdateVehicleInfo([FromBody] VehicleInfo vehicleInfo)
        {
            _vehicleInfoService.UpdateVehicleInfo(vehicleInfo);
        }

        [HttpDelete("DeleteVehicleInfo/{id}")]
        public void DeleteVehicleInfo(int id)
        {
            _vehicleInfoService.DeleteVehicleInfo(id);
        }
        [HttpGet("GetInsuranceDetails/{variantId}/{stateCode}/{level}")]
        public Task<List<VehicleTransactionInfo>> GetInsuranceDetails(int variantId, string stateCode, int level)
        {
            return _vehicleInfoService.GetInsuranceDetails(variantId,stateCode, level);
        }

        [HttpPost("GetInsuranceDetails1")]
        public async Task<List<VT1>> GetInsuranceDetails1([FromBody] SearchParam searchParam)
        {
            return await _vehicleInfoService.GetInsuranceDetails(searchParam);
        }
        [HttpPost("GetInsuranceDetailsPayout")]
        public async Task<List<VT2>> GetInsuranceDetailsPayout([FromBody] SearchParam searchParam)
        {
            return await _vehicleInfoService.GetInsuranceDetailsPayout(searchParam);
        }
    }


}
