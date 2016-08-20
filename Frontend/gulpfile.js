var gulp = require('gulp');
var browserSync = require('browser-sync').create();


gulp.task('serve', function() {
    browserSync.init({
        server: "./app"
    });

    //gulp.watch("app/scss/*.scss", ['sass']);
    gulp.watch("app/*.html").on('change', browserSync.reload);
});

/* 
gulp.task('webserver', function() {
  gulp.src('app')
    .pipe(webserver({
      livereload: {
        enable: true, 
        filter: function(fileName) {
          if (fileName.match(/.map$/)) { 
            return false;
          } else {
            return true;
          }
        }
      },
      directoryListing: false,
      open: true
    }));
});
*/
