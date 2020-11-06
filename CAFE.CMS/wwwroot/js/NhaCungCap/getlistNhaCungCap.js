var urlDomain = "/nha-cung-cap";
var tblDisplay = $('#tblDisplay');
$(document).ready(function () {
    setDataTable();
});
function setDataTable() {
    tblDisplay.DataTable({
        "paging": true,
        "lengthChange": false,
        "pagingType": "full_numbers",
        "searching": true,
        "ordering": true,
        "info": false,
        "autoWidth": false,
        "responsive": true,
        "sDom": 'lrtip',
        order: [],
        columnDefs: [
            { orderable: false, targets: [2] },
            { orderable: false, targets: [3] },
            { orderable: false, targets: [4] }
        ]
        ,
        "language": {
            "emptyTable": "Không tìm thấy dữ liệu",
            "paginate": {
                "first": "Trang đầu",
                "last": "Trang cuối",
                "next": "Trang tiếp",
                "previous": "Trang trước"
            }

        }
    });
}
function openUpdate(id) {
    $.ajax({
        url: urlDomain + "/update?id=" + id,
        method: "Get",
        success: function (response) {
            showContentModal(response, "Cập nhật nhà cung cấp")
        }
    });
}
function openDelete(id) {
    /*$.ajax({
        url: urlDomain + "/delete?id=" + id,
        method: "Get",
        success: function (response) {
            showContentModal(response, "Xóa nguồn kinh phí")
        }
    });*/
    showAlert("chưa làm xóa", 1);
}
