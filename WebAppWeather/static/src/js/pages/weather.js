// контент домашней страницы теперь является динамическим
export default {
    content: async () => {
        // получаем посты
        // возвращаем разметку
    return `
    <div class="container">
        <div class="row">
            <div class="content-group this">
                <div class="weather-box">
                    <div class="weather-box-row">
                        <div class="weather-box-column">
                            <span class="temperature">20°</span>
                            <span class="date">Сегодня</span>
                        </div>
                        <img class="weather-icon big-icon" src="./img/weather-icon/01d.svg"></img>
                    </div>
                    <div class="weather-box-row additionally weather-addition">
                        <div class="time-string">
                            <span class="time-text">Время:</span>
                            <span class="time">21:54</span>
                        </div>
                        <div class="city-string">
                            <span class="city-text">Город:</span>
                            <span class="city">Санкт-Петербург</span>
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
                                <span class="value-info">20° - ощущается как 17°</span>
                            </div>
                            <div class="item-info">
                                <div class="info-parameter">
                                    <div class="icon-info"><img src="./img/info-icon/pressure.svg" alt="капля"></div>
                                    <span class="title-info additionally">Давление</span>
                                </div>
                                <span class="value-info">20° - ощущается как 17°</span>
                            </div>
                            <div class="item-info">
                                <div class="info-parameter">
                                    <div class="icon-info"><img src="./img/info-icon/precipitation.svg" alt="осадки"></div>
                                    <span class="title-info additionally">Осадки</span>
                                </div>
                                <span class="value-info">20° - ощущается как 17°</span>
                            </div>
                            <div class="item-info">
                                <div class="info-parameter">
                                    <div class="icon-info"><img src="./img/info-icon/wind.svg" alt="ветер"></div>
                                    <span class="title-info additionally">Ветер</span>
                                </div>
                                <span class="value-info">20° - ощущается как 17°</span>
                            </div>
                        </ul>
                <div class="info-bg">
                    <img src="./img/cloud-bg.png" alt="Задний фон облака">
                </div>
            </div>
        </div>
    </div>`
    },
    url: `weather`,
}