using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanQuanAo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatlieuController : ControllerBase
    {
        private readonly IChatlieuReponsitory s;
        public ChatlieuController(IChatlieuReponsitory s)
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
        [HttpGet("GetChatlieu/{id}")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetByid(int id)
        {
            var L = await s.GetByid(id);
            return L == null ? NotFound() : Ok(L);
        }
        [HttpPost("AddChatlieu")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Add(ChatlieuModel model)
        {
            try
            {
                var id = await s.AddChatlieu(model);
                var ls = await s.GetByid(id);
                return ls == null ? NotFound() : Ok(ls);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("UpdateChatlieu/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Updated(int id, [FromBody] ChatlieuModel model)
        {
            if (id != model.id)
            {
                return NotFound();
            }
            else
            {
                await s.Updatechatlieu(id, model);
                return Ok();
            }

        }
        [HttpDelete("DeletChatlieu/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> Delet([FromRoute] int id)
        {
            await s.Deletechatlieu(id);
            return Ok();
        }
    }
}
