export const forecastCardTemplate = (forecast) => ({
    content: `
        <article class="card forecast-card"  data-stuff='["${forecast.temperature}", "${forecast.feelsLike }", "${forecast.pressure}", "${forecast.humidity}", "${forecast.wind.speed}", "${forecast.wind.direction}", "${forecast.wind.gustDescription}"]'>
            <span class="week-day">${forecast.weekDay}</span>
            <span class="date additionally">${forecast.data}</span>
            <img src="../img/weather-icon/${forecast.icon}.svg"
            alt="Иконка погоды" class="weather-icon forecast-icon">
            <span class="temperature-max">${
                forecast.maxTemperature < 0 ? forecast.maxTemperature : '+' + forecast.maxTemperature
            }°</span>
            <span class="temperature-min additionally">${
                forecast.minTemperature < 0 ? forecast.minTemperature : '+' + forecast.minTemperature
            }°</span>
            <span class="type-weather additionally">${forecast.weatherName}</span>
        </article>
    `,
    data: forecast
})