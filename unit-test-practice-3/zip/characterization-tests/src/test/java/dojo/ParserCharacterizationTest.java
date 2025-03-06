package dojo;

import static org.assertj.core.api.Assertions.assertThat;

import org.testng.annotations.Test;

public class ParserCharacterizationTest {

	private Parser parser = new Parser();
	
	@Test
	public void test_good_address() throws Exception {
		test("2040 Budaörs Valami utca 5.", "2040", "Budaörs", "Valami utca 5.");
		test("Budaörs 2040 Valami utca 5.", "2040", "Budaörs", "Valami utca 5.");
		test("Valami utca 5. Budaörs 2040", "2040", "Budaörs", "Valami utca 5.");
		test("Valami utca 5. 2040 Budaörs", "2040", "Budaörs", "Valami utca 5.");
	}
	
	@Test
	public void test_bad_address() throws Exception {
		test("Valami 2040 Budaörs utca 5.", "2040", "Budaörs", "Valami utca 5.");
		test("Valami 2040 utca 5. Budaörs", "2040", "Budaörs", "Valami utca 5.");
		test("Valami Budaörs utca 5. 2040", "2040", "Budaörs", "Valami utca 5.");
		test("Budaörs Valami 2040 utca 5.", "2040", "Budaörs", "Valami utca 5.");
		test("2040 Valami Budaörs utca 5.", "2040", "Budaörs", "Valami utca 5.");
	}
	
	@Test
	public void test_duplicated_parts() throws Exception {
		test("2040 Budaörs Valami utca 2040", "2040", "Budaörs", "Valami utca 2040");
		test("2040 Budaörs 2040 Valami utca", "2040", "Budaörs", "2040 Valami utca");
		test("Budaörs 2040 Budaörs utca 5.", "2040", "Budaörs", "Budaörs utca 5.");
		test("Budaörs Budaörs utca 5. 2040", "2040", "Budaörs", "Budaörs utca 5.");
		test("Budaörs Kis Budaörs utca 5. 2040", "2040", "Budaörs", "Kis Budaörs utca 5.");
	}
	
	@Test
	public void test_numbers() throws Exception {
		test("123 1234", "1234", null, "123");
		test("1234 123", "1234", null, "123");
	}
	
	@Test
	public void test_address_with_whitespace() throws Exception {
		test(" 2040", "2040", null, null);
		test("\t2040", "2040", null, null);
		test("\n2040", "2040", null, null);
		test("\r2040", "2040", null, null);
		test("2040 ", "2040", null, null);
		test("2040\t", "2040", null, null);
		test("2040\n", "2040", null, null);
		test("2040\r", "2040", null, null);
	}
	
	private void test(String input, String ... expectedResult) {
		String[] result = parser.parse(input);
		assertThat(result).containsExactly(expectedResult);
	}
	
}
