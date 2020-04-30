//added setTime function which waits for chart library to load then it triggers chart related methods.
setTimeout(function () {
    Chart.defaults.global.legend = { display: false }
    var chart = new CanvasJS.Chart("chartContainer", {
        animationEnabled: true,
        title: {
            text: "Budget Distribution 2019 vs. Budget Distribution 2020"
        },
        axisY: {
            title: "Thousand Dollars/$",
            titleFontColor: "#4F81BC",
            lineColor: "#4F81BC",
            labelFontColor: "#4F81BC",
            tickColor: "#4F81BC"
        },
        axisY2: {
            title: "Thousand Dollars/$",
            titleFontColor: "#C0504E",
            lineColor: "#C0504E",
            labelFontColor: "#C0504E",
            tickColor: "#C0504E"
        },
        toolTip: {
            shared: true
        },
        legend: {
            cursor: "pointer",
            itemclick: toggleDataSeries
        },
        data: [{
            type: "column",
            name: "Budget Distribution 2020/$",
            legendText: "Budget Distribution 2020",
            showInLegend: true,
            dataPoints: [
                { label: "EC", y: 200.00 },
                { label: "SC +", y: 200.00 },
                { label: "SC", y: 200.00 },
                { label: "SC -", y: 200.00 },
                { label: "NI", y: 200.00 },
            ]
        },
        {
            type: "column",
            name: "Budget Distribution 2019/$",
            legendText: "Budget Distribution",
            axisYType: "secondary",
            showInLegend: true,
            dataPoints: [
                { label: "EC", y: 300.00 },
                { label: "SC +", y: 300.00 },
                { label: "SC", y: 300.00 },
                { label: "SC -", y: 300.00 },
                { label: "NI", y: 300.00 },
            ]
        }]
    });
    chart.render();

    function toggleDataSeries(e) {
        if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
            e.dataSeries.visible = false;
        }
        else {
            e.dataSeries.visible = true;
        }
        chart.render();
    }

}, 600);
