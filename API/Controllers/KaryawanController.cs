﻿using API.Models;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class KaryawanController : ControllerBase
    {
        KaryawanRepository karyawanRepository;
        public KaryawanController(KaryawanRepository karyawanRepository)
        {
            this.karyawanRepository = karyawanRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = karyawanRepository.Get();
            if (data != null)
                return Ok(new { message = "Berhasil Get Karyawan", statusCode = 200, data = data });
            return BadRequest(new { message = "Gagal Get Karyawan", statusCode = 400, data = data });
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var data = karyawanRepository.Get(id);
            if (data != null)
                return Ok(new { message = "Berhasil Get Karyawan", statusCode = 200, data = data });
            return BadRequest(new { message = "Gagal Get Karyawan", statusCode = 400, data = data });
        }

        [HttpDelete("id")]
        public IActionResult Delete(int ID)
        {
            var data = karyawanRepository.Delete(ID);
            if (data > 0)
                return Ok(new { message = "Berhasil Delete Karyawan", statusCode = 200 });
            return BadRequest(new { message = "Gagal Delete Karyawan", statusCode = 400 });
        }

        [HttpPost]
        public IActionResult Post(InputKaryawan input)
        {
            var data = karyawanRepository.Post(input);
            if (data > 0)
                return Ok(new { message = "Berhasil Tambah Karyawan", statusCode = 200 });
            return BadRequest(new { message = "Gagal Tambah Karyawan", statusCode = 400 });
        }

        [HttpPut]
        public IActionResult Put(Karyawan karyawan)
        {
            var data = karyawanRepository.Put(karyawan);
            if (data > 0)
                return Ok(new { message = "Berhasil Edit Karyawan", statusCode = 200 });
            return BadRequest(new { message = "Gagal Edit Karyawan", statusCode = 400 });
        }
    }




}
