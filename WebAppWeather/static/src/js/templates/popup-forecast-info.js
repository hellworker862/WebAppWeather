export const infoForecastTemplate = ([temperature, feelsLike, pressure, humidity, speed, direction, gustDescription]) => ({
    content: `
    <div class="content-group this-info">
                        <ul class="title-info">
                                <div class="item-info">
                                    <div class="info-parameter">
                                        <div class="icon-info"><img src="./img/info-icon/temp.svg" alt="термометер"></div>
                                        <span class="title-info additionally">Температура</span>
                                    </div>
                                    <span class="value-info">
                                        ${temperature}° - ощущается как ${feelsLike}°
                                    </span>
                                </div>
                                <div class="item-info">
                                    <div class="info-parameter">
                                        <div class="icon-info"><img src="./img/info-icon/pressure.svg" alt="капля"></div>
                                        <span class="title-info additionally">Давление</span>
                                    </div>
                                    <span class="value-info">${pressure} мм ртутного столба</span>
                                </div>
                                <div class="item-info">
                                    <div class="info-parameter">
                                        <div class="icon-info"><img src="./img/info-icon/precipitation.svg" alt="влажность"></div>
                                        <span class="title-info additionally">Влажность воздуха</span>
                                    </div>
                                    <span class="value-info">${humidity}%</span>
                                </div>
                                <div class="item-info">
                                    <div class="info-parameter">
                                        <div class="icon-info"><img src="./img/info-icon/wind.svg" alt="ветер"></div>
                                        <span class="title-info additionally">Ветер</span>
                                    </div>
                                    <span class="value-info">${speed} м/с ${direction} - ${gustDescription}</span>
                                </div>
                            </ul>
                    </div> `
})