using System;
using System.Collections.Generic;

namespace _365Insurance.Core.Domain.Models;

public partial class TpRate
{
    public int TppId { get; set; }

    public int? CubicCapicityId { get; set; }

    public int? VehicleType { get; set; }

    public decimal? PcvTp { get; set; }

    public decimal? Passanger { get; set; }

    public decimal? PerPassenger { get; set; }

    public decimal? PersonalAccindent { get; set; }

    public decimal? Driver { get; set; }

    public decimal? NetPremimum { get; set; }

    public decimal? GstPcvTp { get; set; }

    public decimal? GstPassenger { get; set; }

    public decimal? GstPersonalAccident { get; set; }

    public decimal? GstDriver { get; set; }

    public decimal? GstTotal { get; set; }

    public decimal? FinalPremium { get; set; }

    public decimal? FiveYearTp { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
