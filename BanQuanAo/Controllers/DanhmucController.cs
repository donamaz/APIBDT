using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanQuanAo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucController : ControllerBase
    {
        private readonly IDanhmucReponsitory danhmuc;
        public DanhmucController(IDanhmucReponsitory danhmuc)
        {
            this.danhmuc = danhmuc;
        }
        [HttpGet("GetAlldm")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await danhmuc.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("Getdm/{id}")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetByid(int id)
        {
            var lsp = await danhmuc.GetByid(id);
            return lsp == null ? NotFound() : Ok(lsp);
        }
        [HttpPost("Adddanhmuc")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> AddLoaissp(DanhmucModel model)
        {
            try
            {
                var lspid = await danhmuc.AddDanhmuc(model);
                var lsp = await danhmuc.GetByid(lspid);
                return lsp == null ? NotFound() : Ok(lsp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("Updateddanhmuc/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Updatelsp(int id, [FromBody] DanhmucModel model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }
            else
            {
                await danhmuc.UpdateDanhmuc(id, model);
                return Ok();
            }

        }
        [HttpDelete("Deletedanhmuc/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Deletlsp([FromRoute] int id)
        {
            await danhmuc.DeleteDanhmuc(id);
            return Ok();
        }
    }
}
