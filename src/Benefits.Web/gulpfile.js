/// <binding AfterBuild='default' Clean='clean' />

var gulp = require('gulp'),
    del = require('del'),
    $ = require('gulp-load-plugins')({ lazy: true });

var webroot = "wwwroot/";

var paths = {
    css: webroot + "css/site.css",
    cssDest: webroot + "css/site.min.css",
    typeScript: ['scripts/**/*.js', 'scripts/**/*.ts', 'scripts/**/*.map'],
    typeScriptDest: webroot + 'scripts'
};

gulp.task('clean', function () {
    return del(['wwwroot/scripts/**/*']);
});

gulp.task("min:css", function () {
    return gulp.src(paths.css)
        .pipe($.cssmin())
        .pipe($.rename(paths.cssDest))
        .pipe(gulp.dest("./"));
});

gulp.task('copy:ts', function () {
    return gulp.src(paths.typeScript)
        .pipe(gulp.dest(paths.typeScriptDest));
});

var build = gulp.series(["min:css","copy:ts"]);

gulp.task('default', build);