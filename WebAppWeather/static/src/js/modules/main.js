import { getCurrentWeatherList } from './weather.js'

const main = document.querySelector('.main');

if (main) {
    ((async () => {
        const result = await getCurrentWeatherList(524894, 498817, 1486209, 1496747, 2013348);

        for (let i = 0; i < result.length; i++)
            addCard(result[i]);
    })());
}

function addCard(weather) {
    console.log(weather)
    const divCard = document.createElement('div');
    divCard.setAttribute('class', 'card city-card');

    const img = document.createElement('img');
    img.setAttribute('src', `../img/weather-icon/${weather.weather[0].icon}.svg`);
    img.setAttribute('alt', 'Иконка погоды');
    img.setAttribute('class', 'weather-icon')

    const temp = document.createElement('span');
    temp.setAttribute('class', 'temperature');

    let temperature = Math.round(weather.main.temperature)
    if (temperature >= 0)
        temperature = '+' + temperature + '°';
    else {
        temperature = temperature + '°';
    }

    temp.append(temperature);

    const type = document.createElement('span');
    type.setAttribute('class', 'type-weather additionally');
    type.append(weather.weather[0].description);

    const city = document.createElement('h3');
    city.setAttribute('class', 'name-city');
    city.append(weather.name);

    divCard.append(img, temp, type, city)
    const container = document.querySelector('#cards-container');
    container.append(divCard)
}