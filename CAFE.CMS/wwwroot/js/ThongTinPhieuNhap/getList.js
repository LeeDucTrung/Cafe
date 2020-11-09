var urlDomain = "/phieu-nhap";
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
function openUpdateThongTinNguyenLieu(id) {
    $.ajax({
        url: "/phieu-nhap" + "/update-thong-tin-phieu-nhap?id=" + id,
        method: "Get",
        success: function (response) {
            showContentModal(response, "Cập nhập chi tiết phiếu nhập")
        }
    });
}
function goToThongTin(phieunhapID) {
    window.location.href = "/phieu-nhap/thong-tin-phieu-nhap?idPhieuNhap=" + phieunhapID;
}

