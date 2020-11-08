var frmUpdateNguyenLieu = $('#frmUpdateNguyenLieu');
$(document).ready(function () {
    addRequired(frmUpdateNguyenLieu);
    /*var DONVITINH = frmUpdateNguyenLieu.find('#DONVITINH').val();
    frmUpdateNguyenLieu.find('#listDonVi').val(DONVITINH).trigger('change');*/
});
$('#modal-form').find('.modal-dialog').addClass("modal-lg")
$('#modal-form').find('#btnSave').off("click").on('click', function (e) {
    e.preventDefault();
    UpdateNguyenLieu();
});
function UpdateNguyenLieu() {
    if (ValidateForm(frmUpdateNguyenLieu)) {
        return;
    }
    showLoading();
    $.ajax({
        url: "/nguyen-lieu" + "/create-or-update",
        method: "POST",
        data: {
            ID: frmUpdateNguyenLieu.find('#IDNguyenLieu').val(),
            TENNGUYENLIEU: frmUpdateNguyenLieu.find('#txtName').val(),
            SOLUONG: frmUpdateNguyenLieu.find('#txtSL').val(),
            DONVITINH: frmUpdateNguyenLieu.find('#listDonVi').val()
        }
        , success: function (response) {
            hideLoading()
            if (response.result) {
                showAlert(response.message, 2)
                getDataNguyenLieu("");
                hideContentModal()
            } else {
                showAlert(response.message)
            }
        }
    });
}