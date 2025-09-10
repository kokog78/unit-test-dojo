package dojo

import org.junit.jupiter.api.Test
import org.mockito.kotlin.*
import twitter4j.Status
import twitter4j.Twitter

class TwitterClientKtTest {
    @Test
    fun `how to use mockito`() {
        // mock létrehozás
        val twitterMock = mock<Twitter>()
        val statusMock = mock<Status>()

        // konfiguráció
        whenever(twitterMock.updateStatus(anyString())).thenReturn(statusMock)

        twitterMock.updateStatus("teszt")

        // ellenőrzés
        verify(twitterMock).updateStatus("teszt")
    }
}