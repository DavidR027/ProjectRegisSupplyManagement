﻿using API.Contracts;
using API.DTOs.Employee;
using API.DTOs.Vendors;
using API.Entities;
using API.Repositories;

namespace API.Services;

public class EmployeeServices
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeServices(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
        
    }

    public IEnumerable<EmployeeDTO> GetAllEmployee()
    {
        var employees = _employeeRepository.GetAll();

        if (!employees.Any()) return Enumerable.Empty<EmployeeDTO>();

        var getEmployee = new List<EmployeeDTO>();

        foreach (var employee in employees)
        {
            if (employee.IsDeleted) continue;
            getEmployee.Add(new EmployeeDTO
            {
                Guid = employee.Guid,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Role = employee.Role,
                Email = employee.Email,
                Password = employee.Password,
                CreateDate = employee.CreateDate,
                IsDeleted = employee.IsDeleted,
            });
        }

        return getEmployee;
    }

    public NewEmployeeDTO CreateEmployee(NewEmployeeDTO employeeDto)
    {
        var employee = new Employee
        {
            Guid = Guid.NewGuid().ToString(),
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Role = employeeDto.Role,
            Email = employeeDto.Email,
            Password = employeeDto.Password,
            CreateDate = DateTime.Now,
            IsDeleted = false,
        };

        _employeeRepository.Create(employee);
        return employeeDto;
    }

    public EmployeeDTO GetEmployeeByGuid(string guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee == null || employee.IsDeleted) return null;

        // Map the employee to an EmployeeDTO
        var employeeDto = new EmployeeDTO
        {
            Guid = employee.Guid,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Role = employee.Role,
            Email = employee.Email,
            Password= employee.Password,
            CreateDate = employee.CreateDate,
            IsDeleted = employee.IsDeleted,
        };

        return employeeDto;
    }

    public EmployeeDTO UpdateEmployee(EmployeeDTO employeeDto)
    {
        var employee = _employeeRepository.GetByGuid(employeeDto.Guid);
        if (employee == null || employee.IsDeleted) return null;

        //Update
        employee.Guid = employeeDto.Guid;
        employee.FirstName = employeeDto.FirstName;
        employee.LastName = employeeDto.LastName;
        employee.Role = employeeDto.Role;
        employee.Email = employeeDto.Email;
        employee.Password = employeeDto.Password;

        _employeeRepository.Update(employee);
        return employeeDto;
    }

    public bool DeleteEmployee(string guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee == null || employee.IsDeleted) throw new Exception("Employee not found");

        employee.IsDeleted = true;
        _employeeRepository.Update(employee);

        return true;
    }
}
