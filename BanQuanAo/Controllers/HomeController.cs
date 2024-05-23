using BanQuanAo.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanQuanAo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeReponsitory home;
        public HomeController(IHomeReponsitory home)
        {
            this.home = home;
        }
        [HttpGet("GetAlldm")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await home.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("categories-with-product-types")]
        public async Task<ActionResult<List<DanhmucWithLoaiSPModel>>> GetCategoriesWithProductTypes()
        {
            var categoriesWithProductTypes = await home.GetCategoriesWithProductTypesAsync();
            if (categoriesWithProductTypes == null || categoriesWithProductTypes.Count == 0)
            {
                return NotFound();
            }
            return Ok(categoriesWithProductTypes);
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchSanpham([FromQuery] string keyword)
        {
            var result = await home.SearchSanpham(keyword);
            return Ok(result);
        }
        [HttpGet("search2")]
        public async Task<IActionResult> SearchSanphaml(string keyword)
        {
            var matchingSanphams = await home.SearchSanphamAsync(keyword);
            if (matchingSanphams == null || matchingSanphams.Count == 0)
            {
                return NotFound();
            }
            return Ok(matchingSanphams);
        }
        [HttpGet]
        [Route("Search3")]
        public async Task<IActionResult> SearchSanpham(string keyword, int pageNumber, int pageSize)
        {
            var result = await home.SearchSanphamAsync(keyword, pageNumber, pageSize);
            return Ok(result);
        }


        [HttpGet("loaisp/{loaiSpId}")]
        public async Task<IActionResult> GetSanphamByLoaiSp(int loaiSpId)
        {
            var result = await home.GetSanphamByLoaiSp(loaiSpId);
            return Ok(result);
        }

        [HttpGet("khuyenmai")]
        public async Task<IActionResult> GetTop10KhuyenMai()
        {
            var sanphams = await home.GetTop10KhuyenMaiAsync();
            return Ok(sanphams);
        }

        [HttpGet("moi")]
        public async Task<IActionResult> GetTop10MoiNhat()
        {
            var sanphams = await home.GetTop10MoiNhatAsync();
            return Ok(sanphams);
        }
    }
}
