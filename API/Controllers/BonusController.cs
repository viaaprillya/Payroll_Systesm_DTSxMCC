using API.Context;
using API.Models;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusController : ControllerBase
    {
        BonusRepository bonusRepository;
        public BonusController(BonusRepository bonusRepository)
        {
            this.bonusRepository = bonusRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = bonusRepository.Get();
            if (data != null)
                return Ok(new { message = "Berhasil Get Bonus", statusCode = 200, data = data });
            return BadRequest(new { message = "Gagal Get Bonus", statusCode = 400, data = data });
        }

        [HttpDelete]
        public IActionResult Delete(int ID)
        {
            var data = bonusRepository.Delete(ID);
            if (data > 0)
                return Ok(new { message = "Berhasil Delete Bonus", statusCode = 200});
            return BadRequest(new { message = "Gagal Delete Bonus", statusCode = 400});
        }

        [HttpPost]
        public IActionResult Post(InputBonus input)
        {
            var data = bonusRepository.Post(input);
            if (data > 0)
                return Ok(new { message = "Berhasil Tambah Bonus", statusCode = 200 });
            return BadRequest(new { message = "Gagal Tambah Bonus", statusCode = 400 });
        }

        [HttpPut]
        public IActionResult Put(Bonus bonus)
        {
            var data = bonusRepository.Put(bonus);
            if (data > 0)
                return Ok(new { message = "Berhasil Edit Bonus", statusCode = 200 });
            return BadRequest(new { message = "Gagal Edit Bonus", statusCode = 400 });
        }
    }
}
