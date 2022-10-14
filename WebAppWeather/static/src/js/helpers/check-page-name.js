export const checkPageName = async (pageName) => {
    let pageToRender = ''
    console.log('pageName', pageName)

    if (pageName.includes('weather')) {
        const id = pageName.replace('weather#', '')
        const pageModule = await import(`../pages/weather.js`)

        pageToRender = pageModule.default(id)
    } else {
        const pageModule = await import(`../pages/${pageName}.js`)

        pageToRender = pageModule.default
    }

    return pageToRender
}