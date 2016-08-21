var gulp = require('gulp');
var browserSync = require('browser-sync').create();
var inject = require('gulp-inject');


gulp.task('watch-css', function() {
    return gulp.src("./src/styles/*.css")
        .pipe(gulp.dest("./src/styles"))
        .pipe(browserSync.stream());
});

gulp.task('watch-js', function() {
    browserSync.reload();
});

gulp.task('inject', function() {
    return gulp.src('./src/index.html')
        .pipe(inject(gulp.src(['./src/**/*.js', './src/**/*.css'], {read: false}), {ignorePath: 'src'}))
        .pipe(gulp.dest('./src'));
});

gulp.task('serve', ['inject'], function() {
    browserSync.init({
        server: "./src"
    });

    gulp.watch("src/app/**/*.js", ['watch-js']);
    gulp.watch("src/styles/*.css", ['watch-css']);
    gulp.watch("src/**/*.html").on('change', browserSync.reload);
});

