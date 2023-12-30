using Client.Models;
using Client.Repositories;
using Client.Repositories.Interface;

namespace Client.Repositories.Data
{
    public class VendorRepository : GeneralRepository<Vendor, Guid>, IVendorRepository
    {
        private readonly HttpClient httpClient;
        private readonly string request;
        public VendorRepository(string request = "Vendors/") : base(request)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7186/api/")
            };
            this.request = request;
        }

    }
}
