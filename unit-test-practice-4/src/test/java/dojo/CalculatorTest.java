package dojo;

import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.catchThrowable;

import org.testng.annotations.Test;

public class CalculatorTest {

	private Calculator calculator = new Calculator();
	
	@Test
	public void should_throw_exception_for_null_input() throws Exception {
		Throwable ex = catchThrowable(() -> calculator.calculate(null));
		assertThat(ex).isInstanceOf(NullPointerException.class);
	}
	
	@Test(enabled=false)
	public void should_throw_exception_for_empty_string() throws Exception {
		Throwable ex = catchThrowable(() -> calculator.calculate(""));
		assertThat(ex).isInstanceOf(IllegalArgumentException.class);
	}
	
	@Test(enabled=false)
	public void should_throw_exception_for_input_with_only_spaces() throws Exception {
		Throwable ex = catchThrowable(() -> calculator.calculate(" \t\n"));
		assertThat(ex).isInstanceOf(IllegalArgumentException.class);
	}
	
	@Test(enabled=false)
	public void should_throw_exception_for_non_numeric_input() throws Exception {
		Throwable ex = catchThrowable(() -> calculator.calculate("a"));
		assertThat(ex).isInstanceOf(IllegalArgumentException.class);
	}

	@Test(enabled=false)
	public void should_return_the_only_integer_input() throws Exception {
		int result = calculator.calculate("1");
		assertThat(result).isEqualTo(1);
	}
	
	@Test(enabled=false)
	public void should_add_two_integers() throws Exception {
		int result = calculator.calculate("1+2");
		assertThat(result).isEqualTo(3);
	}
	
	@Test(enabled=false)
	public void should_add_multiple_integers() throws Exception {
		int result = calculator.calculate("1+2+3+4+5+6");
		assertThat(result).isEqualTo(21);
	}
	
	@Test(enabled=false)
	public void should_skip_spaces_between_numbers() throws Exception {
		int result = calculator.calculate("1 + 2\n+ 3\t+ 4");
		assertThat(result).isEqualTo(10);
	}
	
	@Test(enabled=false)
	public void should_do_subtraction() throws Exception {
		int result = calculator.calculate("1 - 2");
		assertThat(result).isEqualTo(-1);
	}

	@Test(enabled=false)
	public void should_handle_negative_number() throws Exception {
		int result = calculator.calculate("1 + -2");
		assertThat(result).isEqualTo(-1);
	}
}
