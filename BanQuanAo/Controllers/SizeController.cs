using BanQuanAo.Models;
using BanQuanAo.Reponsitoreis.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanQuanAo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeReponsitory size;
        public SizeController(ISizeReponsitory size)
        {
            this.size = size;
        }
        [HttpGet("GetAllSize")]
        //[Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await size.GetAll());
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
            var Lsize = await size.GetByid(id);
            return Lsize == null ? NotFound() : Ok(Lsize);
        }
        [HttpPost("AddSize")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> AddSize(SizeModel model)
        {
            try
            {
                var sizeid = await size.AddSize(model);
                var lsize = await size.GetByid(sizeid);
                return lsize == null ? NotFound() : Ok(lsize);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("UpdatedSize/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> UpdatedSize(int id, [FromBody] SizeModel model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }
            else
            {
                await size.UpdateSize(id, model);
                return Ok();
            }

        }
        [HttpDelete("DeleteSize/{id}")]
        //[Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> DeletSize([FromRoute] int id)
        {
            await size.DeleteSize(id);
            return Ok();
        }
    }
}
