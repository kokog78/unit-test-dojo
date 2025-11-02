<?php

namespace App;

class PathResolver
{
    /**
     * Egy abszolút útvonalat egységes formába alakít, eltávolítja belőle a `.` és a `..`
     * útvonal-részeket. Az egyes útvonal-részeket a `/` karakter választja el egymástól. A `.`
     * útvonal-rész nem változtatja meg az aktuális útvonalat. A `..` útvonal-rész hatására az aktuális
     * útvonal egy szinttel feljebb kerül.
     * @param string $absolutePath egy abszolút útvonal
     * @return string egységes formába alakított útvonal
     */
    public function normalize(string $absolutePath): ?string
    {
        return null;
    }

    /**
     * Egyesíti a két paraméterben megadott útvonalakat és egységes formára hozza az eredményt. Mindkét útvonal esetén
     * kezeli a `.` és a `..` útvonal-részeket.
     * @param string $absolutePath egy abszolút útvonal
     * @param string $relativePath egy relatív útvonal
     * @return string az egyesített és egységes formába alakított útvonal
     */
    public function resolve(string $absolutePath, string $relativePath): ?string
    {
        return null;
    }
}