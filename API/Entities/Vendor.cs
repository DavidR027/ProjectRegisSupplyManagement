namespace API.Entities;

public class Vendor
{
    public Vendor()
    {
        Employees = new HashSet<Employee>();
    }

    public string Guid { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string? Address { get; set; }
    public string? CompanyEmail { get; set; }
    public string? Phone { get; set; }
    public byte[]? Photo { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsApproved { get; set; }
    public string? ApprovedBy { get; set; }
    public string? BusinessField { get; set; }
    public string? BusinessType { get; set; }

    public virtual ICollection<Employee> Employees { get; set; }
}
