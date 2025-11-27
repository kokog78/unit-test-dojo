<?php

use App\MarsRoverNavigation;

beforeEach(function () {
    // Ez a beforeEach minden teszt előtt lefut.
});

// A tesztek csoportosítása (opcionális, de segít a rendszerezésben)
describe('Value Comparison Logic', function () {

    beforeEach(function () {
        // Ez a beforeEach CSAK a 'Value Comparison Logic' tesztjei előtt fut le.
    });

    it('calculates the correct result', function () { 
        $result = 12;
        expect($result)
            ->toBe(12)
            ->toBeInt()
            ->toBeGreaterThan(0)
            ->not->toBe(0);
    });

    afterEach(function () {
        // Takarítás a csoport tesztjei után
    });


});

describe('Exception validation', function () {

    beforeEach(function () {
      // Ez a beforeEach CSAK a 'Exception validation' tesztjei előtt fut le.
    });

    it('throws exception if version string is empty', function () {
        // Itt kell meghívni az ellenőrizendő függvényt: Foo::bar('');
        throw new InvalidArgumentException("Hiba üzenet");
    })->throws(InvalidArgumentException::class, "Hiba üzenet");
    
    it('validates exception handling explicitly', function () {
        // Itt kell meghívni az ellenőrizendő függvényt: expect(fn() => Foo::bar(''))->toThrow(InvalidArgumentException::class, "Hiba üzenet");
        expect(fn() => throw new InvalidArgumentException("Hiba üzenet"))
            ->toThrow(InvalidArgumentException::class, "Hiba üzenet");
        });

    afterEach(function () {
        // Takarítás a csoport tesztjei után
    });
});