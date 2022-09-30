using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutiController : ControllerBase
    {
        CutiRepository cutiRepository;

        public CutiController(CutiRepository cutiRepository)
        {
            this.cutiRepository = cutiRepository;
        }

        [HttpPost]
        [Route("PengajuanCuti")]
        public IActionResult PengajuanGaji(PengajuanCuti pengajuan)
        {
            var data = cutiRepository.PengajuanCuti(pengajuan);
            if (data > 0)
                return Ok(new { message = "Berhasil Pengajuan Cuti", statusCode = 200, data = data });
            return BadRequest(new { message = "Gagal Pengajuan Cuti", statusCode = 400, data = data });
        }


    }
}
