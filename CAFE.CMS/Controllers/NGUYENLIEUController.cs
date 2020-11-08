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
    [Route("nguyen-lieu")]
    public class NGUYENLIEUController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _domain;
        public NGUYENLIEUController(IConfiguration config)
        {
            this._config = config;
            this._domain = _config["APIDomain"].ToString();
        }
        [HttpGet("create")]
        public async Task<IActionResult> CreateNGUYENLIEU()
        {
            return PartialView("CreateNGUYENLIEU");
        }
        [HttpGet("update")]
        public async Task<IActionResult> UpdateNGUYENLIEU(int id)
        {
            var data = await HttpHelper.GetData<NGUYENLIEU>($"{_domain}/api/nguyen-lieu/find-by-id", $"id={id}");
            return PartialView("UpdateNGUYENLIEU", data);
        }

        [HttpPost("create-or-update")]
        public async Task<IActionResult> Create_Or_Update(NGUYENLIEU inputModel)
        {
            try
            {
                if (inputModel.ID == 0)
                {
                    await HttpHelper.PostData<NGUYENLIEU>(inputModel, $"{_domain}/api/nguyen-lieu/create");
                    return Json(new { Result = true, Message = "Thêm mới dữ liệu thành công" });
                }
                else
                {
                    await HttpHelper.PostData<NGUYENLIEU>(inputModel, $"{_domain}/api/nguyen-lieu/update");
                    return Json(new { Result = true, Message = "Cập nhật dữ liệu thành công" });
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
            var data = await HttpHelper.GetData<List<NGUYENLIEU>>($"{_domain}/api/nguyen-lieu/get-list", $"name={name}");
            return PartialView("GetList", data);
        }
        [HttpGet("danh-sach")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
