module.exports = function(config) {
    config.set({
        basePath: '',
        browsers: ['Chrome'],
        frameworks: ['browserify', 'jasmine'],
        plugins: [
            'karma-jasmine',
            'karma-chrome-launcher',
            'karma-browserify',
            'karma-coverage'
        ],
        files: [
            'src/**/*.js'
        ],
        preprocessors: {
            'src/**/*.js': ['browserify']
        },
        reporters: ['progress', 'coverage'],
        browserify: {
            debug: true,
            transform: [
                [
                    'babelify',
                    {
                        presets: 'es2015'
                    }
                ], [
                    'browserify-istanbul',
                    {
                        instrumenterConfig: {
                            embedSource: true
                        }
                    }]
            ]
        },
        coverageReporter: {
            type : 'html',
            dir : 'coverage/'
        },
        port: 9876,
        colors: true,
        logLevel: config.LOG_INFO,
        autoWatch: true,
        singleRun: false,
        concurrency: Infinity
    });
};