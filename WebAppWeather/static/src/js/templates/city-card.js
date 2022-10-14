// функция также возвращает объект с содержимым и адресом страницы
export const cityCardTemplate = (weather) => ({
    content: `
    <article class="card city-card" data-url="weather#${weather.id}">
        <img src="../img/weather-icon/${weather.weather.icon}.svg"
        alt="Иконка погоды" class="weather-icon"><span class="temperature">${
            weather.weather.main.temperature < 0 ? weather.weather.main.temperature : '+' + weather.weather.main.temperature
        }°</span><span
        class="type-weather additionally">${weather.weather.weatherName}</span>
        <h3 class="name-city">${weather.cityName}</h3>
    </article>
    `,
    // обратите внимание на то, как мы указываем номер поста
    // если мы сделаем так: `post/${id}`, то корневая директория изменится на post
    // и сервер после перезагрузки страницы не сможет установить соединение
    // существуют и другие подходы к решению указанной проблемы
    url: `card#${weather.id}`,
})