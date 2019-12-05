$(function () {
    //滑鼠移入變色
    $(".account").on("mouseover", function () {
        $(this).css("color","aqua");
    });
    //滑鼠移出變色
    $(".account").on("mouseout", function () {
        $(this).css("color", "");
    });

    //移除tab-pane顯示
    function removeTabActive() {
        $(".tab-pane").each(function () {
            $(this).removeClass("active in");
        });
    }

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
});