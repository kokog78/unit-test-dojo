<?php

namespace App;

class MarsRoverNavigation
{
    /**
     * Navigációs metódus a marsjáróhoz.
     *
     * @param string $zoneSize a zóna mérete, két egész szám egymástól egy szóközzel elválasztva
     * @param string $startingFrom a kiindulási pozíció, két egész szám és egy nagybetű, egymástól szóközökkel elválasztva
     * @param string $commands a végrehajtandó parancsok, több nagybetű egymás után
     * @return string a végső pozíció, két egész szám és egy nagybetű, egymástól szóközökkel elválasztva
     */
    public function navigate(string $zoneSize, string $startingFrom, string $commands): ?string 
    {
        return null;
    }
}