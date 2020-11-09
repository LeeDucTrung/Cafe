var frmFilter = $('#frmFilter');
var urlDomain = "/phieu-nhap";
var take = 10;
var skip = 0;
$(document).ready(function () {
    var id = $('#idPhieuNhap').val();
    getDataThongTinPhieuNhap(id);
    frmFilter.find('#btnCreate').on('click', function () {
        openCreatePhieuNhap();
    });
});

function getDataThongTinPhieuNhap(id) {
    showLoading()
    $.ajax({
        url: "/phieu-nhap" + "/get-list-thong-tin-phieu-nhap?id=" + id,
        method: "GET",
        data: {
            title: frmFilter.find('#txtName').val(),
            take: take,
            skip: skip
        }
        , success: function (response) {
            $('#dtTable').html(response);
            hideLoading()
        }
    });
}
function openCreatePhieuNhap() {
    $.ajax({
        url: "/phieu-nhap" + "/create-thong-tin-phieu-nhap",
        method: "Get",
        success: function (response) {
            showContentModal(response, "Tạo mới thông tin phiếu nhập")
        }
    });
}