/*
Karma initializer for code using ECMAScript Modules.

How does it work:

- Prevents karma from autostarting after "load" event.
- Manually scans all `karma.files` and filters to only load "*Spec.js" and "*spec.js" files.
- Loads spec files one after another so the order of the files will not change between executions.
- Starts karma

*/
(function () {
	const karma = window.__karma__;
	karma.loaded = function() {
	};

	async function loadFiles() {
		const specFiles = Object.keys(karma.files)
			.filter((p) => /[sS]pec\.js$/.test(p));

		for (const specFile of specFiles) {
			await import(specFile);
		}
	}

	async function startKarma() {
		try {
			await loadFiles();
			karma.start();
		} catch (err) {
			karma.error(err.stack || err);
		}
	}

	document.addEventListener("DOMContentLoaded", startKarma);
})();
