import {findWeather} from '../modules/weather.js'

export default function(id) {
    return {
        content: async () => {
            const weather = await findWeather(id);
         return   `
        <div class="container">
            <div class="row">
                <div class="content-group this">
                    <div class="weather-box">
                        <div class="weather-box-row">
                            <div class="weather-box-column">
                                <span class="temperature">
                                    ${weather.weather.main.temperature < 0 ? weather.weather.main.temperature : '+' + weather.weather.main.temperature}
                                    °</span>
                                <span class="date">Сегодня</span>
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
        </div>`},
        url: `weather#${id}`
    }
}