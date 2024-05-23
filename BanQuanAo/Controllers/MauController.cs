using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanQuanAo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauController : ControllerBase
    {
        private readonly IMauReponsitory s;
        public MauController(IMauReponsitory s)
        {
            this.s = s;
        }
        [HttpGet("GetAll")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await s.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetMau/{id}")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetByid(int id)
        {
            var L = await s.GetByid(id);
            return L == null ? NotFound() : Ok(L);
        }
        [HttpPost("AddMau")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Add(MauModel model)
        {
            try
            {
                var id = await s.Addmau(model);
                var ls = await s.GetByid(id);
                return ls == null ? NotFound() : Ok(ls);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("UpdateMau/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Updated(int id, [FromBody] MauModel model)
        {
            if (id != model.id)
            {
                return NotFound();
            }
            else
            {
                await s.Updatemau(id, model);
                return Ok();
            }

        }
        [HttpDelete("DeletMau/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Delet([FromRoute] int id)
        {
            await s.Deletemau(id);
            return Ok();
        }
    }
}
