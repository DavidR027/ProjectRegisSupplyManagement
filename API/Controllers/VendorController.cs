using API.DTOs.Vendors;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("vendors")]
//[Authorize]
public class VendorController : ControllerBase
{
    private readonly VendorServices _vendorServices;
    public VendorController(VendorServices vendorServices)
    {
        _vendorServices = vendorServices;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var entities = _vendorServices.GetAllVendor();

            if (!entities.Any())
                return NotFound(new ResponseHandler<VendorDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });

            return Ok(new ResponseHandler<IEnumerable<VendorDTO>>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Data found",
                Data = entities
            });
        }
        catch (Exception ex)
        {
            //if error
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseExceptionHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = ex.Message
            });
        }
    }

    [HttpPost]
    public IActionResult Create(NewVendorDTO vendorDto)
    {
        try
        {
            var vendor = _vendorServices.CreateVendor(vendorDto);

            return Ok(new ResponseHandler<NewVendorDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendor created successfully",
                Data = vendor
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseExceptionHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = ex.Message
            });
        }
    }

    [HttpGet("{guid}")]
    public IActionResult GetByGuid(string guid)
    {
        try
        {
            var vendor = _vendorServices.GetVendorByGuid(guid);

            if (vendor == null)
                return NotFound(new ResponseHandler<VendorDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Vendor not found"
                });

            return Ok(new ResponseHandler<VendorDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendor found",
                Data = vendor
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseExceptionHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = ex.Message
            });
        }
    }

    [HttpPut]
    public IActionResult Update(VendorDTO vendorDto)
    {
        try
        {

            var vendor = _vendorServices.UpdateVendor(vendorDto);

            return NotFound(new ResponseHandler<VendorDTO>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Vendor not found"
            });

            return Ok(new ResponseHandler<VendorDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendor updated successfully",
                Data = vendor
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseExceptionHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = ex.Message
            });
        }
    }

    [HttpDelete("{guid}")]
    public IActionResult Delete(string guid)
    {
        try
        {
            var result = _vendorServices.DeleteVendor(guid);

            if (!result)
                return NotFound(new ResponseHandler<VendorDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Vendor not found"
                });

            return Ok(new ResponseHandler<VendorDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendor deleted successfully"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseExceptionHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = ex.Message
            });
        }
    }

    [HttpPut("{guid}/approve")]
    public IActionResult Approve(string guid)
    {
        try
        {
            var result = _vendorServices.ApproveVendor(guid);

            if (!result)
                return NotFound(new ResponseHandler<VendorDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Vendor not found"
                });

            return Ok(new ResponseHandler<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Vendor approved successfully"
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseExceptionHandler
            {
                Code = StatusCodes.Status500InternalServerError,
                Status = HttpStatusCode.InternalServerError.ToString(),
                Message = ex.Message
            });
        }
    }
}
