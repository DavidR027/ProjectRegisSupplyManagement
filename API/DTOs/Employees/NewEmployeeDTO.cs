namespace API.DTOs.Employee;

public class NewEmployeeDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime CreateDate { get; set; }

    public static implicit operator Entities.Employee(NewEmployeeDTO employeeDto)
    {
        return new Entities.Employee
        {
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Role = employeeDto.Role,
            Email = employeeDto.Email,
            Password = employeeDto.Password,
            CreateDate = employeeDto.CreateDate,
        };
    }

    public static explicit operator NewEmployeeDTO(Entities.Employee employee)
    {
        return new NewEmployeeDTO
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Role = employee.Role,
            Email = employee.Email,
            Password = employee.Password,
            CreateDate = employee.CreateDate,
        };
    }
}