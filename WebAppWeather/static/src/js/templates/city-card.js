// функция также возвращает объект с содержимым и адресом страницы
export const cityCardTemplate = (weather) => ({
    content: `
    <article class="card city-card" id="${weather.id}">
        <img src="../img/weather-icon/${weather.weather[0].icon}.svg"
        alt="Иконка погоды" class="weather-icon"><span class="temperature">${
            weather.main.temperature < 0 ? Math.round(weather.main.temperature): '+' + Math.round(weather.main.temperature)
        }°</span><span
        class="type-weather additionally">${weather.weather[0].description}</span>
        <h3 class="name-city">${weather.name}</h3>
    </article>
    `,
    // обратите внимание на то, как мы указываем номер поста
    // если мы сделаем так: `post/${id}`, то корневая директория изменится на post
    // и сервер после перезагрузки страницы не сможет установить соединение
    // существуют и другие подходы к решению указанной проблемы
    url: `card#${weather.id}`,
})