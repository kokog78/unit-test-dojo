// Karma configuration

module.exports = function (config) {
	config.set({
		// base path that will be used to resolve all patterns (eg. files, exclude)
		basePath: "",

		frameworks: ["jasmine"],

		// list of files / patterns to load in the browser
		files: [
			{ pattern: "karma-init.js" },
            { pattern: "dist/**/*", included: false } //Only serve but do not include by default (loaded by karma-init.js)
		],

		// list of files to exclude
		exclude: [
			'dist/test/javascript/*'
		],

		preprocessors: {
			"dist/**/*.js": ["babel"]  // Needed to instrument the code using babel-plugin-istanbul
		},

		reporters: [
			"progress",
			"coverage",
			"karma-remap-istanbul" // Needed to map coverage report back to source using sourcemaps
		],

		babelPreprocessor: {
			options: {
				plugins: [
					[
						"istanbul", // Comment out to enable/disable coverage
						{
							exclude: [
								"dist/test/**/*"
							]
						}
					]
				]
			}
		},

		coverageReporter: {
			type: "in-memory" // in-memory as remapIstanbul will output the html report
		},

		remapIstanbulReporter: {
			reports: {
				html: 'coverage'
			}
		},

		// web server port
		port: 9876,

		// enable / disable colors in the output (reporters and logs)
		colors: true,

		// level of logging
		// possible values: config.LOG_DISABLE || config.LOG_ERROR || config.LOG_WARN || config.LOG_INFO || config.LOG_DEBUG
		logLevel: config.LOG_INFO,

		// enable / disable watching file and executing tests whenever any file changes
		autoWatch: true,

		// start these browsers
		// available browser launchers: https://npmjs.org/browse/keyword/karma-launcher
		browsers: ["Chrome"],

		// Continuous Integration mode
		// if true, Karma captures browsers, runs the tests and exits
		// singleRun: true,

		// Concurrency level
		// how many browser should be started simultaneous
		concurrency: Infinity
	});
};
