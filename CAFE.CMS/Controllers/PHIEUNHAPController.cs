using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAFE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VPDT.Models;
using VPDT.Utils;

namespace CAFE.CMS.Controllers
{
    [Route("phieu-nhap")]
    public class PHIEUNHAPController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _domain;
        public PHIEUNHAPController(IConfiguration config)
        {
            this._config = config;
            this._domain = _config["APIDomain"].ToString();
        }
        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            return PartialView("Create");
        }
        [HttpGet("update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = await HttpHelper.GetData<PHIEUNHAP>($"{_domain}/api/phieu-nhap/find-by-id", $"id={id}");
            return PartialView("UpdatePhieuNhap", data);
        }

        [HttpPost("create-or-update")]
        public async Task<IActionResult> Create_Or_Update(PHIEUNHAP inputModel)
        {
            try
            {
                if (inputModel.ID == 0)
                {
                    await HttpHelper.PostData<PHIEUNHAP>(inputModel, $"{_domain}/api/phieu-nhap/create");
                    return Json(new { Result = true, Message = "Thêm mới dữ liệu thành công" });
                }
                else
                {
                    await HttpHelper.PostData<PHIEUNHAP>(inputModel, $"{_domain}/api/phieu-nhap/update");
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
            var data = await HttpHelper.GetData<List<PHIEUNHAP>>($"{_domain}/api/phieu-nhap/get-list", $"name={name}");
            return PartialView("GetList", data);
        }
        [HttpGet("danh-sach")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("get-nha-cung-cap")]
        public async Task<IActionResult> GetChucVu()
        {
            try
            {
                var data = await HttpHelper.GetData<List<LookupModels>>($"{_domain}/api/nha-cung-cap/look-up-nha-cung-cap");
                return Json(new { Data = data });
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message });
            }
        }
    }
}
