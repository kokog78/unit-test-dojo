<?php

namespace Tests;

use Abraham\TwitterOAuth\TwitterOAuth; 
use stdClass; 
use Mockery; 
use Mockery\Adapter\Phpunit\MockeryTestCase; 

/**
 * FONTOS: A 'MockeryTestCase'-t terjesztjük ki (extend)
 * a sima 'TestCase' helyett. Erre azért van szükség, mert a Mockery-nek minden teszt lefutása után
 * "ki kell takarítania" maga után. Ez az osztály ezt
 * automatikusan elvégzi (meghívja a Mockery::close()-t a háttérben).
 */
class TwitterClientTest extends MockeryTestCase
{

    public function testHowToUseMockery()
    {

        $twitterMock = Mockery::mock(TwitterOAuth::class);
        $statusMock = Mockery::mock(stdClass::class);
        $twitterMock
            ->shouldReceive('post')
            ->with('statuses/update', ['status' => 'teszt'])
            ->andReturn($statusMock);

        $twitterMock->post('statuses/update', ['status' => 'teszt']);

        $twitterMock->shouldHaveReceived('post', ['statuses/update', ['status' => 'teszt']]);
    }
    
}