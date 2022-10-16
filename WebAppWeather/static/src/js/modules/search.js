import { findCity } from '../modules/weather.js'
import { searchItemTemplate } from '../templates/search-item.js'
import { checkPageName } from '../helpers/check-page-name.js'
import { App } from '../app.js'

const searchLinks = document.querySelectorAll('.search');
const box = document.querySelector('.values-box');
var app;

if (searchLinks.length > 0) {
    for (let index = 0; index < searchLinks.length; index++) {

        const searchLink = searchLinks[index];
        searchLink.addEventListener('input', () => {
            box.innerHTML = "";

            if(searchLink.value.trim().length > 0) {

                (async () => {
                    const cities = await findCity(searchLink.value);

                    for (let index = 0; index < cities.length; index++) {
                        box.innerHTML += searchItemTemplate(cities[index]).content;
                    }

                    const searchItemLinks = document.querySelectorAll('.search-item');
                    if (searchItemLinks.length > 0) {
                        for (let index = 0; index < searchItemLinks.length; index++) {
                            const searchItemLink = searchItemLinks[index];
                            searchItemLink.addEventListener('click', ({ target }) => {
                                
                                if (target.tagName !== 'ARTICLE') return

                                (async() => {
                                app.page = await checkPageName(target.dataset.url)

                                app.render(app.page)
                                app.savePage(app.page)
                                })()
                            })
                        }
                    }
                })()
            }
        });
    }
}

export function setApp(newApp){
    app = newApp;
}
