import * as nodePath from 'path';
const rootFolder = nodePath.basename(nodePath.resolve());

const buildFolder = `./wwwroot`;
const srcFolder = `./static/src`;

export const path = {
    build: {
        js: `${buildFolder}/js/`,
        images: `${buildFolder}/img/`,
        html: `${buildFolder}/`,
        files: `${buildFolder}/files/`,
        css: `${buildFolder}/css/`
    },
    src: {
        js: `${srcFolder}/js/app.js`,
        images: `${srcFolder}/img/**/*.{jpg,jpeg,png,gif,webp,ico,svg}`,
        html: `${srcFolder}/*.html`,
        files: `${srcFolder}/files/**/*.*`,
        css: `${srcFolder}/css/**/*.css`
    },
    watch: {
        js: `${srcFolder}/js/**/*.js`,
        images: `${srcFolder}/img/**/*.{jpg,jpeg,png,gif,webp,ico,svg}`,
        html: `${srcFolder}/**/*.html`,
        files: `${srcFolder}/files/**/*.*`,
        css: `${srcFolder}/css/**/*.css`
    },
    clean: buildFolder,
    buildFolder: buildFolder,
    srcFolder: srcFolder,
    rootFolder: rootFolder
}