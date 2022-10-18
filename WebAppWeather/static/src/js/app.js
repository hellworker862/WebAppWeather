import { popupOpen, popups, popupClose } from "./modules/popups.js"
import { search } from "./modules/search.js"
import { setApp } from "./modules/search.js"
import { checkPageName } from './helpers/check-page-name.js'
import { infoForecastTemplate } from "./templates/popup-forecast-info.js"
import { renderChart } from "./modules/chart.js"


var preloader = document.querySelector('#preloader');

export class App {
  #page = null

  constructor(container, page) {
    this.$container = container
    this.#page = page

    this.$nav = document.querySelector('.nav-link')

    this.route = this.route.bind(this)

    this.showWeather = this.showWeather.bind(this)

    this.#initApp()
  }

  #initApp() {
    const { url } = this.#page

    history.replaceState({ page: `${url}` }, `${url} page`, url)

    this.render(this.#page)

    this.$nav.addEventListener('click', this.route, { passive: true })

    window.addEventListener('popstate', async ({ state }) => {

      const pageName = state.page

      this.#page = await checkPageName(pageName)

      this.render(this.#page)
      this.savePage(this.#page);
    })
  }

  async route({ target }) {
    if (target.tagName !== 'A' && target.tagName !== 'ARTICLE') return

    const link = target.dataset.url
    if (this.#page.url === link) return

    this.#page = await checkPageName(link)

    preloader.classList.remove('preloader-hide');

    this.render(this.#page)
    this.savePage(this.#page)
  }

  async render({ content }) {
    unload();

    this.$container.innerHTML = typeof content === 'string' ? content : await content()
    this.$container.removeEventListener('click', this.showWeather)

    load()
    const page = JSON.parse(localStorage.getItem('pageName'));

    const cityCards = document.querySelectorAll('.city-card');
    const forecastCards = document.querySelectorAll('.forecast-card');
    const favorite = document.querySelector('.button-favorite');

    if (favorite) {
      favorite.addEventListener('click', this.setFavorite)
    }

    if (cityCards.length > 0) {
      cityCards.forEach(element => element.addEventListener('click', this.showWeather))
    }

    if (forecastCards.length > 0) {
      forecastCards.forEach(element => element.addEventListener('click', this.showForecast))

      forecastCards.forEach(element => element.addEventListener('click', function (e) {
        const curentPopup = document.getElementById('popup-info');
        curentPopup.addEventListener("click", function (e) {
          if (!e.target.closest('.popup-content')) {
            popupClose(e.target.closest('.popup'));
          }
        });
        popupOpen(curentPopup);
        e.preventDefault();
      }))
    }

    const chart = document.querySelector("#chart");

    if (chart) {
      await renderChart(chart, "temperature", "day");
    }

    const settingsItems = document.querySelectorAll('.item-settings');

    if(settingsItems.length > 0) {
      settingsItems.forEach(element => element.addEventListener('change', this.setChart ))
    }

  }


  async setChart() {
    const typeItem = document.querySelector('input[name="group-type"]:checked').value;
    const rangeItem = document.querySelector('input[name="group-range"]:checked').value;
    console.log(rangeItem);
    console.log(typeItem);

    if(typeItem && rangeItem) {
      const chart = document.querySelector("#chart");

      if(chart) {
        await renderChart(chart, typeItem, rangeItem);
      }
    }
  }
  

  async setFavorite({ target }) {
    let favorites = JSON.parse(localStorage.getItem("favorites")) ?? [];

    if (favorites.includes(target.dataset.id)) {
      const index = favorites.indexOf(target.dataset.id);

      if (index >= 0) {
        favorites.splice(index, 1);
      }


      localStorage.setItem("favorites", JSON.stringify(favorites))
      target.getElementsByTagName("img")[0].src = "../img/star0.svg"
    } else {
      favorites.push(target.dataset.id)
      localStorage.setItem("favorites", JSON.stringify(favorites))
      target.getElementsByTagName("img")[0].src = "../img/star1.svg"
    }
  }

  async showForecast({ target }) {
    if (target.tagName !== 'ARTICLE') return

    const popup = document.querySelector('.popup-content');

    if (popup) {
      popup.innerHTML = infoForecastTemplate(JSON.parse(target.dataset.stuff)).content;
    }
  }

  async showWeather({ target }) {
    if (target.tagName !== 'ARTICLE') return

    this.#page = await checkPageName(target.dataset.url)

    this.render(this.#page)
    this.savePage(this.#page)
  }

  savePage({ url }) {
    history.pushState({ pageName: `${url}` }, `${url} page`, url)

    localStorage.setItem('pageName', JSON.stringify(url))
  }
};

(async () => {
  const container = document.querySelector('main');
  if (localStorage.getItem('pageName') === 'undefined')
    localStorage.setItem('pageName', JSON.stringify('home'))

  const pageName = JSON.parse(localStorage.getItem('pageName')) ?? 'home';
  const pageToRender = await checkPageName(pageName)

  let app = new App(container, pageToRender)
  setApp(app);
})()

function load() {
  preloader.classList.add('preloader-hide');
  setTimeout(function () {
    preloader.style.display = 'none'
  }, 595)
}

function unload() {
  preloader.classList.remove('preloader-hide');
  preloader.style.display = 'block'
}

function applyTheme(theme) {
  document.body.classList.remove("theme-auto", "theme-light", "theme-dark");
  document.body.classList.add(`theme-${theme}`);
}

document.addEventListener("DOMContentLoaded", () => {
  const savedTheme = localStorage.getItem("theme") || "auto";

  applyTheme(savedTheme);

  const button = document.querySelector("#theme");

  button.addEventListener("click", function () {

    if ((localStorage.getItem("theme") || "auto") == "auto") {
      if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
        localStorage.setItem("theme", "light");
        applyTheme("light");
      } else {
        localStorage.setItem("theme", "dark");
        applyTheme("dark");
      }
    } else {
      if ((localStorage.getItem("theme") || "auto") == "light") {
        localStorage.setItem("theme", "dark");
        applyTheme("dark");
      } else {
        localStorage.setItem("theme", "light");
        applyTheme("light");
      }
    }
  });
});