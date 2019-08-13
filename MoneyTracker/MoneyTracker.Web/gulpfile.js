'use strict';
 
const gulp = require('gulp');
const sourcemaps = require('gulp-sourcemaps');
const sass = require('gulp-sass');
const cleanCSS = require('gulp-clean-css');
const rename = require('gulp-rename');
//const imagemin = require('gulp-imagemin');

sass.compiler = require('node-sass');

gulp.task('styles', function () {
  return gulp.src('./scss/**/*.scss')
    .pipe(sourcemaps.init())
    .pipe(sass.sync().on('error', sass.logError))
    .pipe(cleanCSS({compatibility: 'ie11'}))
	.pipe(gulp.dest('./Content/styles'))
    .pipe(rename({ suffix: '.min' }))
	.pipe(sourcemaps.write('.'))
    .pipe(gulp.dest('./Content/styles'));
});

gulp.task('other-css', function () {
  return gulp.src('./node_modules/normalize.css/normalize.css')
    .pipe(cleanCSS({compatibility: 'ie11'}))
    .pipe(rename({ suffix: '.min' }))
    .pipe(gulp.dest('./Content/styles'));
});
/*
gulp.task('favicons', function(){
  return gulp.src('src/images/favicons/*')
    .pipe(imagemin())
    .pipe(gulp.dest('build/images/favicons'))
});

gulp.task('images', function(){
  return gulp.src('src/images/*.*')
    .pipe(imagemin())
    .pipe(gulp.dest('build/images'))
});
*/
gulp.task('watch', function () {
    gulp.watch('./scss/**/*.scss', gulp.series(['styles']));
});

gulp.task('default', gulp.series(['styles', 'other-css']));