var frmUpdate = $('#frmUpdate');
var ListPermission = [];
var list = [];
var arrList = [];
$(document).ready(function () {
    addRequired(frmUpdate);
    setStatus();
    getListRole();
});
$('#modal-form').find('#btnSave').off("click").on('click', function (e) {
    e.preventDefault();
    update();
});


function getListRole() {
    var listQuyen = $("#frmUpdate").find("#listQuyen");
    listQuyen.select2({
        closeOnSelect: false
    });
    $.ajax({
        url: urlDomain + "/get-permissions",
        method: "GET",
        success: function (response) {
            $.each(response.data, function (i, itemMenu) {
                if (i >= 0) {
                    var newOption = new Option(itemMenu.title, itemMenu.value);
                    listQuyen.append(newOption);
                }
            })
        }
    }).then(function () {
        getListRolePermission();
    })
}
function getListRolePermission() {
    var listQuyen = $("#frmUpdate").find("#listQuyen");
    $.ajax({
        url: urlDomain + '/get-permission-by-roleid?roleId=' + frmUpdate.find("#hdId").val(),
        method: "GET",
        success(response) {
            $.each(response, function (i, itemMenu) {
                if (i >= 0) {
                    list.push(itemMenu.permissionId);
                }
            })
            listQuyen.val(list).trigger("change");
        }

    })
}
function setStatus() {
    if (frmUpdate.find('#ckbStatus').val() == 1) {
        frmUpdate.find('#ckbStatus').prop('checked', true);
    }
}
function update() {
    if (ValidateForm(frmUpdate)) {
        return;
    }
    showLoading();
    var listquyen = [];
    listquyen = frmUpdate.find('#listQuyen').val();
    for (i = 0; i < listquyen.length; i++) {
        var rolePermission = {
            permissionId: listquyen[i],
            sapxep: frmUpdate.find('#txtSapxep').val()
        }
        console.log(rolePermission);
        arrList.push(rolePermission);
    }
    $.ajax({
        url: urlDomain + "/create-or-update",
        method: "POST",
        data: {
            id: frmUpdate.find('#hdId').val(),
            role: frmUpdate.find('#txtName').val(),
            status: frmUpdate.find('#ckbStatus').prop("checked") ? 1 : 2,
            sapxep: frmUpdate.find('#txtSapxep').val(),
            Role_Permissions: arrList
        }
        , success: function (response) {
            hideLoading()
            if (response.result) {
                showAlert(response.message, 2)
                var name = frmFilter.find("#txtName").val();
                var status = frmFilter.find("#drStatus").val()
                getData(name, status);
                hideContentModal()
            } else {
                showAlert(response.message)
            }
        }
    });
}