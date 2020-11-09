using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VPDT.Models;
using VPDT.Utils;

namespace CAFE.CMS.Controllers
{
    [Route("nha-cung-cap")]
    public class NHACUNGCAPController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _domain;
        public NHACUNGCAPController(IConfiguration config)
        {
            this._config = config;
            this._domain = _config["APIDomain"].ToString();
        }
        [HttpGet("create")]
        public async Task<IActionResult> CreateNhaCungCap()
        {
            return PartialView("CreateNhaCungCap");
        }
        [HttpGet("update")]
        public async Task<IActionResult> UpdateNhaCungCap(int id)
        {
            var data = await HttpHelper.GetData<NHACUNGCAP>($"{_domain}/api/nha-cung-cap/find-by-id", $"id={id}");
            return PartialView("UpdateNhaCungCap", data);
        }

        [HttpPost("create-or-update")]
        public async Task<IActionResult> Create_Or_Update(NHACUNGCAP inputModel)
        {
            try
            {
                if (inputModel.ID == 0)
                {
                    await HttpHelper.PostData<NHACUNGCAP>(inputModel, $"{_domain}/api/nha-cung-cap/create");
                    return Json(new { Result = true, Message = "Thêm mới nhà cung cấp thành công" });
                }
                else
                {
                    await HttpHelper.PostData<NHACUNGCAP>(inputModel, $"{_domain}/api/nha-cung-cap/update");
                    return Json(new { Result = true, Message = "Cập nhật nhà cung cấp thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }
        }

        [HttpGet("get-list")]
        public async Task<IActionResult> GetList(string name)
        {
            var data = await HttpHelper.GetData<List<NHACUNGCAP>>($"{_domain}/api/nha-cung-cap/get-list", $"name={name}");
            return PartialView("GetList", data);
        }
        [HttpGet("danh-sach")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
