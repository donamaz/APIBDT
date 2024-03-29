using AutoMapper;
using BanDienThoai.DTO;
using BanDienThoai.Models;
using BanDienThoai.Repositories;
using BanDienThoai.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanDienThoai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonhangController : ControllerBase
    {
        private readonly IDonhang _donhangRepository;
        

        public DonhangController(IDonhang donhangRepository)
        {
            _donhangRepository = donhangRepository;
            
        }

        [HttpPost]
        public async Task<IActionResult> AddDonhang([FromBody] DonhangRequest request)
        {
            try
            {
                var donhangId = await _donhangRepository.AddDonhang(request.DonhangModel, request.ChitietDonhangModels, request.KhachhangModel);

                
                return Ok(new { message = "Order added successfully", orderId = donhangId });
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { message = "Failed to add order", error = ex.Message });
            }
        }
    }
}
