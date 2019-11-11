$('#abc').on("click", function () {
    var user = $('#usr').val();
    var pas = $("#pass").val();
    checkLogin(user, pas);

    if (checkLogin) {
        var url = '/Customer/Index';
        window.location.href = url;
    }
})


function checkLogin() {
    var l = Object.create(null)
    l.username = $('#usr').val();
    l.password = $("#pass").val();
    console.log(l);
    $.ajax({
        type: "GET",
        url: "/Login/GetVerify",
        data: l,
        success: function (res) {
            console.log(res.length);
            if (res.length) {
                var url = '/Customer/Index';
                window.location.href = url;

            }
            else {
                swal("Error", "Đăng nhập không thành công").catch(swal.noop);
            }
        }
    })
}