namespace API.DTOs.Employee;

public class EmployeeDTO
{
    public string Guid { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDeleted { get; set; }

    public static implicit operator Entities.Employee(EmployeeDTO employeeDto)
    {
        return new Entities.Employee
        {
            Guid = employeeDto.Guid,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Role = employeeDto.Role,
            Email = employeeDto.Email,
            Password = employeeDto.Password,
            CreateDate = employeeDto.CreateDate,
            IsDeleted = employeeDto.IsDeleted,
        };
    }

    public static explicit operator EmployeeDTO(Entities.Employee employee)
    {
        return new EmployeeDTO
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
    }
}