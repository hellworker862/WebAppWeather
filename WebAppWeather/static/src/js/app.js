import { popups } from "./modules/popups.js"
import { search } from "./modules/search.js"
import { setApp } from "./modules/search.js"
import { weatherTemplate } from './pages/weather.js'
import { checkPageName } from './helpers/check-page-name.js'

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

    load()
    this.$container.addEventListener('click', this.showWeather)
  }

  async  showWeather({ target }) {
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