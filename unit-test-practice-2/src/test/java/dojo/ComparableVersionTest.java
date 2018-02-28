package dojo;

import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.assertThatThrownBy;

import org.testng.annotations.Test;

public class ComparableVersionTest {

	@Test
	public void should_do_something() throws Exception {
		int result = 12;
		// asszertálás példák:
		assertThat(result).isEqualTo(12);
		assertThat(result).isPositive();
		assertThat(result).isNotNegative();
		assertThat(result).isNotZero();
		// asszertálás kivételre:
		assertThatThrownBy(() -> {
			throw new NullPointerException();
		}).isInstanceOf(NullPointerException.class);
	}
	
}
