using RetailEcommerce.Domain.Models;

namespace RetailEcommerce.Services.Interfaces
{
    public interface IAuthServices
    {

        Task<string?> GenerateJwtTokenAsync(AppUser user);

    }
}
