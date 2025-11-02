<?php

namespace App;

/**
 * Ezt az osztályt arra használjuk, hogy konfigurációs fájlokban megadott
 * verziószámokkal tudjunk műveleteket megadni. Egyrészről össze szeretnénk hasonlítani
 * két verziószámot - erre való a compareTo(ComparableVersion) metódus.
 * Másrészről az egyes verziószámokat engedélyezni vagy tiltani szeretnénk - erre való
 * a setEnabled(bool) ill. az isEnabled() metódus.
*/
class ComparableVersion
{
    /**
     * @var int[] A verziószám részei, pl. "1.2.3" -> [1, 2, 3]
     */
    private array $parts;

    /**
     * @var array<string, bool> Az engedélyezett verziókat tárolja.
     * A kulcs a verzió string (pl. "1.10.2"), az érték pedig simán `true`.
     * Ez egy "Set" implementáció PHP-s asszociatív tömbbel.
     */
    private static array $enabledVersions = [];

    public function __construct(string $version)
    {
        $this->parts = $this->createParts($version);
    }

    /**
     * Összehasonlítja ezt az objektumot egy másikkal.
     *
     * @return int < 0, ha $this < $other
     * @return int 0, ha $this == $other
     * @return int > 0, ha $this > $other
     */
    public function compareTo(ComparableVersion $other): int
    {
        $limit = min(count($this->parts), count($other->parts));
        for ($i = 0; $i < $limit; $i++) {
            $currentResult = $this->parts[$i] - $other->parts[$i];
            if ($currentResult !== 0) {
                return $currentResult;
            }
        }
        return count($this->parts) - count($other->parts);
    }

    /**
     * Ellenőrzi, hogy két verzió megegyezik-e.
     */
    public function equals(mixed $other): bool
    {
        if (!($other instanceof ComparableVersion)) {
            return false;
        }
        return $this->compareTo($other) === 0;
    }

    /**
     * PHP "mágikus" metódus. Akkor hívódik meg, ha az objektumot stringként
     * próbáljuk használni (pl. echo $ver; vagy egy tömb kulcsaként).
     */
    public function __toString(): string
    {
        return implode('.', $this->parts);
    }

    /**
     * A verziószám engedélyezett?
     */
    public function isEnabled(): bool
    {
        return isset(self::$enabledVersions[(string)$this]);
    }

    /**
     * Engedélyezi vagy tiltja a verziószámot.
     */
    public function setEnabled(bool $enabled): void
    {
        $key = (string)$this;
        if ($enabled) {
            self::$enabledVersions[$key] = true;
        } else {
            unset(self::$enabledVersions[$key]);
        }
    }

    /**
     * A verzió stringet felbontja egy számokból álló tömbre.
     * @return int[]
     */
    private function createParts(string $version): array
    {
        $partsArray = explode('.', $version);
        return array_map('intval', $partsArray);
    }

    /**
     * [CSAK TESZTELÉSHEZ] Visszaállítja az engedélyezett verziók listáját.
     *
     * Mivel a `$enabledVersions` statikus, a tesztek között "koszos" maradhat.
     * Ezt a metódust a PHPUnit tesztjeid `tearDown()` vagy `setUp()`
     * metódusában hívd meg, hogy tiszta lappal indulj.
     */
    public static function resetEnabledVersions(): void
    {
        self::$enabledVersions = [];
    }
}