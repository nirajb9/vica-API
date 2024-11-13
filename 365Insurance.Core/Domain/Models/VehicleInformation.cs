using System;
using System.Collections.Generic;

namespace VICAInsurance.Core.Domain.Models;

public partial class VehicleInformation
{
    public int ViId { get; set; }

    public string? ClientId { get; set; }

    public string? RcNumber { get; set; }

    public DateTime? FitUpTo { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? OwnerName { get; set; }

    public string? FatherName { get; set; }

    public string? PresentAddress { get; set; }

    public string? PermanentAddress { get; set; }

    public string? MobileNumber { get; set; }

    public string? VehicleCategory { get; set; }

    public string? VehicleChasiNumber { get; set; }

    public string? VehicleEngineNumber { get; set; }

    public string? MakerDescription { get; set; }

    public string? MakerModel { get; set; }

    public string? BodyType { get; set; }

    public string? FuelType { get; set; }

    public string? Color { get; set; }

    public string? NormsType { get; set; }

    public string? Financer { get; set; }

    public bool? Financed { get; set; }

    public string? InsuranceCompany { get; set; }

    public string? InsurancePolicyNumber { get; set; }

    public DateTime? InsuranceUpto { get; set; }

    public string? ManufacturingDate { get; set; }

    public DateTime? ManufacturingDateFormatted { get; set; }

    public string? RegisteredAt { get; set; }

    public DateTime? LatestBy { get; set; }

    public bool? LessInfo { get; set; }

    public DateTime? TaxUpto { get; set; }

    public DateTime? TaxPaidUpto { get; set; }

    public int? CubicCapacity { get; set; }

    public int? VehicleGrossWeight { get; set; }

    public int? NoCylinders { get; set; }

    public int? SeatCapacity { get; set; }

    public int? SleeperCapacity { get; set; }

    public int? StandingCapacity { get; set; }

    public int? Wheelbase { get; set; }

    public int? UnladenWeight { get; set; }

    public string? VehicleCategoryDescription { get; set; }

    public string? PuccNumber { get; set; }

    public DateTime? PuccUpto { get; set; }

    public string? PermitNumber { get; set; }

    public DateTime? PermitIssueDate { get; set; }

    public DateTime? PermitValidFrom { get; set; }

    public DateTime? PermitValidUpto { get; set; }

    public string? PermitType { get; set; }

    public string? NationalPermitNumber { get; set; }

    public DateTime? NationalPermitUpto { get; set; }

    public string? NationalPermitIssuedBy { get; set; }

    public string? NonUseStatus { get; set; }

    public DateTime? NonUseFrom { get; set; }

    public DateTime? NonUseTo { get; set; }

    public string? BlacklistStatus { get; set; }

    public string? NocDetails { get; set; }

    public int? OwnerNumber { get; set; }

    public string? RcStatus { get; set; }

    public bool? MaskedName { get; set; }

    public string? ChallanDetails { get; set; }

    public string? Variant { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
