module.exports = function(config) {
    config.set({
        basePath: '',
        browsers: ['Chrome'],
        frameworks: ['browserify', 'jasmine'],
        plugins: [
            'karma-jasmine',
            'karma-chrome-launcher',
            'karma-browserify'
        ],
        reporters: ['progress'],
        files: [
            'src/**/*.js'
        ],
        preprocessors: {
            'src/**/*.js': ['browserify']
        },
        port: 9876,
        colors: true,
        logLevel: config.LOG_INFO,
        autoWatch: true,
        singleRun: false,
        concurrency: Infinity
    });
};