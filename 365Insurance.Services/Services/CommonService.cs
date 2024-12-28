using VICAInsurance.Core.Domain.Models;
using VICAInsurance.Services.IServices;
using VICAInsurance.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace VICAInsurance.Services.Services
{
    public class CommonService : ICommonService
    {
        private readonly _247IDbContext _context;

        public CommonService(_247IDbContext context)
        {
            _context = context;
        }
        public async Task<List<VehicleFueltype>> GetVehicleFueltypes()
        {
            return await _context.VehicleFueltypes.Where(s => s.IsDeleted == false) .ToListAsync();
        }

        public async Task<List<VehicleType>> GetVehicleType()
        {
            return await _context.VehicleTypes.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<List<VehicleAge>> GetVehicleAge()
        {
            return await _context.VehicleAges.Where(s => s.IsDeleted == false).ToListAsync();
        }

        public async Task<List<StateMa>> GetState()
        {
            return await _context.StateMas.Where(s => s.IsDeleted == false).ToListAsync();
        }
        public async Task<List<RtoMa>> GetRTODetails(int stateId)
        {
            return await _context.RtoMas.Where(s => s.IsDeleted == false && s.StateId == stateId).ToListAsync();
        }

        public async Task<List<PolicyPaymentLink>> GetPaymentLink(SearchParam searchParam)
        {
            return await _context.PolicyPaymentLinks.Where(s =>s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId && s.IsDeleted == false).OrderByDescending(s=>s.PaymentLinkId).ToListAsync();
        }
        public async Task<List<PolicySurveyLink>> GetSurveyLink(SearchParam searchParam)
        {
            return await _context.PolicySurveyLinks.Where(s => s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId && s.IsDeleted == false).OrderByDescending(s => s.SurveyLinkId).ToListAsync();
        }
        public async Task<List<PolicyType>> GetPolicyType(SearchParam searchParam)
        {
            return await _context.PolicyTypes.Where(s => s.IsDeleted == false).ToListAsync();
        }
        public async Task<List<PolicyCashback>> GetPolicyCashback(SearchParam searchParam)
        {
            return await _context.PolicyCashbacks.Where(s => s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId).OrderByDescending(s => s.PolicyCashbackId).ToListAsync();
        }
        public async Task<CompanySlider> GetCompanySliders(SearchParam searchParam)
        {
            return await _context.CompanySliders.Where(s => s.UserId == searchParam.UserId && s.AgentCompanyId == searchParam.AgentCompanyId).FirstOrDefaultAsync();
        }
        public async Task<List<VehicleInsuranceCompany>> GetVehicleInsuranceCompanies()
        {
            return await _context.VehicleInsuranceCompanies.Where(s => s.IsDeleted == false).ToListAsync();
        }
        public async Task<AllMastersModel> GetAllMasters()
        {
            AllMastersModel allMastersModel = new AllMastersModel();
            allMastersModel.FuelTypeList = await GetVehicleFueltypes();
            allMastersModel.StateList = await GetState();
            allMastersModel.RtoList = await _context.RtoMas.Where(s => s.IsDeleted == false).ToListAsync();
            allMastersModel.VehicleAgeList = await GetVehicleAge();
            allMastersModel.VehicleTypeList = await GetVehicleType();
            allMastersModel.VehicleInsuranceCompanyList = await GetVehicleInsuranceCompanies();
            allMastersModel.VehicleCubicCapicityList= await _context.VehicleCubicCapicities.Where(s => s.IsDeleted == false).ToListAsync();
            allMastersModel.GSTValue = 18;

            return allMastersModel;
        }

        public async Task<List<ClaimSupportModel>> GetClaimSupport()
        {
            List<ClaimSupportModel>? result = null;
            try
            {
                result = await (from cs in _context.ClaimSupports
                          join viv in _context.VehicleInsuranceCompanies on cs.InsuranceCompanyId equals viv.InsuranceCompanyId
                          where cs.IsDeleted == false && viv.IsDeleted == false
                          select new ClaimSupportModel
                          {
                              CompanyName = viv.InsuranceCompanyName,
                              ContactNo = cs.ContactDetails,
                              Id = cs.ClaimSupportId

                          }).ToListAsync();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<List<MonthlyGridModel>> GetMonthlyGrid()
        {
            List<MonthlyGridModel>? result = null;
            try
            {
                result = await (from mg in _context.MonthlyGridMas
                                join sm in _context.StateMas on mg.StateId equals sm.StateId
                                where mg.IsDeleted == false && sm.IsDeleted == false
                                select new MonthlyGridModel
                                {
                                    FileLink = mg.FileLink,
                                    Month = mg.Month,
                                    StateCode = sm.StateCode,
                                    StateName = sm.StateName,                          
                                    Id = mg.GridId

                                }).ToListAsync();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<List<PolicyCopy>?> GetPolicyCopy(PolicyCopySearch model)
        {
            List<PolicyCopy>? result = null;
            try
            {
                DateTime? sdate = model.startdate == null ? DateTime.Now : model.startdate;
                DateTime? edate = model.enddate == null ? DateTime.Now : model.enddate;
                result = await _context.PolicyCopies.Where(s => s.UserId == model.userid && s.CreatedDate >= sdate.Value.Date.AddDays(-1) && s.CreatedDate <= edate.Value.Date.AddDays(1) && s.IsDeleted == false).ToListAsync();

            }
            catch (Exception ex)
            {
                return result;
            }

            return result;
        }

        public async Task<string> UploadToFtp(byte[] fileBytes, string fileName, int? userid)
        {
            var ftpServer = "ftp://vicainsurance.in";
            var ftpUsername = "webuploads"; //"vicainsu";
            var ftpPassword = "8u&bvY387"; //"wJ(o6ml5_NV1-)A";
            long currentDate = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            fileName = currentDate + "_" + fileName.Replace(" ","");

            var ftpRequest = (FtpWebRequest)WebRequest.Create($"{ftpServer}/{userid}/{fileName}");
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpRequest.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

            using (var ftpStream = ftpRequest.GetRequestStream())
            {
                ftpStream.Write(fileBytes, 0, fileBytes.Length);
            }

            using (var response = (FtpWebResponse)ftpRequest.GetResponse())
            {
                return $"https://assets.vicainsurance.in/uploads/{userid}/{fileName}";
            }
        }
        public async Task<string> UploadToFtp(IFormFile  model)
        {
            if (model == null || model.Length == 0)
            {
                return "No file uploaded.";
            }

            var ftpServer = "103.235.104.184";
            var ftpUsername = "vicainsu";
            var ftpPassword = "wJ(o6ml5_NV1-)A";
            var remoteFileName = model.FileName;

            try
            {
                // Save the uploaded file temporarily
                var tempFilePath = Path.Combine(Path.GetTempPath(), remoteFileName);
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await model.CopyToAsync(stream);
                }

                // Upload the file to the FTP server
                var ftpRequest = (FtpWebRequest)WebRequest.Create($"{ftpServer}/{remoteFileName}");
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                using (var fileStream = new FileStream(tempFilePath, FileMode.Open, FileAccess.Read))
                using (var ftpStream = await ftpRequest.GetRequestStreamAsync())
                {
                    await fileStream.CopyToAsync(ftpStream);
                }

                var response = (FtpWebResponse)await ftpRequest.GetResponseAsync();
                var status = response.StatusDescription;
                response.Close();

                // Optionally, delete the temporary file
                System.IO.File.Delete(tempFilePath);

                return  "File uploaded successfully";
            }
            catch (Exception ex)
            {
                return "Error uploading file to FTP";
            }
        }




    }
}
