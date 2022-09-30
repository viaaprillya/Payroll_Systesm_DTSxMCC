using API.Models;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotonganController : ControllerBase
    {
        PotonganRepository potonganRepository;
        public PotonganController(PotonganRepository potonganRepository)
        {
            this.potonganRepository = potonganRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = potonganRepository.Get();
            if (data != null)
                return Ok(new { message = "Berhasil Get Potongan", statusCode = 200, data = data });
            return BadRequest(new { message = "Gagal Get Potongan", statusCode = 400, data = data });
        }

        [HttpDelete]
        public IActionResult Delete(int ID)
        {
            var data = potonganRepository.Delete(ID);
            if (data > 0)
                return Ok(new { message = "Berhasil Delete Potongan", statusCode = 200 });
            return BadRequest(new { message = "Gagal Delete Potongan", statusCode = 400 });
        }

        [HttpPost]
        public IActionResult Post(InputPotongan input)
        {
            var data = potonganRepository.Post(input);
            if (data > 0)
                return Ok(new { message = "Berhasil Tambah Potongan", statusCode = 200 });
            return BadRequest(new { message = "Gagal Tambah Potongan", statusCode = 400 });
        }

        [HttpPut]
        public IActionResult Put(Potongan potongan)
        {
            var data = potonganRepository.Put(potongan);
            if (data > 0)
                return Ok(new { message = "Berhasil Edit Potongan", statusCode = 200 });
            return BadRequest(new { message = "Gagal Edit Potongan", statusCode = 400 });
        }
    }
}
