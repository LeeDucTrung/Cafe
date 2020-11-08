var frmFilter = $('#frmFilter');
var urlDomain = "/phieu-nhap";
var take = 10;
var skip = 0;
$(document).ready(function () {
    getDataPhieuNhap("",);
    frmFilter.find('#btnCreate').on('click', function () {
        openCreatePhieuNhap();
    });
});

function getDataPhieuNhap(name) {
    showLoading()
    $.ajax({
        url: "/phieu-nhap" + "/get-list/?name=" + name,
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
        url: "/phieu-nhap" + "/create",
        method: "Get",
        success: function (response) {
            showContentModal(response, "Tạo mới phiếu nhập")
        }
    });
}