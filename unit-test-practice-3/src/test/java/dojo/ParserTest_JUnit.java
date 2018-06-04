package dojo;

import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.assertThatThrownBy;

import org.junit.Test;

public class ParserTest_JUnit {

	@Test
	public void should_do_something() throws Exception {
		String[] result = new String[]{
				"a",
				"a",
				"b"
		};
		// asszertálás példák:
		assertThat(result).containsExactly("a", "a", "b");
		assertThat(result).hasSize(3);
		assertThat(result).containsOnly("b", "a");
		assertThat(result[0]).isEqualTo("a");
		assertThat(result[1]).isNotNull();
		// asszertálás kivételre:
		assertThatThrownBy(() -> {
			throw new NullPointerException();
		}).isInstanceOf(NullPointerException.class);
	}
	
}
