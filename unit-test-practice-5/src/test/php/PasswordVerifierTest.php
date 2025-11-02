<?php

namespace Tests;

use App\PasswordVerifier;
use PHPUnit\Framework\TestCase;
use \InvalidArgumentException;

class PasswordVerifierTest extends TestCase
{

    public function testShouldDoSomething()
    {
        $result = 12;
        $this->assertEquals(12, $result);
        $this->assertGreaterThan(0, $result);
        $this->assertGreaterThanOrEqual(0, $result);
        $this->assertNotEquals(0, $result);
    }

    public function testExceptionIsThrown()
    {
        // Jelezzük a PHPUnit-nak, hogy milyen kivételt VÁRUNK.
        // Ezt a kivételt dobó kód ELŐTT kell megtenni.
        $this->expectException(InvalidArgumentException::class);
        // Futtatjuk a kódot, aminek el kell dobnia a kivételt.
        throw new InvalidArgumentException("A verziónak tartalmaznia kell legalább egy számot.");
        // Ha a kód eljut idáig (mert nem dobott kivételt), 
        // a PHPUnit a tesztet automatikusan SIKERTELENNEK (Failed) jelöli.
    }
}