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
                    return Json(new { Result = true, Message = "Thêm mới phiếu nhập thành công" });
                }
                else
                {
                    await HttpHelper.PostData<PHIEUNHAP>(inputModel, $"{_domain}/api/phieu-nhap/update");
                    return Json(new { Result = true, Message = "Cập nhật phiếu nhập thành công" });
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
        [HttpGet("get-nguyen-lieu")]
        public async Task<IActionResult> GetNguyenLieu()
        {
            try
            {
                var data = await HttpHelper.GetData<List<LookupModels>>($"{_domain}/api/nguyen-lieu/look-up-nguyen-lieu");
                return Json(new { Data = data });
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message });
            }
        }
        [HttpGet("thong-tin-phieu-nhap")]
        public async Task<IActionResult> ThongTinPhieuNhap(int idPhieuNhap)
        {
            ViewData["idPhieuNhap"] = idPhieuNhap;
            return View();
        }
        [HttpGet("get-list-thong-tin-phieu-nhap")]
        public async Task<IActionResult> GetListThongTinPhieuNhap(int id)
        {
            var data = await HttpHelper.GetData<List<CHITIETPHIEUNHAP>>($"{_domain}/api/chi-tiet-phieu-nhap/get-list-thong-tin-phieu-nhap", $"id={id}");
            return PartialView("GetListThongTinPhieuNhap", data);
        }

        [HttpGet("create-thong-tin-phieu-nhap")]
        public async Task<IActionResult> CreateThongTinPhieuNhap()
        {
            return PartialView("CreateThongTinPhieuNhap");
        }
        [HttpGet("update-thong-tin-phieu-nhap")]
        public async Task<IActionResult> UpdateThongTinPhieuNhap(int id)
        {
            var data = await HttpHelper.GetData<CHITIETPHIEUNHAP>($"{_domain}/api/chi-tiet-phieu-nhap/find-by-id", $"id={id}");
            return PartialView("UpdateThongTinPhieuNhap", data);
        }
        [HttpPost("create-or-update-thong-tin")]
        public async Task<IActionResult> Create_Or_Update_Thong_Tin(CHITIETPHIEUNHAP inputModel)
        {
            try
            {
                if (inputModel.ID == 0)
                {
                    await HttpHelper.PostData<CHITIETPHIEUNHAP>(inputModel, $"{_domain}/api/chi-tiet-phieu-nhap/create");
                    return Json(new { Result = true, Message = "Thêm mới chi tiết phiếu nhập thành công" });
                }
                else
                {
                    await HttpHelper.PostData<CHITIETPHIEUNHAP>(inputModel, $"{_domain}/api/chi-tiet-phieu-nhap/update");
                    return Json(new { Result = true, Message = "Cập nhật chi tiết phiếu nhập thành công" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }
        }

    }
}
