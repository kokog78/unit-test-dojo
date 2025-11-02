<?php

namespace App;

use \InvalidArgumentException;

/**
 * Jelszó ellenőrzésére szolgáló osztályka.
 * A verify() metódus kap egy jelszót, amit ellenőriz.
 * Ha az alábbi feltételek közül bármelyik NEM teljesül, akkor InvalidArgumentException-t dob.
 *
 * <ul>
 * <li>A jelszó nem null.</li>
 * <li>A jelszó legalább 8 karakter hosszú.</li>
 * <li>A jelszó tartalmaz legalább egy számot.</li>
 * <li>A jelszó tartalmaz legalább egy kisbetűt.</li>
 * <li>A jelszó tartalmaz legalább egy nagybetűt.</li>
 * </ul>
 */
class PasswordVerifier
{
    /**
     * Ellenőrzi a jelszót a fenti szabályok alapján.
     *
     * @param string|null $password A jelszó, amit ellenőrizni kell.
     *
     * @throws InvalidArgumentException Ha a jelszó érvénytelen.
     * @return void
     */
    public function verify(?string $password): void {
       
    }
}