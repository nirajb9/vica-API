using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using _365Insurance.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.Services
{
    public class TpRatesService : ITpRatesService
    {
        private readonly Insure247DbContext _context;

        public TpRatesService(Insure247DbContext context)
        {
            _context = context;
        }

        public int AddTpRates(List<TpRatesModel> tpRate)
        {
            foreach(var tp in tpRate)
            {
                TpRatesMa obj = new TpRatesMa();
                obj.AgeId = tp.AgeId;
                obj.AgentCompanyId = tp.AgentCompanyId;
                obj.CompanyId = tp.CompanyId;
                
                obj.CubicCapicityId = tp.CubicCapicityId;
                obj.DriverCover = tp.DriverCover;
                obj.FueltypeId = tp.FueltypeId;
                obj.GcvGvw = tp.GcvGvw;
                obj.PaCover = tp.PaCover;
                obj.PassengersCover = tp.PassengersCover;
                obj.PayoutAmount = tp.PayoutAmount;
                obj.PremimumAmount = tp.PremimumAmount;
                obj.PremimumGst = tp.PremimumGst;
                obj.StateId = tp.StateId;
                obj.TpRatesId = tp.TpRatesId;
                obj.UserId = tp.UserId;
                obj.VehicleVariantId = tp.VehicleVariantId;
                obj.InsuranceCompanyId = tp.InsuranceCompanyId;
                obj.IsDeleted = tp.IsDeleted;
                obj.VehicleTypeId = tp.VehicleTypeId;
                obj.CreatedBy = 1;
                obj.CreatedDate = DateTime.Now;

                obj.ModifiedBy = 1;
                obj.ModifiedDate = DateTime.Now;

                if (tp.TpRatesId >0)
                {
                    _context.TpRatesMas.Update(obj);
                   
                }
                else
                {
                    _context.TpRatesMas.Add(obj);
                }

                _context.SaveChanges();
                UpdateRTO(obj.TpRatesId, obj.StateId, obj.AgentCompanyId, obj.UserId, tp.RtoList1);

            }

            return 0;
        }

        public List<TpRatesModel> GetTpDetailsByID(int stateId, int vehicleTypeId)
        {
            var lst = _context.TpRatesMas.Where(s => s.StateId == stateId && s.VehicleTypeId == vehicleTypeId && s.IsDeleted == false).ToList();
            List<TpRatesModel> lstRM = new List<TpRatesModel>();
            if (lst != null && lst.Count()>0)
            {
                foreach(var x in lst)
                {
                    TpRatesModel rm = new TpRatesModel();
                    rm.AgeId = x.AgeId;
                    rm.TpRatesId = x.TpRatesId;
                    rm.StateId = x.StateId;
                    rm.AgentCompanyId = x.AgentCompanyId;
                    rm.CompanyId = x.CompanyId;
                    rm.CubicCapicityId = x.CubicCapicityId;
                    rm.DriverCover = x.DriverCover;
                    rm.PaCover = x.PaCover;
                    rm.PayoutAmount = x.PayoutAmount;
                    rm.PremimumAmount = x.PremimumAmount;
                    rm.PremimumGst = x.PremimumGst;
                    rm.RtoId = x.RtoId;
                    rm.VehicleVariantId = x.VehicleVariantId;
                    rm.InsuranceCompanyId = x.InsuranceCompanyId;
                    rm.IsDeleted = false;
                    rm.FueltypeId = x.FueltypeId;
                    rm.PassengersCover = x.PassengersCover;
                    rm.UserId = x.UserId;
                    var l = _context.RtoTpratesMappings.Where(s => s.TpRatesId == rm.TpRatesId && s.IsDeleted == false).Select(s => s.RtoId);
                    rm.lsRtoId = l.Select(s => s.Value).ToList();
                    lstRM.Add(rm);

                }
                

                
            }


            return lstRM;
        }
        private void UpdateRTO(int TpRatesId,int? stateid, int? agentCompanyId, int? userId,  List<Multiselect> lstRTO)
        {
            var rtoList = _context.RtoTpratesMappings.Where(s => s.StateId == stateid && s.TpRatesId == TpRatesId).ToList();

            foreach(var r in lstRTO)
            {
                if (r.id > 0)
                {
                    var rtoList1 = rtoList.Where(s => s.RtoId == r.id).FirstOrDefault();
                    if (rtoList1 != null)
                    {
                        
                        rtoList1.IsDeleted = r.isselect?false:true;
                        _context.RtoTpratesMappings.Update(rtoList1);
                        _context.SaveChanges();
                    }
                    else
                    {
                        if (r.isselect)
                        {
                            RtoTpratesMapping objRTO = new RtoTpratesMapping();
                            objRTO.StateId = stateid;
                            objRTO.RtoId = r.id;
                            objRTO.AgentCompanyId = agentCompanyId;
                            objRTO.TpRatesId = TpRatesId;
                            objRTO.UserId = userId;
                            objRTO.IsDeleted = false;
                            objRTO.CompanyId = 1;
                            objRTO.CreatedDate = DateTime.Now;
                            objRTO.CreatedBy = 1;
                            objRTO.ModifiedBy = 1;
                            objRTO.ModifiedDate = DateTime.Now;
                            _context.RtoTpratesMappings.Add(objRTO);
                            _context.SaveChanges();
                        }
                    }
                }
            }


        }

    }
}
