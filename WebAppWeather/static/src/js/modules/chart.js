var lineChart;


export async function renderChart(chart, type, range) {

    if(lineChart!=null) {
        lineChart.destroy();
    }

    switch (type) {
        case "temperature":
            await createTemperatyreChart(chart, window.globalVar, range);
            break;
        case "pressure":
            await createPressureChart(chart, window.globalVar, range);
            break;
        case "humidity":
            await createHumidityChart(chart, window.globalVar, range);
            break
    }
}

async function createTemperatyreChart(chart, data, range) {

    let temperature, chartRange;

    switch (range) {
        case "day":
            temperature = data.daysForecasts.map(item => item.temperature);
            chartRange = data.daysForecasts.map(item => item.weekDay);
            break;
        case "hour":
            temperature = data.weathers.map(item => item.main.temperature);
            chartRange = data.weathers.map(item => item.dateTimeString);
            break;
    }

    const dataT = {
        label: "Температура, С°",
        data: temperature,
        lineTension: 0.3,
        backgroundColor: 'rgba(255, 99, 132, 0.2)',
        borderColor: 'rgb(255, 99, 132)',
        pointBackgroundColor: 'rgb(255, 99, 132)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgb(255, 99, 132)',
        fill: true
    };

    var chartData = {
        labels: chartRange,
        datasets: [dataT]
    };

    lineChart = new Chart(chart, {
        type: 'line',
        data: chartData,
        options: {
            maintainAspectRatio: false,
        }
    });
}

async function createPressureChart(chart, data, range) {

    let pressure, chartRange;

    switch (range) {
        case "day":
            pressure = data.daysForecasts.map(item => item.pressure);
            chartRange = data.daysForecasts.map(item => item.weekDay);
            break;
        case "hour":
            pressure = data.weathers.map(item => item.main.pressure);
            chartRange = data.weathers.map(item => item.dateTimeString);
            break;
    }

    const dataT = {
        label: "Давление, мм рт. ст.",
        data: pressure,
        lineTension: 0.3,
        backgroundColor: 'rgba(54, 162, 235, 0.2)',
        borderColor: 'rgb(54, 162, 235)',
        pointBackgroundColor: 'rgb(54, 162, 235)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgb(54, 162, 235)',
        fill: true
    };

    var chartData = {
        labels: chartRange,
        datasets: [dataT]
    };

    lineChart = new Chart(chart, {
        type: 'line',
        data: chartData,
        options: {
            maintainAspectRatio: false,
        }
    });
}

async function createHumidityChart(chart, data, range) {

    let humidity, chartRange;

    switch (range) {
        case "day":
            humidity = data.daysForecasts.map(item => item.humidity);
            chartRange = data.daysForecasts.map(item => item.weekDay);
            break;
        case "hour":
            humidity = data.weathers.map(item => item.main.humidity);
            chartRange = data.weathers.map(item => item.dateTimeString);
            break;
    }

    const dataT = {
        label: "Влажность, %",
        data: humidity,
        lineTension: 0.3,
        backgroundColor: 'rgba(75, 192, 192, 0.2)',
        borderColor: 'rgb(75, 192, 192)',
        pointBackgroundColor: 'rgb(75, 192, 192)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgb(75, 192, 192)',
        fill: true
    };

    var chartData = {
        labels: chartRange,
        datasets: [dataT]
    };

    lineChart = new Chart(chart, {
        type: 'line',
        data: chartData,
        options: {
            maintainAspectRatio: false,
        }
    });
}