$(document).ready(function () {
})

$('#usr').keypress((e) => {
    if (e.keyCode == 13 && $('#usr').val()) {
        $('#pass').focus();
    }
})

$('#pass').keypress((e) => {
    if (e.keyCode == 13 && $('#pass').val()) {
        checkLogin();
    }
})

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
                console.log("a");
                $('#usr').focus();
                $('#usr').addClass("border-bottom-danger");
                $('#loginError').removeClass("d-none");
            }
        }
    })
}