﻿using API.Models;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LemburController : ControllerBase
    {
        LemburRepository lemburRepository;
        public LemburController(LemburRepository lemburRepository)
        {
            this.lemburRepository = lemburRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = lemburRepository.Get();
            if (data != null)
                return Ok(new { message = "Berhasil Get Lembur", statusCode = 200, data = data });
            return BadRequest(new { message = "Gagal Get Lembur", statusCode = 400, data = data });
        }

        [HttpDelete]
        public IActionResult Delete(int ID)
        {
            var data = lemburRepository.Delete(ID);
            if (data > 0)
                return Ok(new { message = "Berhasil Delete Lembur", statusCode = 200 });
            return BadRequest(new { message = "Gagal Delete Lembur", statusCode = 400 });
        }

        [HttpPost]
        public IActionResult Post(InputLembur input)
        {
            var data = lemburRepository.Post(input);
            if (data > 0)
                return Ok(new { message = "Berhasil Tambah Lembur", statusCode = 200 });
            return BadRequest(new { message = "Gagal Tambah Lembur", statusCode = 400 });
        }

        [HttpPut]
        public IActionResult Put(Lembur lembur)
        {
            var data = lemburRepository.Put(lembur);
            if (data > 0)
                return Ok(new { message = "Berhasil Edit Lembur", statusCode = 200 });
            return BadRequest(new { message = "Gagal Edit Lembur", statusCode = 400 });
        }
    }
}
