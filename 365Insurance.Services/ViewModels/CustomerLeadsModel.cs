using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Insurance.Services.ViewModels
{
    public class CustomerLeadsModel
    {
    }

    public class CustomerLeadSearch
    {
        public int userid { get; set; }
        public DateTime? startdate { get; set; }
        public DateTime? enddate { get; set; }
    }
}
