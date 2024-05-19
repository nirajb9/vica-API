using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using _365Insurance.Services.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.Services
{
    public class TPRequestQuotationService: ITPRequestQuotationService
    {
        private readonly Insure247DbContext _context;
        private readonly IConfiguration _configuration;


        public TPRequestQuotationService(Insure247DbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }
        public string SaveTPQuotation(TpRequestQuotation model)
        {
            try
            {
                _context.TpRequestQuotations.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return "fail";
            }

            return "success";
        }
    }
}
