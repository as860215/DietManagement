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
    $(".active").removeClass("active");
}
/**
 * 註冊事件
 * @param {any} url -
 */
function registeredEvent(url) {
    $("#btn_registered").on("click", function () {
        let check = true;
        let $required = $(".registered-input");
        $required.each(function () {
            if ($(this).val() === "") {
                $("#registered_alert").show();
                check = false;
            }
        });
        if (check === false) {
            return;
        }

        $("#registered_alert").hide();

        let datas = $("#form_registered").serializeArray();
        let members = {};
        datas.forEach(n => {
            n.name = n.name.replace("member.", "");
        });
        $.map(datas, function (n, i) {
            members[n['name']] = n['value'];
        });
        $.ajax({
            url: url,
            type: 'POST',
            data: { member: members}
        }).done(function (data) {
            if (data.fail !== undefined) {
                alert("註冊失敗，帳號重複！");
                $("#member_Account").val("");
                return;
            }
            removeTabActive();
            $("#otherPartial").html(data);
            setTimeout(function () {
                window.location.reload();
            }, 3000);
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
                removeTabActive();
                $("#otherPartial").html(data);
                $("#UserData_MemberId").val($("#login_MemberId").val());
                $("#UserData_Account").val($("#login_Account").val());
                $("#UserData_Name").val($("#login_Name").val());
                setTimeout(function () {
                    $("#login").hide();
                    $("#registered").hide();
                    $("#logout").show();
                    $("#track").html("<span class='glyphicon glyphicon-user'></span>&nbsp;" + $("#UserData_Name").val()).show();
                    $("#otherPartial").html("");
                }, 3000);
            }
        });
    });
}
/**
 * 登出事件
 * @param {any} url -
 */
function logoutEvent(url) {
    $("#logout").on("click", function () {
        $.ajax({
            url: url,
            type: 'POST',
            data: { }
        }).done(function (data) {
            removeTabActive();
            $("#otherPartial").html(data);
            setTimeout(function () {
                window.location.reload();
            }, 1500);
        });
    });
}