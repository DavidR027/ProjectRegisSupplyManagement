using API.Contracts;
using API.DTOs.Vendors;
using API.Entities;
using API.Repositories;

namespace API.Services;

public class VendorServices
{
    private readonly IVendorRepository _vendorRepository;

    public VendorServices(IVendorRepository vendorRepository)
    {
        _vendorRepository = vendorRepository;

    }

    public IEnumerable<VendorDTO> GetAllVendor()
    {
        var vendors = _vendorRepository.GetAll();

        if (!vendors.Any()) return Enumerable.Empty<VendorDTO>();

        var getVendors = new List<VendorDTO>();

        foreach (var vendor in vendors)
        {
            if (vendor.IsDeleted) continue;

            getVendors.Add(new VendorDTO
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
                BusinessField = vendor.BusinessField,
                BusinessType = vendor.BusinessType,
                IsDeleted = vendor.IsDeleted,
            });
        }

        return getVendors;
    }

    public NewVendorDTO CreateVendor(NewVendorDTO vendorDto)
    {
        var vendor = new Vendor
        {
            Guid = Guid.NewGuid().ToString(),
            CompanyName = vendorDto.CompanyName,
            Address = vendorDto.Address,
            CompanyEmail = vendorDto.CompanyEmail,
            Phone = vendorDto.Phone,
            Photo = vendorDto.Photo,
            Password = vendorDto.Password,
            CreateDate = DateTime.Now,
            IsApproved = false,
            ApprovedBy = vendorDto.ApprovedBy,
            IsDeleted = false,
            BusinessField = vendorDto.BusinessField,
            BusinessType = vendorDto.BusinessType,
        };

        _vendorRepository.Create(vendor);
        return vendorDto;
    }

    public VendorDTO GetVendorByGuid(string guid)
    {
        var vendor = _vendorRepository.GetByGuid(guid);
        if (vendor == null || vendor.IsDeleted) return null;

        // Map the vendor to a VendorDTO
        var vendorDto = new VendorDTO
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
            BusinessField = vendor.BusinessField,
            BusinessType = vendor.BusinessType,
            IsDeleted = vendor.IsDeleted
        };

        return vendorDto;
    }

    public VendorDTO UpdateVendor(VendorDTO vendorDto)
    {
        var vendor = _vendorRepository.GetByGuid(vendorDto.Guid);
        if (vendor == null || vendor.IsDeleted) return null;

        //Update
        vendor.Guid = vendorDto.Guid;
        vendor.CompanyName = vendorDto.CompanyName;
        vendor.Address = vendorDto.Address;
        vendor.CompanyEmail = vendorDto.CompanyEmail;
        vendor.Phone = vendorDto.Phone;
        vendor.Photo = vendorDto.Photo;
        vendor.Password = vendorDto.Password;
        vendor.CreateDate = vendorDto.CreateDate;
        vendor.IsApproved = vendorDto.IsApproved;
        vendor.ApprovedBy = vendorDto.ApprovedBy;
        vendor.BusinessField = vendorDto.BusinessField;
        vendor.BusinessType = vendorDto.BusinessType;

        _vendorRepository.Update(vendor);
        return vendorDto;
    }

    public bool DeleteVendor(string guid)
    {
        var vendor = _vendorRepository.GetByGuid(guid);
        if (vendor == null || vendor.IsDeleted) throw new Exception("Vendor not found");

        vendor.IsDeleted = true;
        return _vendorRepository.Update(vendor);
    }

    public bool ApproveVendor(string guid)
    {
        var vendor = _vendorRepository.GetByGuid(guid);
        if (vendor == null) return false;

        vendor.IsApproved = true;
        _vendorRepository.Update(vendor);

        return true;
    }
}
