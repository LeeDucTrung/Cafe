var frmFilter = $('#frmFilter');
var urlDomain = "/nguyen-lieu";
var take = 10;
var skip = 0;
$(document).ready(function () {
    getDataNguyenLieu("",);
    searching();
    frmFilter.find('#btnCreate').on('click', function () {
        openCreate();
    });
});
function searching() {
    frmFilter.find("#btnSearch").on('click', function () {
        var name = frmFilter.find("#txtName").val();
        getDataNguyenLieu(name);
    });
}
function getDataNguyenLieu(name) {
    showLoading()
    $.ajax({
        url: "/nguyen-lieu" + "/get-list/?name=" + name,
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
function openCreate() {
    $.ajax({
        url: "/nguyen-lieu" + "/create",
        method: "Get",
        success: function (response) {
            showContentModal(response, "Tạo mới nguyên liệu")
        }
    });
}