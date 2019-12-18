//=========計算熱量=========
//綁定計算熱量觸發事件
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

        let bmr = (gender === false) ? 9.6 * weight + 1.8 * height - 4.7 * age + 655 : 13.7 * weigh + 5 * height - 6.8 * age + 66;

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
//=========計算熱量=========
//=========食譜推推=========
/**
 * 搜尋食譜
 * @param {any} url -
 */
function recipeSearchEvent(url) {
    $("#btn_recipeSearch").on("click", function () {
        let calories = $("#recipe_calories").val();
        $.ajax({
            url: url,
            type: 'POST',
            data: { calories: calories }
        }).done(function (data) {
            $("#recipe_searchResult").empty();
            if (data === undefined || data === null) {
                $("#recipe_searchResult").html("<div style='text-align:center'><span style='color:red'>查詢不到指定範圍內相關的食譜！</span></div>");
            }
            else {
                $("#recipe_searchResult").html(data);
            }
        });
    });
}
//=========食譜推推=========
//=========食物查詢=========
$("#food_selectFood").on("change", function () {
    let name = $("#food_selectFood option:selected").text();
    let calories = $("#food_selectFood option:selected").val();
    if (name === "請選擇...") {
        $("#food_calories").text("");
        return;
    }
    $("#food_calories").text(name + " " + calories + " 大卡");
});
function shopSearchEvent(url) {
    $("#btn_shopSearch").on("click", function () {
        let shopId = $("#food_selectShop").val();
        $.ajax({
            url: url,
            type: 'POST',
            data: { shopId: shopId }
        }).done(function (data) {
            $("#food_searchResult").empty();
            if (data === undefined || data === null) {
                $("#food_searchResult").html("<div style='text-align:center'><span style='color:red'>查詢不到商店內的食物資訊！</span></div>");
            }
            else {
                $("#food_searchResult").html(data);
            }
        });
    });
}
//=========食物查詢=========
//=========我要運動=========
$('#sport_picker').datetimepicker({
    format: 'yyyy/mm/dd 【 hh:00 】',
    minView: 'day',
    autoclose: true
});
/**
 * 建立運動
 * @param {any} url -
 */
function createSportEvent(url) {
    $("#btn_createSport").on("click", function () {
        $("#sport_addResult").text("");
        let MemberId = $("#UserData_MemberId").val();
        if (MemberId === undefined || MemberId === "") {
            alert("建立失敗，尚未登入！！");
            return;
        }

        if ($("#sport_picker").data("date") === undefined) {
            $("#sport_addResult").text("請選擇日期！");
            return;
        }

        let market = $("#sport_market").val();
        let date = $("#sport_picker").data("date").split(" ")[0];
        let time = $("#sport_picker").data("date").split(" ")[2];
        let datetime = date + " " + time + ":00";

        $.ajax({
            url: url,
            type: 'POST',
            data: { MemberId: MemberId, market: market, sportDate: datetime}
        }).done(function (data) {
            if (data === null) {
                $("#sport_addResult").text("建立失敗，請重新新增！");
                return;
            }
            $("#sport_addResult").text("※已新增一筆「" + $("#sport_market option:selected").text() + "」運動於 " + data.sportDate + " " + data.sportTime + "點！");
        });
    });
}
/**
 * 搜尋運動
 * @param {any} url -
 */
function searchSportEvent(url) {
    $("#btn_searchSport").on("click", function () {

    });
}
//=========我要運動=========