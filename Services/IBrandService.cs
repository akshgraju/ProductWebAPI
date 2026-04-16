using ProductWebAPI.Models;

namespace ProductWebAPI.Services
{
    public interface IBrandService
    {
        Task<int> AddBrand(Brand brd);
        Task<List<Brand>> GetAllBrands();
        Task<Brand?> GetBrandById(int brdId);
        Task<Brand?> GetBrandByName(string brandName);  // ← add this
    }
}