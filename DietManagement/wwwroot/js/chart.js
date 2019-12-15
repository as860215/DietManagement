function drawLineCanvas(ctx, data) {
    window.myLine = new Chart(ctx, {  //先建立一個 chart
        type: 'line', // 型態
        data: data,
        options: {
            responsive: true,
            legend: { //是否要顯示圖示
                display: true,
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
            },
        }
    });
};