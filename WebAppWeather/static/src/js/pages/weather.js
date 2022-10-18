import {findForecast, findWeather} from '../modules/weather.js'
import { forecastCardTemplate } from '../templates/forecast-card.js';


export default function(id) {
    return {
        content: async () => {
            const weather = await findWeather(id);
            const forecast = await findForecast(id);

            let favorites = JSON.parse(localStorage.getItem("favorites")) ?? [];
            let src;

            if(favorites.includes(id)) {
                src="../img/star1.svg"
            } else {
                src="../img/star0.svg"
            }

            window.globalVar = forecast;

         return   `
        <div class="container">
            <div class="row">
                <div class="content-group this">
                    <div class="weather-box">
                    <button class="button-favorite" data-id="${id}">
                        <img src="${src}" alt="кнопка фаворита">
                    </button>
                        <div class="weather-box-row">
                            <div class="weather-box-column">
                                <span class="temperature">
                                    ${weather.weather.main.temperature < 0 ? weather.weather.main.temperature : '+' + weather.weather.main.temperature}°</span>
                                <span class="date-title">Сегодня</span>
                            </div>
                            <img class="weather-icon big-icon" src="./img/weather-icon/${weather.weather.icon}.svg"></img>
                        </div>
                        <div class="weather-box-row additionally weather-addition">
                            <div class="time-string">
                                <span class="time-text">Время:</span>
                                <span class="time">${weather.timeString}</span>
                            </div>
                            <div class="city-string">
                                <span class="city-text">Город:</span>
                                <span class="city">${weather.cityName}</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content-group this-info">
                <ul class="title-info">
                                <div class="item-info">
                                    <div class="info-parameter">
                                        <div class="icon-info"><img src="./img/info-icon/temp.svg" alt="термометер"></div>
                                        <span class="title-info additionally">Температура</span>
                                    </div>
                                    <span class="value-info">
                                        ${weather.weather.main.temperature}° - ощущается как ${weather.weather.main.feelsLike}°
                                    </span>
                                </div>
                                <div class="item-info">
                                    <div class="info-parameter">
                                        <div class="icon-info"><img src="./img/info-icon/pressure.svg" alt="капля"></div>
                                        <span class="title-info additionally">Давление</span>
                                    </div>
                                    <span class="value-info">${weather.weather.main.pressure} мм ртутного столба</span>
                                </div>
                                <div class="item-info">
                                    <div class="info-parameter">
                                        <div class="icon-info"><img src="./img/info-icon/precipitation.svg" alt="влажность"></div>
                                        <span class="title-info additionally">Влажность воздуха</span>
                                    </div>
                                    <span class="value-info">${weather.weather.main.humidity}%</span>
                                </div>
                                <div class="item-info">
                                    <div class="info-parameter">
                                        <div class="icon-info"><img src="./img/info-icon/wind.svg" alt="ветер"></div>
                                        <span class="title-info additionally">Ветер</span>
                                    </div>
                                    <span class="value-info">${weather.weather.wind.speed} м/с ${weather.weather.wind.direction} - ${weather.weather.wind.gustDescription}</span>
                                </div>
                            </ul>
                    <div class="info-bg">
                        <img src="./img/cloud-bg.png" alt="Задний фон облака">
                    </div>
                </div>
            </div>
            <div class="content-group forecast">
                <h2 class="group-title title">Прогноз погоды на 5 дней</h2>
                <div id="cards-container" class="group-cards">
                    ${
                        forecast.daysForecasts.reduce((html, weather) => (html+= forecastCardTemplate(weather).content), '')
                    }
                </div>
            </div>

            <div class="charts-settings">
                <div class="fieldset fieldset-type">
                    <div class="form_radio_btn">
                        <input class="item-settings" type="radio" value="temperature" id="temperature" name="group-type" checked >
                        <label for="temperature">Температура</label>
                    </div>
                    <div class="form_radio_btn">
                        <input class="item-settings" type="radio" value="pressure" id="pressure" name="group-type">
                        <label for="pressure">Давление</label>
                    </div>
                    <div class="form_radio_btn">
                        <input class="item-settings" type="radio" value="humidity" id="humidity" name="group-type">
                        <label for="humidity">Влажность</label>
                    </div>
                </div>
                <div class="fieldset fieldset-range">
                    <div class="form_radio_btn">
                        <input class="item-settings" type="radio" value="day" id="day" name="group-range" checked>
                        <label for="day">По дням</label>
                    </div>
                    <div class="form_radio_btn">
                        <input class="item-settings" type="radio" value="hour" id="hour" name="group-range">
                        <label for="hour">По 3 часа</label>
                    </div>
                </div>
            </div>

            <div class="content-group charts">
                <canvas id="chart">
                </canvas>
            </div>
        </div>
        <div id="popup-info" class="popup">
            <div class="popup-body">
                <div class="popup-content">

                </div>
            </div>
        </div>`
    },
        url: `weather#${id}`
    }
}