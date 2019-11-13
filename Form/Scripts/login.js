


function checkLogin() {
    var l = Object.create(null)
    l.username = $('#usr').val();
    l.password = $("#pass").val();
    $.ajax({
        type: "GET",
        url: "/Login/GetVerify",
        data: l,
        success: function (res) {
            if (res.length) {
                var url = '/Customer/Index';
                sessionStorage.setItem('name', l.username);
                window.location.href = url;
            }
            else {
                swal("Error", "Đăng nhập không thành công").catch(swal.noop);
            }
        }
    })
}