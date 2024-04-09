using BanDienThoai.Helpers;
using BanQuanAo.Data;
using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanQuanAo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSPController : ControllerBase
    {
        private readonly ILoaiSPReponsitory loaiSP;
        public LoaiSPController(ILoaiSPReponsitory loaiSP)
        {
            this.loaiSP = loaiSP;
        }
        [HttpGet("GetAllLoaiSP")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await loaiSP.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetLoaiSP/{id}")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetByid(int id)
        {
            var lsp = await loaiSP.GetByid(id);
            return lsp == null ? NotFound() : Ok(lsp);
        }
        [HttpPost("AddLoaisp")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> AddLoaissp(LoaiSPModel model)
        {
            try
            {
                var lspid = await loaiSP.AddLoaissp(model);
                var lsp = await loaiSP.GetByid(lspid);
                return lsp == null ? NotFound() : Ok(lsp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("UpdateLoaisp/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Updatelsp(int id, [FromBody] LoaiSPModel model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }
            else
            {
                await loaiSP.UpdateLoaissp(id, model);
                return Ok();
            }

        }
        [HttpDelete("DeletLoaisp/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Deletlsp([FromRoute] int id)
        {
            await loaiSP.DeleteLoaissp(id);
            return Ok();
        }

    }
}
