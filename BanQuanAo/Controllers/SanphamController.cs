using BanQuanAo.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanQuanAo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamController : ControllerBase
    {
        private readonly ISanphamReponsitory sanpham;
        private readonly IWebHostEnvironment hostingEnvironment;

        public SanphamController(ISanphamReponsitory sanpham, IWebHostEnvironment hostingEnvironment)
        {
            this.sanpham = sanpham;
            this.hostingEnvironment = hostingEnvironment;
        }
        [HttpGet("GetAllSP")]
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
        [HttpGet("GetAllSP/{id}")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetByid(int id)
        {
            var sp = await sanpham.GetByid(id);
            return sp == null ? NotFound() : Ok(sp);
        }
        [HttpPost("AddSanpham")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> AddSP([FromBody]SanphamModel model)
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
        [HttpPut("UpdateSanpham/{id}")]
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
        [HttpDelete("DeletSanpham/{id}")]
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
        [HttpGet]
        [Route("Search3")]
        public async Task<IActionResult> SearchSanpham(string keyword, int pageNumber, int pageSize)
        {
            var result = await sanpham.SearchSanphamAsync(keyword, pageNumber, pageSize);
            return Ok(result);
        }


        [HttpGet("loaisp/{loaiSpId}")]
        public async Task<IActionResult> GetSanphamByLoaiSp(int loaiSpId)
        {
            var result = await sanpham.GetSanphamByLoaiSp(loaiSpId);
            return Ok(result);
        }
    }
}
