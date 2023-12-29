using API.Entities;

namespace API.DTOs.Employee;

public class EmployeeDTO
{
    public string Guid { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public DateTime CreateDate { get; set; }

    public static implicit operator Employee(EmployeeDTO employeeDto)
    {
        return new Employee
        {

        };
    }

    public static explicit operator Employee(Employee employee)
    {
        return new BatchClassDto
        {
            Guid = batchClass.Guid,
            Code = batchClass.Code,
            Quantity = batchClass.Quantity,
            Plan = batchClass.Plan,
            CreateDate = batchClass.CreateDate,
            Note = batchClass.Note,
            Status = batchClass.Status,
            ClassGuid = batchClass.Class,
            RoomGuid = batchClass.Room,
            BatchGuid = batchClass.Batch
        };
    }
}