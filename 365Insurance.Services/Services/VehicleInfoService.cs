using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using _365Insurance.Services.ViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.Services
{
    public class VehicleInfoService : IVehicleInfoService
    {
        private readonly Insure247DbContext _context;
        private readonly IConfiguration _configuration;
       

        public VehicleInfoService(Insure247DbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
           
        }

        public async Task<VehicleInformation> GetVehicleInformation(VehicleRegistrationSearch vrSearch)
        {
            var vehicleDetails = _context.VehicleInformations.Where(s => s.RcNumber == vrSearch.registrationno).OrderByDescending(s => s.ViId).FirstOrDefaultAsync();
            return await vehicleDetails;
        }

        public async Task<List<VehicleInfo>> GetAllVehicleInfos()
        {
            return await _context.VehicleInfos.ToListAsync();
        }

        public async Task<VehicleInfo> GetVehicleInfoById(int id)
        {
            return await _context.VehicleInfos.FindAsync(id);
        }

        public async Task<int> AddVehicleInfo(VehicleInfo vehicleInfo)
        {
            try
            {
                _context.VehicleInfos.Add(vehicleInfo);
            await _context.SaveChangesAsync();
            return vehicleInfo.VehicleinfoId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<string> UpdateVehicleInfo(VehicleInfo vehicleInfo)
        {
            try
            {
             _context.Entry(vehicleInfo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Sucess";
        }

        public async Task<string> DeleteVehicleInfo(int id)
        {
            try
            {
                var vehicleInfo = await _context.VehicleInfos.FindAsync(id);
                if (vehicleInfo != null)
                {
                    _context.VehicleInfos.Remove(vehicleInfo);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return "Sucess";
            
        }

        public async Task<List<VehicleTransactionInfo>> GetInsuranceDetails(int varientId, string stateCode, int level)
        {
            // level = 1 Model , level 2 varient
            var insuranceDetails = new List<VehicleTransactionInfo>();
            if(level == 1)
            {
                insuranceDetails = await (from ict in _context.InsuranceCompanyTransactions
                                          join vv in _context.VehicleModels on ict.CubicCapicityId equals vv.CubicCapicityId
                                          join vic in _context.VehicleInsuranceCompanies on ict.InsuranceCompanyId equals vic.InsuranceCompanyId
                                          where vv.ModelId == varientId
                                          select new VehicleTransactionInfo
                                          {
                                              CashBack = ict.CashBack,
                                              InsuranceAmount = ict.InsuranceAmount,
                                              InsuranceCompanyName = vic.InsuranceCompanyName

                                          }).ToListAsync();               
            }
            if(level == 2)
            {
                insuranceDetails = await (from ict in _context.InsuranceCompanyTransactions
                                          join vv in _context.VehicleVariants on ict.CubicCapicityId equals vv.CubicCapicityId
                                          join vic in _context.VehicleInsuranceCompanies on ict.InsuranceCompanyId equals vic.InsuranceCompanyId
                                          where vv.VehicleVariantId == varientId
                                          select new VehicleTransactionInfo
                                          {
                                              CashBack = ict.CashBack,
                                              InsuranceAmount = ict.InsuranceAmount,
                                              InsuranceCompanyName = vic.InsuranceCompanyName

                                          }).ToListAsync();          
            }
            return insuranceDetails;

        }

        public async Task<List<VT1>> GetInsuranceDetails(SearchParam searchParam)
        {
            List<VT1> lst = new List<VT1>();
          
            using (var db = new SqlConnection(_configuration.GetConnectionString("365IConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@StateId", searchParam.StateId);
                p.Add("@RTOId", searchParam.RTOId);
                p.Add("@VehicleTypeId", searchParam.VehicleTypeId);
                p.Add("@CCId", searchParam.CCId);
                p.Add("@FuelTypeId", searchParam.FuelTypeId);
                p.Add("@AgeId", searchParam.AgeId);
                lst = db.Query<VT1>("GetInsuranceComapanyTransaction", p, commandType: CommandType.StoredProcedure).ToList();

            }
            return lst;
        }
        public async Task<List<VT2>> GetInsuranceDetailsPayout(SearchParam searchParam)
        {
            List<VT2> lst = new List<VT2>();

            using (var db = new SqlConnection(_configuration.GetConnectionString("365IConnection")))
            {
                var p = new DynamicParameters();             
                p.Add("@RTOId", searchParam.RTOId);             
                p.Add("@CCId", searchParam.CCId);
                p.Add("@FuelTypeId", searchParam.FuelTypeId);
                p.Add("@AgeId", searchParam.AgeId);
                lst = db.Query<VT2>("GetInsuranceInfo", p, commandType: CommandType.StoredProcedure).ToList();

            }
            return lst;
        }
    }

}
