using API.DTOs.Employee;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[ApiController]
[Route("employees")]
//[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeServices _employeeServices;
    public EmployeeController(EmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var entities = _employeeServices.GetAllEmployee();

            if (!entities.Any())
                return NotFound(new ResponseHandler<EmployeeDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data not found"
                });

            return Ok(new ResponseHandler<IEnumerable<EmployeeDTO>>
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
    public IActionResult Create(NewEmployeeDTO employeeDto)
    {
        try
        {
            var employee = _employeeServices.CreateEmployee(employeeDto);

            return Ok(new ResponseHandler<NewEmployeeDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Employee created successfully",
                Data = employee
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
            var employee = _employeeServices.GetEmployeeByGuid(guid);

            if (employee == null)
                return NotFound(new ResponseHandler<EmployeeDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Employee not found"
                });

            return Ok(new ResponseHandler<EmployeeDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Employee found",
                Data = employee
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
    public IActionResult Update(EmployeeDTO employeeDto)
    {
        try
        {

            var employee = _employeeServices.UpdateEmployee(employeeDto);

            if (employee == null)
                return NotFound(new ResponseHandler<EmployeeDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Employee not found"
                });

            return Ok(new ResponseHandler<EmployeeDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Employee updated successfully",
                Data = employee
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
            var result = _employeeServices.DeleteEmployee(guid);

            if (!result)
                return NotFound(new ResponseHandler<EmployeeDTO>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Employee not found"
                });

            return Ok(new ResponseHandler<EmployeeDTO>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Employee deleted successfully"
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
