using API.Models;
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
        [Route("/PengajuanCuti")]
        public IActionResult PengajuanCuti(PengajuanCuti pengajuan)
        {
            var data = cutiRepository.PengajuanCuti(pengajuan);
            if (data > 0)
                return Ok(new { message = "Berhasil Pengajuan Cuti", statusCode = 200, data = data });
            return BadRequest(new { message = "Gagal Pengajuan Cuti", statusCode = 400, data = data });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = cutiRepository.Get();
            if (data != null)
                return Ok(new { message = "Berhasil Get Cuti", statusCode = 200, data = data });
            return BadRequest(new { message = "Gagal Get Cuti", statusCode = 400, data = data });
        }

        [HttpDelete]
        public IActionResult Delete(int ID)
        {
            var data = cutiRepository.Delete(ID);
            if (data > 0)
                return Ok(new { message = "Berhasil Delete Cuti", statusCode = 200 });
            return BadRequest(new { message = "Gagal Delete Cuti", statusCode = 400 });
        }

        [HttpPost]
        public IActionResult Post(InputCuti input)
        {
            var data = cutiRepository.Post(input);
            if (data > 0)
                return Ok(new { message = "Berhasil Tambah Cuti", statusCode = 200 });
            return BadRequest(new { message = "Gagal Tambah Cuti", statusCode = 400 });
        }

        [HttpPut]
        public IActionResult Put(Cuti cuti)
        {
            var data = cutiRepository.Put(cuti);
            if (data > 0)
                return Ok(new { message = "Berhasil Edit Cuti", statusCode = 200 });
            return BadRequest(new { message = "Gagal Edit Cuti", statusCode = 400 });
        }
    }
}
