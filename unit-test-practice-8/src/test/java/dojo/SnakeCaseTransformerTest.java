package dojo;

import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.assertThatThrownBy;

import org.junit.Test;

public class SnakeCaseTransformerTest {

	private SnakeCaseTransformer transformer = new SnakeCaseTransformer();
	
	@Test
	public void sample_test() throws Exception {
		String result = transformer.transform("");
		assertThat(4).isEqualTo(4);
	}
}
