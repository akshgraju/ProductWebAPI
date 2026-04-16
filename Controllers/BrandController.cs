using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Models;
using ProductWebAPI.Services;

namespace ProductWebAPI.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;
        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet("getAllBrands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await brandService.GetAllBrands();
            return Ok(brands);
        }

        [HttpGet("getBrandById/{brdId}")]
        public async Task<IActionResult> GetBrandById(int brdId)
        {
            var brand = await brandService.GetBrandById(brdId);
            if (brand == null) return NotFound();
            return Ok(brand);
        }

        [HttpPost("addBrand")]
        public async Task<IActionResult> AddBrand(Brand brd)
        {
            int result = await brandService.AddBrand(brd);
            if (result > 0) return Ok(result);
            return BadRequest();
        }
        [HttpGet("getBrandByName/{brandName}")]
        public async Task<IActionResult> GetBrandByName(string brandName)
        {
            var brand = await brandService.GetBrandByName(brandName);
            if (brand == null) return NotFound("Brand not found!");
            return Ok(brand);
        }
    }
}