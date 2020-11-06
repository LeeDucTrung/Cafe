var frmFilter = $('#frmFilter');
var urlDomain = "/nha-cung-cap";
var take = 10;
var skip = 0;
$(document).ready(function () {
    getData("",);
    searching();
    frmFilter.find('#btnCreate').on('click', function () {
        openCreate();
    });
});
function searching() {
    frmFilter.find("#btnSearch").on('click', function () {
        var name = frmFilter.find("#txtName").val();
        getData(name);
    });
}
function getData(name) {
    showLoading()
    $.ajax({
        url: urlDomain + "/get-list/?name=" + name,
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
        url: urlDomain + "/create",
        method: "Get",
        success: function (response) {
            showContentModal(response, "Tạo mới nhà cung cấp")
        }
    });
}