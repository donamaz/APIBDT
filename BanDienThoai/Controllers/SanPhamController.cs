using BanDienThoai.Data;
using BanDienThoai.Helpers;
using BanDienThoai.Models;
using BanDienThoai.Repositories;
using BanDienThoai.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BanDienThoai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanpham sanpham;
        public SanPhamController(ISanpham sanpham)
        {
            this.sanpham = sanpham;
        }
        [HttpGet]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await sanpham.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetByid(int id)
        {
            var sp = await sanpham.GetByid(id);
            return sp == null ? NotFound() : Ok(sp);
        }
        [HttpPost]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> AddSP(SanphamModel model)
        {
            try
            {
                var spId = await sanpham.Addsanpham(model);
                var addedSp = await sanpham.GetByid(spId);
                return Ok(addedSp);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to add product", error = ex.Message });
            }

        }
        [HttpPut("{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Updatelsp(int id, [FromBody] SanphamModel model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }
            else
            {
                await sanpham.Updatesanpham(id, model);
                return Ok();
            }

        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Deletlsp([FromRoute] int id)
        {
            await sanpham.Deletesanpham(id);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchSanpham([FromQuery] string keyword)
        {
            var result = await sanpham.SearchSanpham(keyword);
            return Ok(result);
        }
        [HttpGet("search2")]
        public async Task<IActionResult> SearchSanphaml(string keyword)
        {
            var matchingSanphams = await sanpham.SearchSanphamAsync(keyword);
            if (matchingSanphams == null || matchingSanphams.Count == 0)
            {
                return NotFound();
            }
            return Ok(matchingSanphams);
        }


        [HttpGet("loaisp/{loaiSpId}")]
        public async Task<IActionResult> GetSanphamByLoaiSp(int loaiSpId)
        {
            var result = await sanpham.GetSanphamByLoaiSp(loaiSpId);
            return Ok(result);
        }
    }
}
