// импортируем генератор шаблона поста
import { weatherPage } from '../pages/weather.js'

export const findWeather = async (id) => {
  return weatherPage(id)
}