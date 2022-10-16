export const searchItemTemplate = (city) => ({
    content: `
    <article class="search-item" data-url="weather#${city.id}">
        <span class="seacrh-city">${city.ruName}</span>
        <span class="seacrh-place additionally dop">${city.region.ruName}</span>
        <span class="seacrh-country additionally dop">${city.region.country.ruName}</span>
    </article>`
})