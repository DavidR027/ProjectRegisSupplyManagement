namespace API.Entities;

public class Employee
{
    public Employee()
    {
        Vendors = new HashSet<Vendor>();
    }
    public string Guid { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public DateTime CreateDate { get; set; }

    public virtual ICollection<Vendor> Vendors { get; set; }
}
