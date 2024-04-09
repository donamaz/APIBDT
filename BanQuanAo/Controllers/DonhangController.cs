using BanDienThoai.Data;
using BanQuanAo.Data;
using BanQuanAo.DTO;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanQuanAo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonhangController : ControllerBase
    {
        private readonly IDonhangReponsitory _donhangRepository;


        public DonhangController(IDonhangReponsitory donhangRepository)
        {
            _donhangRepository = donhangRepository;

        }
        [HttpGet("GetAlldh")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _donhangRepository.GetAllAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddDonhang([FromBody] DonhangRequest request)
        {
            try
            {
                var donhangId = await _donhangRepository.AddDonhang(request.DonhangModel!, request.ChitietDonhangModels!, request.KhachhangModel!);


                return Ok(new { message = "Order added successfully", orderId = donhangId });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = "Failed to add order", error = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DonhangRequest>> GetHoaDonDetail(int id)
        {
            var hoaDonDetail = await _donhangRepository.GetHoaDonDetailByIdAsync(id);
            if (hoaDonDetail == null)
            {
                return NotFound();
            }
            return Ok(hoaDonDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonhang(int id)
        {
            var result = await _donhangRepository.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        

        
    }
}
