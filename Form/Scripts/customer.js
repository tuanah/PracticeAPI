$(document).ready(function () {
    $('#loginName').text(sessionStorage.getItem('name'));

});


//Load data to table
$.ajax({
    url: "/Customer/GetList",
    dataType: "json",
    success: function (res) {
        $('#myDataTable').bootstrapTable({ data: res });
    }
})

// Add Option collumn into Table
function formatterDel(value) {
    var data = JSON.stringify(value);
    return '<a href="#myDataTable"><span class="fas fa-edit text-infor mr-2" onclick="editInformation(' + data + ') "data-toggle="modal" data-target="#editModal"></span></a><a href="#myDataTable"><span class="fa fa-trash text-danger" onclick="conformDel(' + data + ')"></span></a>'
}

// Check Input form
// Hide anhd Show tag contain "d-none"
function checkInput($formId) {
    var check = true;
    $formId.find('input[type=text]').each(
        function (index) {
            var param = $(this);
            if (param.val() == '') {
                $("div[name=" + param.attr('name') + "]").removeClass("d-none");
                check = false;
            } else {
                $("div[name=" + param.attr('name') + "]").addClass("d-none");
            }
        }
    );
    var a = $formId.find('input[type=radio]:checked');
    if (!a.val()) {
        a = $formId.find('input[type=radio]');
        $("div[name=" + a.attr('name') + "]").removeClass("d-none");
        check = false;
    } else {
        $("div[name=" + a.attr('name') + "]").addClass("d-none");
    }
    return check;
}

//Call Controller in MVC by using ajax
function addNewInfor(infor) {
    var check = true
    $.ajax({
        type: "POST",
        url: "/Customer/PostNewInfo",
        data: infor,
        success: function (res) {
            if (res.status == 'error') {
                swal('Error!', 'Some information were miss!').catch(swal.noop);
                check = false;
            }
            else {
                swal('Adding successfully.').catch(
                    swal.noop);
                $('#myDataTable').bootstrapTable('refresh', {
                    url: '/Customer/GetList'
                })
            }
        },
        error: function (xhr, error) {
            console.log("abc");
            console.debug(xhr); console.debug(error);
            check = false;
        }
    })
    return check;
}

//Call Controller in MVC by using ajax
function putEditedInfor(infor) {
    $.ajax({
        type: "POST",
        url: "/Customer/PutInfor",
        data: infor,
        success: function (res) {
            if (res) {
                swal('Successfully edit.').catch(swal.noop);
                $('#myDataTable').bootstrapTable('refresh', {
                    url: '/Customer/GetList'
                })
            }
            else swal('error', 'Error');
        }
    })

}

//Call Controller in MVC by using ajax
function delInfor(id) {
    $.ajax({
        type: "POST",
        url: "/Customer/Delete",
        data: { id: id },
        success: function (res) {
            if (res) {
                swal('Successfully delete.').catch(
                    swal.noop);
                $('#myDataTable').bootstrapTable('refresh', {
                    url: '/Customer/GetList'
                });
            }
            else {
                swal('Error!');
            }
        }
    })
}


// Icon edit (collum Option in Table) click
function editInformation(id) {
    $('#editModal div[name=inputName]').addClass("d-none");
    $('#editModal div[name=sGender]').addClass("d-none");
    $('#editModal div[name=inputPhone]').addClass("d-none");
    $('#editModal div[name=inputMail]').addClass("d-none");
    $('#editModal div[name=inputAddress]').addClass("d-none");
    

    var infor = $('#myDataTable').bootstrapTable('getRowByUniqueId', id);
    infor.Gender = infor.Gender.replace(/\s/g, '');

    $('#idName').text("ID: " + id);
    if (infor.Gender == "Male" || infor.Gender == "Nam") {
        $('#radio_male').prop("checked", true);
    } else {
        $('#radio_female').prop("checked", true);
    }
    $('#editModal input[name=inputName]').val(infor.Name);
    $('#editModal input[name=inputPhone]').val(infor.Phone);
    $('#editModal input[name=inputMail]').val(infor.Email);
    $('#editModal input[name=inputAddress]').val(infor.Address);
}

// Icon Trash (collum Option in Table) click
function conformDel(id) {
    swal({
        type: 'warning',
        title: 'Warning',
        text: 'Do you want to delete this Information via ID = ' + id + '?',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then(function () {
        delInfor(id);
    }).catch(swal.noop);
}


//Button "Add to Table" in _FormInfor.cshtml
$('#btnAdd').on("click", function () {
    var check = true;
    if (!$('#txtName').val()) {
        $('#wName').removeClass("d-none");
        check = false;
    } else {
        $('#wName').addClass("d-none");
        check = true;
        if (!$('#txtPhone').val()) {
            $('#wPhone').removeClass("d-none");
            check = false;
        } else {
            $('#wPhone').addClass("d-none");
            check = true;
            if (!$('#mail').val()) {
                $('#wMail').removeClass("d-none");
                check = false;
            } else {
                $('#wMail').addClass("d-none");
                check = true;
                if (!$('#txtAddress').val()) {
                    $('#wAddress').removeClass("d-none");
                    check = false;
                } else {
                    $('#wAddress').addClass("d-none");
                    check = true;
                }
            }
        }
    }

    if (check) {
        var infor = new Object();
        infor.Name = $('#txtName').val();
        infor.Gender = $('input[name="gender"]:checked').val();
        infor.Phone = $('#txtPhone').val();
        infor.Email = $('#mail').val();
        infor.Address = $('#txtAddress').val();

        if (addNewInfor(infor)) {
            $('#txtName').val('');
            $('#txtPhone').val('');
            $('#mail').val('');
            $('#txtAddress').val('');
            $('#radio_male').prop("checked", false);
            $(':radio').prop('checked', false);
        }
    }
})


//Button "Find" in _FormInfor.cshtml
$('#btnFind').on("click", function () {
    var infor = Object.create(null);
    infor.Name = $('#txtName').val();
    infor.Gender = $('input[name="gender"]:checked').val();
    infor.Phone = $('#txtPhone').val();
    infor.Email = $('#mail').val();
    infor.Address = $('#txtAddress').val();
    console.log(infor);

    $.ajax({
        type: "GET",
        url: "/Customer/GetFindResult",
        data: infor,
        success: function (res) {
            console.log(res);
            $('#myDataTable').bootstrapTable('load', res);
        }
    })
})

// Button Save in EditModal (_DisplayModal.cshtml)
$('#sBtnSave').on("click", function () {
    var infor = new Object();
    infor.CustomerId = $('#idName').text().substr(4, $(this).text().length);
    infor.Name = $('input[name=inputName]').val();
    infor.Gender = $('input[name="sGender"]:checked').val();
    infor.Phone = $('input[name=inputPhone]').val();
    infor.Email = $('input[name=inputMail]').val();
    infor.Address = $('input[name=inputAddress]').val();

    if (checkInput($('#formEdit'))) {
        putEditedInfor(infor);
        $('#editModal').modal('hide');
    }

})

// Button Create in createModal (_DisplayModal.cshtml)
$('#btnConformCreate').on("click", function () {
    var infor = new Object();
    infor.id = $('#idName').text().substr(4, $(this).text().length);
    infor.Name = $('#formCreate input[name=inputName]').val();
    infor.Gender = $('#formCreate input[name="sGender"]:checked').val();
    infor.Phone = $('#formCreate input[name=inputPhone]').val();
    infor.Email = $('#formCreate input[name=inputMail]').val();
    infor.Address = $('#formCreate input[name=inputAddress]').val();


    if (checkInput($('#formCreate'))) {
        if (addNewInfor(infor)) {
            $('#formCreate input[name=inputName]').val('');
            $('#formCreate input[name=inputPhone]').val('');
            $('#formCreate input[name=inputMail]').val('');
            $('#formCreate input[name=inputAddress]').val('');
            $(':radio').prop('checked', false);
        };
        $('#createModal').modal('hide');
    }

})
