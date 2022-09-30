using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GajiController : Controller
    {
        public class DepartmentController : ControllerBase
        {
            GajiRepository gajiRepository;

            public DepartmentController(GajiRepository gajiRepository)
            {
                this.gajiRepository = gajiRepository;
            }


            [HttpPost]
            [Route("Cetak Slip Gaji")]
            public IActionResult CetakSlipGaji (CetakSlipGaji cetak)
            {
                var data = gajiRepository.CetakSlipGaji(cetak);
                if (data != null)
                    return Ok(new { message = "Berhasil Cetak Slip Gaji", statusCode = 200, data = data });
                return BadRequest(new { message = "Gagal Cetak Slip", statusCode = 400, data = data });
            }
        }
    }
}
