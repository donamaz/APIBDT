using BanDienThoai.Helpers;
using BanDienThoai.Models;
using BanDienThoai.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanDienThoai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSPController : ControllerBase
    {
        private readonly ILoaiSP loaiSP;
        public LoaiSPController(ILoaiSP loaiSP)
        {
            this.loaiSP = loaiSP;
        }
        [HttpGet]
        [Authorize(Roles = "Customer,Admin")]
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
        [HttpGet("{id}")]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetByid(int id)
        {
            var lsp =await loaiSP.GetByid(id);
            return lsp == null ? NotFound() : Ok(lsp);
        }
        [HttpPost]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> AddLoaissp(LoaiSPModel model)
        {
            try
            {
                var lspid = await loaiSP.AddLoaissp(model);
                var lsp=await loaiSP.GetByid(lspid);
                return lsp==null? NotFound() : Ok(lsp);
            }catch
            {
                return BadRequest();
            }
            
        }
        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Updatelsp(int id,[FromBody]LoaiSPModel model)
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
        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Deletlsp([FromRoute]int id)
        {
            await loaiSP.DeleteLoaissp(id);
            return Ok();
        }
    }
}
