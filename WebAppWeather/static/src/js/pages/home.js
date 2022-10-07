import {cityCardTemplate} from '../templates/city-card.js'
import {getCurrentWeatherList} from '../modules/weather.js'

export default {
  content: async () => {
    const weathers = await getCurrentWeatherList(524894, 498817, 1486209, 1496747, 2013348);
    return `

    <div class="container">
    <div class="content-group">
        <h2 class="group-title title">Основные города России</h2>
        <div id="cards-container" class="group-cards">
            ${weathers.reduce((html, weather) => (html+= cityCardTemplate(weather).content), '')}
        </div>
    </div>`
  },
  url: 'home',
}