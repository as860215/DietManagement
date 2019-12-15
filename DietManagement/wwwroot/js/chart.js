function drawLineCanvas(ctx, data) {
    window.myLine = new Chart(ctx, {  //先建立一個 chart
        type: 'line', // 型態
        data: data,
        options: {
            responsive: true,
            legend: { //是否要顯示圖示
                display: true
            },
            tooltips: { //是否要顯示 tooltip
                enabled: true
            },
            scales: {  //是否要顯示 x、y 軸
                xAxes: [{
                    display: true
                }],
                yAxes: [{
                    display: true
                }]
            }
        }
    });
}
let lastHistoryClick;
function historyEvent(url) {
    $("#btn_trackHistory_calories,#btn_trackHistory_weight").on("click", function () {
        lastHistoryClick = this;

        let historyType = 0;
        if ($(this).attr("id") == "btn_trackHistory_weight") {
            historyType = 1;
        }

        //如果搜尋條件都沒有資料則使用預設搜尋
        if ($("#track_historyYear").val() == "" && $("#track_historyMonth").val() == "") {
            let defaultYear = new Date().getFullYear();
            let defaultMonth = new Date().getMonth();
            $("#track_historyYear").val(defaultYear);
            $("#track_historyMonth").val(new Date().getMonth());
        }
        let month = parseInt($("#track_historyMonth").val()) + 1;
        let year = $("#track_historyYear").val();
        if (month < 10)
            month = "0" + month;
        $("#track_historyDate").val(year + "-" + month + "-01");

        $("#btn_lastMonth").show();
        $("#btn_nextMonth").show();
        $("#track_displayDate").text(year + " / " + month);

        let memberId = $("#UserData_MemberId").val();
        let dateTime = $("#track_historyDate").val();

        $.ajax({
            url: url,
            type: 'POST',
            data: { memberId: memberId, dateTime: dateTime, historyType: historyType }
        }).done(function (data) {
            let title = "熱量";
            let color = "#ea464d";
            if (historyType == 1) {
                title = "體重";
                color = "#41BDFA";
            }
            let label = [];
            let value = [];
            data.histories.forEach(function (item) {
                label.push(item.dataDate.replace("T00:00:00", "").split("-")[2]);
                value.push(item.value);
            });

            //取得查詢月份有幾天
            let searchYear = $("#track_historyYear").val();
            let searchMonth = parseInt($("#track_historyMonth").val()) + 1;
            let monthDays = new Date(searchYear, searchMonth, 0).getDate();
            let bottomLabel = [];   //底下的標題
            let screenValue = [];   //畫圖的值
            let originDataCount = 0;
            for (i = 1; i <= monthDays; i++) {
                bottomLabel.push(searchYear + "/" + searchMonth + "/" + i);
                if (parseInt(label[originDataCount]) == i) {
                    screenValue.push(value[originDataCount]);
                    originDataCount++;
                }
                else {
                    screenValue.push(0);
                }
            }

            $("#canvasDiv").empty();
            $("#canvasDiv").html("<canvas id='canvas'></canvas>");

            var ctx = document.getElementById("canvas").getContext("2d");
            var lineChartData = {
                labels: bottomLabel, //顯示區間名稱
                datasets: [{
                    label: title, // tootip 出現的名稱
                    lineTension: 0.2, // 曲線的彎度，設0 表示直線
                    backgroundColor: color,
                    borderColor: color,
                    borderWidth: 5,
                    data: screenValue, // 資料
                    fill: false, // 是否填滿色彩
                }]
            };
            drawLineCanvas(ctx, lineChartData);
        });

    });
}
$(function () {
    $("#btn_nextMonth,#btn_lastMonth").on("click", function () {
        let searchYear = parseInt($("#track_historyYear").val());
        let searchMonth = parseInt($("#track_historyMonth").val());

        if ($(this).attr("id") == "btn_nextMonth")
            searchMonth++;
        else
            searchMonth--;

        //進位到下一年
        if (searchMonth >= 12) {
            searchYear++;
            searchMonth = 0;
        }
        //退位到前一年
        else if (searchMonth < 0) {
            searchYear--;
            searchMonth = 11;
        }

        $("#track_historyYear").val(searchYear);
        $("#track_historyMonth").val(searchMonth);

        $(lastHistoryClick).click();
    });
});