$(document).ready(function () {

})

//Check Enter key Login Page
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

//Check Enter key Register Page
$('#inputUsername').keypress((e) => {
    if (e.keyCode == 13 && $('#inputUsername').val()) {
        $('#inputPassword').focus();
    }
})
$('#inputPassword').keypress((e) => {
    if (e.keyCode == 13 && $('#inputPassword').val()) {
        $('#repeatPassword').focus();
    }
})
$('#repeatPassword').keypress((e) => {
    if (e.keyCode == 13 && $('#alertBox').hasClass("d-none")) {
        register();
    }
})


function checkRepeatPassword() {
    if ($('#repeatPassword').val() == $('#inputPassword').val()) {
        $('#alertBox').addClass("d-none");
        $('#repeatPassword').removeClass("border-bottom-danger")
        $('#repeatPassword').addClass("border-bottom-success");
    }
    else {
        $('#alertBox').removeClass("d-none");
        $('#repeatPassword').addClass("border-bottom-danger");
    }
}


function register() {
    var l = Object.create(null);
    l.username = $('#inputUsername').val();
    l.password = $('#inputPassword').val();

    $.ajax({
        type: 'POST',
        url: '/Login/PostNewAccount',
        data: l,
        success: function (res) {
            console.log(res);
        }
    })
}

function get() {
    $.ajax({
        type: 'GET',
        url: '/Login/GetList',
        success: function (res) {
            console.log(res);
        }
    })
}


