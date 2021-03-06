﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAFE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPDT.Manager;
using VPDT.Models;

namespace VPDT.API.Controllers
{
    [Route("api/chi-tiet-phieu-nhap")]
    [ApiController]
    public class CHITIETPHIEUNHAPController : ControllerBase
    {
        private readonly ICHITIETPHIEUNHAPManager _manager;
        public CHITIETPHIEUNHAPController(ICHITIETPHIEUNHAPManager manager)
        {
            this._manager = manager;
        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetList(string name = "", int pageSize = 10, int pageNumber = 0)
        {
            try
            {
                var data = await _manager.Get_list(name, pageSize, pageNumber);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("get-list-thong-tin-phieu-nhap")]
        public async Task<IActionResult> GetListThongTinPhieuNhap(int id = 0, int pageSize = 10, int pageNumber = 0)
        {
            try
            {
                var data = await _manager.Get_list_Thong_Tin(id, pageSize, pageNumber);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("find-by-id")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var data = await _manager.FindById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CHITIETPHIEUNHAP inputModel)
        {
            try
            {
                await _manager.Create(inputModel);
                return Ok(inputModel);
            }
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] CHITIETPHIEUNHAP inputModel)
        {
            try
            {
                var data = await _manager.FindById(inputModel.ID);
                if(data == null)
                {
                    return StatusCode(404);
                }
                await _manager.Update(inputModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400,ex);
            }
        }

    }
}
