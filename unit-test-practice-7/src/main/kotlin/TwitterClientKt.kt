package dojo

import twitter4j.Twitter
import twitter4j.TwitterFactory
import twitter4j.TwitterException
import twitter4j.auth.AccessToken
import java.io.IOException
import java.util.Properties
import java.text.SimpleDateFormat
import java.util.Date

/**
 * Ezt az osztályt arra szeretnénk majd használni, hogy konfigurációs fájlokban megadott
 * Twitter adatokkal tudjunk tweet-eket küldeni.
 */
class TwitterClientKt @Throws(IOException::class) constructor() {

    // az alkalmazásunk azonosítója a twitter rendszerében
    private val consumerKey: String

    // az alkalmazásunk jelszava a twitter rendszerében
    private val consumerSecret: String

    // Access Token
    private val accessToken: String

    // Access Token Secret
    private val accessTokenSecret: String

    private val twitterFactory: TwitterFactory

    init {
        twitterFactory = TwitterFactory()
        val authProps = Properties()
        // A try-with-resources-hoz hasonló viselkedés Kotlinban a use blokk
        this.javaClass.getResourceAsStream("twitter-auth.properties").use { stream ->
            authProps.load(stream)
        }
        consumerKey = authProps.getProperty("consumerKey")
        consumerSecret = authProps.getProperty("consumerSecret")
        accessToken = authProps.getProperty("accessToken")
        accessTokenSecret = authProps.getProperty("accessTokenSecret")
    }

    /**
     * Ezzel a metódussal ki szeretnénk tweet-elni az aznap megtett lépéseink számát.
     * A lépésszámot egy független eszközzel mérjük, a metódus paraméterként kapja.
     * Követelmények:
     * <ul>
     * <li> Negatív lépésszámot nem írunk ki, hanem [IllegalArgumentException]-t dobunk.</li>
     * <li> Ha a lépésszám 0, akkor írjuk ki, hogy "Ma nem léptem egyet sem."</li>
     * <li> Ha a lépésszám pozitív, akkor írjuk ki: "A mai lépéseim száma: ", és a lépésszámot fűzzük utána.</li>
     * <li> Minden üzenet végére tegyük oda az aktuális dátumot YYYY-MM-dd formában.</li>
     * <li> Mielőtt közzétennénk az új státuszüzenetet, ellenőrizzük, hogy egyedi-e! Ha már van olyan üzenet, akkor dobjunk [IllegalArgumentException]-t.</li>
     * <li> Mielőtt közzétennénk az új státuszüzenetet, töröljük ki azokat a korábbiakat, amik ugyanerre a napra szólnak!</li>
     * </ul>
     * A tweet-eléshez használjuk a [Twitter.updateStatus] metódust.
     * Az üzenetek lekérdezéséhez használjuk a [Twitter.getHomeTimeline] metódust.
     * @param todaySteps az adott napon megtett lépések száma
     * @throws TwitterException
     */
    @Throws(TwitterException::class)
    fun tweetSteps(todaySteps: Int) {
        if (todaySteps < 0) {
            throw IllegalArgumentException("A lépésszám nem lehet negatív.")
        }

        val twitter = newTwitter()
        val dateFormatter = SimpleDateFormat("yyyy-MM-dd")
        val currentDate = dateFormatter.format(Date())

        val message = when (todaySteps) {
            0 -> "Ma nem léptem egyet sem."
            else -> "A mai lépéseim száma: $todaySteps."
        } + " ($currentDate)"

        val timeline = twitter.homeTimeline
        timeline.filter { it.text.contains("($currentDate)") }.forEach {
            twitter.destroyStatus(it.id)
        }

        if (timeline.any { it.text == message }) {
            throw IllegalArgumentException("Ez a tweet már létezik.")
        }

        twitter.updateStatus(message)
    }

    private fun newTwitter(): Twitter {
        val twitter = twitterFactory.instance
        twitter.setOAuthConsumer(consumerKey, consumerSecret)
        twitter.oAuthAccessToken = AccessToken(accessToken, accessTokenSecret)
        return twitter
    }
}