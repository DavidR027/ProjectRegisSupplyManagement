using API.Contexts;
using API.Contracts;
using API.Entities;

namespace API.Repositories;

public class VendorRepository : GeneralRepository<Vendor>, IVendorRepository
{
    public VendorRepository(RegisterDbContext context) : base(context)
    {
    }
}
