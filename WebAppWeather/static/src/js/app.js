import { popups} from "./modules/popups.js"
var preloader = document.querySelector('#preloader');

class App {
    #page = null
  
    constructor(container, page) {
      this.$container = container
      this.#page = page
  
      this.$nav = document.querySelector('.nav-link')
  
      this.route = this.route.bind(this)
      // привязываем метод отображения поста
      // данный метод будет вызываться при клике по посту
      this.showWeather = this.showWeather.bind(this)
  
      this.#initApp(this.#page)
    }
  
    #initApp({ url }) {
      history.replaceState({ page: `${url}` }, `${url} page`, url)
  
      this.#render(this.#page)
  
      this.$nav.addEventListener('click', this.route)
  
      window.addEventListener('popstate', async ({ state }) => {
        // получаем адрес предыдущей страницы
        const { page } = state
  
        // если адрес содержит post
        if (page.includes('post')) {
          // извлекаем идентификатор
          const id = page.replace('post#', '')
          // присваиваем текущей странице объект найденного поста
          this.#page = await findPost(id)
        } else {
          // иначе, получаем модуль поста
          const newPage = await import(`./pages/${state.page}.js`)
          // присваиваем текущей странице объект предыдущей страницы
          this.#page = newPage.default
        }
  
        this.#savePage(this.#page);
        this.#render(this.#page)
      })
    }
  
    async #render({ content }) {
      unload();
      this.$container.innerHTML =
        // проверяем, является ли контент строкой,
        // т.е. является он статическим или динамическим
        typeof content === 'string' ? content : await content()
        
      load()
      // после рендеринга регистрируем обработчик клика по посту на контейнере
      this.$container.addEventListener('click', this.showPost)
    }
  
    async route({ target }) {
      if (target.tagName !== 'A') return

      const { url } = target.dataset
      if (this.#page.url === url) return
  
      const newPage = await import(`./pages/${url}.js`)
      console.log(newPage)
      this.#page = newPage.default
  
      preloader.classList.remove('preloader-hide');
      this.#render(this.#page)
  
      this.#savePage(this.#page)
    }
  
    // метод отображения поста
    async showWeather({ target }) {
      // нас интересуте только клик по посту
      // помните эту строку в стилях: div > article > * { pointer-events: none; } ?
      // это позволяет сделать так, чтобы элементы, вложенные в article,
      // не были кликабельными, т.е. не являлись e.target
      if (target.tagName !== 'ARTICLE') return
  
      // присваиваем текущей странице объект найденного поста
      this.#page = await findPost(target.id)
  
      this.#render(this.#page)
  
      this.#savePage(this.#page)
    }
  
    #savePage({ url }) {
      history.pushState({ page: `${url}` }, `${url} page`, url)
  
      localStorage.setItem('pageName', JSON.stringify(url))
    }
  };
  
  (async () => {
    const container = document.querySelector('main')
  
    const pageName = JSON.parse(localStorage.getItem('pageName')) ?? 'home'
  
    let pageToRender = ''
  
    // содержит ли название страницы слово "post" и т.д.
    // см. обработку popstate
    if (pageName.includes('post')) {
      const id = pageName.replace('post#', '')
  
      pageToRender = await findPost(id)
    } else {
      const pageModule = await import(`./pages/${pageName}.js`)
  
      pageToRender = pageModule.default
    }
    new App(container, pageToRender)
  })()

function load(){
  preloader.classList.add('preloader-hide');
  setTimeout(function() {
    preloader.style.display='none'
  }, 595)
}

function unload() {
  preloader.classList.remove('preloader-hide');
  preloader.style.display='block'
}