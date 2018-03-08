const Twitter = require('twitter-node-client').Twitter;
const authData = require('./twitter-auth.json');

module.exports = function TwitterClient() {

    /**
     * Ezzel a függvénnyel ki szeretnénk tweet-elni az aznap megtett lépéseink számát.
     * A lépésszámot egy független eszközzel mérjük, a metódus paraméterként kapja.
     * Követelmények:
     * - Negatív lépésszámot nem írunk ki, hanem errorCallback-ot hívunk.
     * - Ha a lépésszám 0, akkor írjuk ki, hogy "Ma nem léptem egyet sem."
     * - Ha a lépésszám pozitív, akkor írjuk ki: "A mai lépéseim száma: ", és a lépésszámot fűzzük utána.
     * - Minden üzenet végére tegyük oda az aktuális dátumot YYYY-MM-dd formában.
     * - Mielőtt közzétennénk az új státuszüzenetet, ellenőrizzük, hogy egyedi-e! Ha már van olyan üzenet, akkor errorCallback-ot hívunk.
     * - Mielőtt közzétennénk az új státuszüzenetet, töröljük ki azokat a korábbiakat, amik ugyanerre a napra szólnak!
     * A tweet-eléshez használjuk a "twitter.postTweet()" függvényt.
     * Az üzenetek lekérdezéséhez használjuk a "twitter.getHomeTimeline()" függvényt.
     * Segítség: https://github.com/BoyCook/TwitterJSClient
     * @param todaySteps az adott napon megtett lépések száma
     */
    this.tweetSteps = function(todaySteps) {
        let twitter = new Twitter(authData);
        return new Promise((resolve, reject) => {
            twitter.getHomeTimeline({
                count: 20
            }, (error) => {
                // handle error case
                console.error(error);
                reject(error);
            }, (timelineResponseBody) => {
                let tweets = JSON.parse(timelineResponseBody);
                for (let i=0; i < tweets.length; i++) {
                    let statusMessage = tweets[i];
                    console.log(statusMessage.text);
                }
                twitter.postTweet({
                    status: `Test: ${todaySteps}`
                }, (error) => {
                    // handle error case
                    console.error(error);
                    reject(error);
                }, (tweetResponseBody) => {
                    resolve(tweetResponseBody);
                });
            });
        });
    };

};