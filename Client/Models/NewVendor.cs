namespace Client.Models
{
    public class NewVendor
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CompanyEmail { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string BusinessField { get; set; }
        public string BusinessType { get; set; }
    }
}
