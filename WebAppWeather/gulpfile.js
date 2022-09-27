/// <binding />
import gulp from "gulp"
import { path } from "./static/gulp/config/path.js";

global.app = {
    path: path,
    gulp: gulp
}

import { copy } from "./static/gulp/tasks/copy.js";
import { reset } from "./static/gulp/tasks/reset.js";
import { html } from "./static/gulp/tasks/html.js";
import { css } from "./static/gulp/tasks/css.js";
import { js } from "./static/gulp/tasks/js.js"
import { images } from "./static/gulp/tasks/images.js";

function watcher(){
    gulp.watch(path.watch.files, copy);
    gulp.watch(path.watch.html, html);
    gulp.watch(path.watch.css, css);
    gulp.watch(path.watch.js, js);
    gulp.watch(path.watch.images, images);
}


const mainTasts = gulp.parallel(copy, images, html, css, js);

const dev = gulp.series(reset, mainTasts, watcher);

gulp.task('default', dev);