<?php

namespace App;

use Abraham\TwitterOAuth\TwitterOAuth;
use Abraham\TwitterOAuth\TwitterOAuthException;
use InvalidArgumentException;

class TwitterClient
{
    // az alkalmazásunk azonosítója a twitter rendszerében
    private string $consumerKey;

    // az alkalmazásunk jelszava a twitter rendszerében
    private string $consumerSecret;

    // Access Token
    private string $accessToken;

    // Access Token Secret
    private string $accessTokenSecret;

    /**
     * @throws \Exception Ha a 'twitter-auth.ini' fájl nem található vagy olvashatatlan.
     */
    public function __construct()
    {
        $authProps = parse_ini_file(__DIR__ . '/twitter-auth.ini');
        if ($authProps === false) {
            throw new \Exception("Hiba: A twitter-auth.ini fájl nem található.");
        }

        $this->consumerKey = $authProps['consumerKey'];
        $this->consumerSecret = $authProps['consumerSecret'];
        $this->accessToken = $authProps['accessToken'];
        $this->accessTokenSecret = $authProps['accessTokenSecret'];
    }

    /**
     * Ezzel a metódussal ki szeretnénk tweet-elni az aznap megtett lépéseink számát.
     * A lépésszámot egy független eszközzel mérjük, a metódus paraméterként kapja.
     * Követelmények:
     * <ul>
     * <li>Negatív lépésszámot nem írunk ki, hanem InvalidArgumentException-t dobunk.</li>
     * <li>Ha a lépésszám 0, akkor írjuk ki, hogy "Ma nem léptem egyet sem."</li>
     * <li>Ha a lépésszám pozitív, akkor írjuk ki: "A mai lépéseim száma: ", és a lépésszámot fűzzük utána.</li>
     * <li>Minden üzenet végére tegyük oda az aktuális dátumot YYYY-MM-dd formában.</li>
     * <li>Mielőtt közzétennénk az új státuszüzenetet, ellenőrizzük, hogy egyedi-e! Ha már van olyan üzenet, akkor dobjunk InvalidArgumentException-t.</li>
     * <li>Mielőtt közzétennénk az új státuszüzenetet, töröljük ki azokat a korábbiakat, amik ugyanerre a napra szólnak!</li>
     * </ul>
     * A tweet-eléshez használjuk a TwitterOAuth::post() metódust.
     * Az üzenetek lekérdezéséhez használjuk a TwitterOAuth::get() metódust.
     *
     * @param int $todaySteps az adott napon megtett lépések száma
     * @throws TwitterOAuthException Ha hálózati hiba történik
     * @throws InvalidArgumentException Ha az üzleti logika sérül
     */
    public function tweetSteps(int $todaySteps): void
    {
        // TODO: implementálni ezt a metódust a fenti szabályok szerint
        $twitter = $this->newTwitter();
        $twitter->post('statuses/update', ['status' => "Test: " . $todaySteps]);
        $tweets = $twitter->get('statuses/home_timeline');
        foreach ($tweets as $tweet) {
            echo $tweet->text . PHP_EOL;
        }
    }

    /**
     * Létrehoz egy új, autentikált TwitterOAuth klienst.
     */
    private function newTwitter(): TwitterOAuth
    {
        $twitter = new TwitterOAuth(
            $this->consumerKey,
            $this->consumerSecret,
            $this->accessToken,
            $this->accessTokenSecret
        );
        // A PHP könyvtárnak szüksége lehet a v1.1 API-ra az 'updateStatus'-hoz
        // $twitter->setApiVersion('1.1'); 
        return $twitter;
    }
}