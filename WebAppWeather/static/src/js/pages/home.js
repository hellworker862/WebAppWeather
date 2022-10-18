import { cityCardTemplate } from '../templates/city-card.js'
import { getCurrentWeatherList } from '../modules/weather.js'

export default {
  content: async () => {
    const weathers = await getCurrentWeatherList([524894, 498817, 1486209, 1496747, 2013348]);

    const favorites = await getCurrentWeatherList(JSON.parse(localStorage.getItem("favorites")) ?? []);

    let form;

    if(typeof favorites === 'undefined') {
      form = '<span class="none-cards">У вас неты избранных</div>';
    }
    else {
      form = favorites.reduce((html, weather) => (html += cityCardTemplate(weather).content), '')
    }
    return `

    <div class="container">
      <div class="content-group">
        <h2 class="group-title title">Основные города России</h2>
        <div id="cards-container" class="group-cards">
            ${weathers.reduce((html, weather) => (html += cityCardTemplate(weather).content), '')}
        </div>
      </div>

      <div class="content-group favorites-group">
        <h2 class="group-title title">Избранное</h2>
        <div id="cards-container" class="favorites-cards">
            ${form}
        </div>
      </div>
    </div>`
  },
  url: 'home',
}