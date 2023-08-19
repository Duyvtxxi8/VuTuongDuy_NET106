using AppAPI.IServices;
using AppAPI.Services;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/color")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        public readonly IColorService colorService;
        public ColorController()
        {
            colorService = new ColorService();
        }
        [Route("get-color")]
        [HttpGet]
        public async Task<IActionResult> GetColor()
        {
            var Color = await colorService.GetAllColors();
            return Ok(Color);
        }
        [Route("add-color")]
        [HttpPost]
        public async Task<IActionResult> CreateColor(Color color)
        {
            var result = await colorService.AddColor(color);
            return Created("", color);
        }
        [Route("delete-color/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteColor(Guid id)
        {
            await colorService.DeleteColor(id);
            return Ok();
        }
        [HttpPost("tinh-bmi")]
        public string TinhBMI(double canNang, double chieuCao)
        {
            if (canNang <= 0 || chieuCao <=0)
            {
                return "Bạn phải nhập thông tin chính xác";
            }
            var BMI = canNang / (chieuCao * chieuCao);
            return $"Chỉ số bmi của bạn là: {BMI}";
        }
        [HttpPut("edit-color/{id}")]
        public async Task<IActionResult> UpdateColor(Guid id)
        {
            var result = await colorService.GetAllColors();
            var obj = result.First(c => c.Id == id);
            await colorService.UpdateColor(obj);
            return Ok(obj);
        }
    }
}
