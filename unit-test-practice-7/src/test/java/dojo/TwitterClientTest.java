package dojo;

import static org.mockito.ArgumentMatchers.anyString;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

import org.testng.annotations.Test;

import twitter4j.Status;
import twitter4j.Twitter;

public class TwitterClientTest {

	
	@Test
	public void how_to_use_mockito() throws Exception {
		// mock létrehozás
		Twitter twitterMock = mock(Twitter.class);
		Status statusMock = mock(Status.class);

		// konfiguráció
		when(twitterMock.updateStatus(anyString())).thenReturn(statusMock);
		
		twitterMock.updateStatus("teszt");
		
		// ellenőrzés
		verify(twitterMock).updateStatus("teszt");
	}
}
