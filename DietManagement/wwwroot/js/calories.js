﻿//綁定計算熱量觸發事件
function eventSet() {
    //性別
    $("[name=radio_gender]").on("click", function () {
        $("#gender").val($(this).val());
    });

    //運動類型
    $("[name=sport]").on("click", function () {
        $("#sportType").val($(this).val());
        $("[name=sport]").css('background-color', 'white');
        $("[name=sport]").css('color', 'black');
        $(this).css('background-color', '#008CBA');
        $(this).css('color', 'white');
    });

    //計算熱量和bmi
    $("#calculation").on("click", function () {
        calories = $("#Calories").html();

        let height = $("#height").val();
        let weight = $("#weight").val();
        let age = $("#age").val();
        let gender = $("#gender").val();
        let sportType = $("#sportType").val();

        height = parseInt(height) / 100;

        let bmi = parseInt(weight) / height / height;
        bmi = bmi.toFixed(2);

        let bmr = (gender === true) ? 13.7 * weigh + 5 * height - 6.8 * age + 66 : 9.6 * weight + 1.8 * height - 4.7 * age + 655;

        if (sportType === "0")
            bmr = bmr * 1.2;
        else if (sportType === "1")
            bmr = bmr * 1.375;
        else if (sportType === "2")
            bmr = bmr * 1.55;
        else if (sportType === "3")
            bmr = bmr * 1.725;

        bmr = bmr.toFixed(2);

        $("#Calories").empty();
        $("#Calories").append("<div style='text-align:center'><label style='font-size:22pt'>測量結果</label><br /><br /><label style='font-size:22pt'>ＢＭＩ：<label id='bmi'></label></label><br /><br /><label style='font-size:22pt'>熱量建議：<label id='caloriesSuggest'></label></label></div>");
        $("#bmi").html(bmi);
        $("#caloriesSuggest").html(bmr);
    });
}

//重置計算熱量按鈕
$("#titleCalories").on("click", function () {
    if (calories === undefined) {
        return;
    }
    $("#Calories").empty();
    $("#Calories").append(calories);
    $("[name=sport]").css('background-color', 'white');
    $("[name=sport]").css('color', 'black');

    eventSet();
});