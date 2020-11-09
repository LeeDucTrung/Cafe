using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPDT.Manager;
using VPDT.Models;
using VPDT.Utils;

namespace VPDT.API.Controllers
{
    [Route("api/nha-cung-cap")]
    [ApiController]
    public class NHACUNGCAPController : ControllerBase
    {
        private readonly INHACUNGCAPManager _manager;
        public NHACUNGCAPController(INHACUNGCAPManager manager)
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
        public async Task<IActionResult> Create([FromBody] NHACUNGCAP inputModel)
        {
            try
            {
                var exist = await _manager.Find_By_Name(inputModel.TENNHACUNGCAP);
                if (exist != null)
                {
                    throw new Exception($"Nhà cung cấp { MessageConst.EXIST }");
                }
                await _manager.Create(inputModel);
                return Ok(inputModel);
            }
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] NHACUNGCAP inputModel)
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
        [HttpGet("look-up-nha-cung-cap")]
        public async Task<IActionResult> LookUp()
        {
            try
            {
                var data = await _manager.Look_up();
                return Ok(data.Select(x => new { Value = x.ID, Title = x.TENNHACUNGCAP }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
