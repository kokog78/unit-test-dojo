package dojo

import org.mockito.kotlin.*
import twitter4j.Status
import twitter4j.Twitter
import org.testng.annotations.Test

class TwitterClientKtTest {

    @Test
    fun howToUseMockito() {
        //   mock létrehozás
        val twitterMock = mock<Twitter>()
        val statusMock = mock<Status>()

        // konfiguráció
        whenever(twitterMock.updateStatus(any<String>())).thenReturn(statusMock)

        twitterMock.updateStatus("teszt")

        // ellenőrzés
        verify(twitterMock).updateStatus("teszt")
    }

}