using API.Entities;

namespace API.DTOs.Vendors;

public class VendorDTO
{
    public string Guid { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string? Address { get; set; }
    public string? CompanyEmail { get; set; }
    public string? Phone { get; set; }
    public byte[]? Photo { get; set; }
    public string? Password { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsApproved { get; set; }
    public string? ApprovedBy { get; set; }
    public bool IsDeleted { get; set; }
    public string? BusinessField { get; set; }
    public string? BusinessType { get; set; }

    public static implicit operator Vendor(VendorDTO vendorDTO)
    {
        return new Vendor
        {
            Guid = vendorDTO.Guid,
            CompanyName = vendorDTO.CompanyName,
            Address = vendorDTO.Address,
            CompanyEmail = vendorDTO.CompanyEmail,
            Phone = vendorDTO.Phone,
            Photo = vendorDTO.Photo,
            Password = vendorDTO.Password,
            CreateDate = vendorDTO.CreateDate,
            IsApproved = vendorDTO.IsApproved,
            ApprovedBy = vendorDTO.ApprovedBy,
            IsDeleted = vendorDTO.IsDeleted,
            BusinessField = vendorDTO.BusinessField,
            BusinessType = vendorDTO.BusinessType,
        };
    }

    public static explicit operator VendorDTO(Vendor vendor)
    {
        return new VendorDTO
        {
            Guid = vendor.Guid,
            CompanyName = vendor.CompanyName,
            Address = vendor.Address,
            CompanyEmail = vendor.CompanyEmail,
            Phone = vendor.Phone,
            Photo = vendor.Photo,
            Password = vendor.Password,
            CreateDate = vendor.CreateDate,
            IsApproved = vendor.IsApproved,
            ApprovedBy = vendor.ApprovedBy,
            IsDeleted= vendor.IsDeleted,
            BusinessField = vendor.BusinessField,
            BusinessType = vendor.BusinessType,
        };
    }
}
