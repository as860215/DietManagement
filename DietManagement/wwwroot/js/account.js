$(function () {
    //滑鼠移入變色
    $(".account").on("mouseover", function () {
        $(this).css("color","aqua");
    });
    //滑鼠移出變色
    $(".account").on("mouseout", function () {
        $(this).css("color", "");
    });

    $("#login").on("click", function () {
        removeTabActive();
        $("#partialLogin").addClass("active in");
    });
    
    $("#registered").on("click", function () {
        removeTabActive();
        $("#partialRegistered").addClass("active in");
    });

    $("#track").on("click", function () {
        removeTabActive();
        $("#partialTrack").addClass("active in");
    });

    $("#btn_cancel").on("click", function () {
        window.location.reload();
    });
});
//移除tab-pane顯示
function removeTabActive() {
    $(".tab-pane").each(function () {
        $(this).removeClass("active in");
    });
}
/**
 * 註冊事件
 * @param {any} url -
 */
function registeredEvent(url) {
    $("#btn_registered").on("click", function () {
        let datas = $("#form_registered").serializeArray();
        let members = {};
        datas.forEach(n => {
            n.name = n.name.replace("member.", "");
        });
        $.map(datas, function (n, i) {
            members[n['name']] = n['value'];
        });
        let data = { "Account": "capoo" };
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'json',
            data: { member: members},
            success: function (data) {
                console.log(data);
            }
        });
    });
}
/**
 * 登入事件
 * @param {any} url -
 */
function loginEvent(url) {
    $("#btn_login").on("click", function () {
        $.ajax({
            url: url,
            type: 'POST',
            data: { Account: $("#login_account").val(), Password: $("#login_password").val() },
            success: function (data) {
                if (data === undefined || data === null) {
                    alert("帳號或密碼錯誤！");
                    return;
                }
                alert("歡迎 " + data.name + " 登入成功！");
                removeTabActive();
                $("#login").hide();
                $("#registered").hide();
                $("#logout").show();
                $("#track").html("<span class='glyphicon glyphicon-user'></span>&nbsp;" + data.name).show();
            }
        });
    });
}