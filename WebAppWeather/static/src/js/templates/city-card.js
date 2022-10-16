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
    url: `card#${weather.id}`,
})