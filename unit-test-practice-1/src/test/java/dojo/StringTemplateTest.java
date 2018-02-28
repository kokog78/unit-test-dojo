package dojo;

import static org.assertj.core.api.Assertions.assertThat;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Locale;

import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

public class StringTemplateTest {

	private StringTemplate template;
	
	@BeforeMethod
	public void setUp() {
		Locale.setDefault(Locale.forLanguageTag("hu"));
		template = new StringTemplate();
	}
	
	@Test
	public void render_should_return_null_if_pattern_is_null() throws Exception {
		String result = template.render(null);
		assertThat(result).isNull();
	}
	
	@Test
	public void render_should_return_pattern_without_parameters() throws Exception {
		String result = template.render("pattern");
		assertThat(result).isEqualTo("pattern");
	}
	
	@Test
	public void render_should_include_empty_string_for_null() throws Exception {
		String result = template.render("pattern ${0}", (Object)null);
		assertThat(result).isEqualTo("pattern ");
	}
	
	@Test
	public void render_should_include_formatted_double() throws Exception {
		String result1 = template.render("pattern ${0}", 0.1);
		String result2 = template.render("pattern ${0}", 123456.12);
		assertThat(result1).isEqualTo("pattern 0,10");
		assertThat(result2).isEqualTo("pattern 123456,12");
	}
	
	@Test
	public void render_should_include_formatted_float() throws Exception {
		String result1 = template.render("pattern ${0}", 0.1f);
		String result2 = template.render("pattern ${0}", 123456.12f);
		assertThat(result1).isEqualTo("pattern 0,10");
		assertThat(result2).isEqualTo("pattern 123456,12");
	}
	
	@Test
	public void render_should_include_formatted_bigdecimal() throws Exception {
		String result1 = template.render("pattern ${0}", new BigDecimal(0.1));
		String result2 = template.render("pattern ${0}", new BigDecimal(123456.12));
		assertThat(result1).isEqualTo("pattern 0,10");
		assertThat(result2).isEqualTo("pattern 123456,12");
	}
	
	@Test
	public void render_should_include_integer() throws Exception {
		String result = template.render("pattern ${0}", 123456);
		assertThat(result).isEqualTo("pattern 123456");
	}
	
	@Test
	public void render_should_include_formatted_date() throws Exception {
		Calendar calendar = Calendar.getInstance();
		calendar.set(Calendar.YEAR, 2001);
		calendar.set(Calendar.MONTH, Calendar.JANUARY);
		calendar.set(Calendar.DAY_OF_MONTH, 10);
		calendar.set(Calendar.HOUR_OF_DAY, 19);
		calendar.set(Calendar.MINUTE, 32);
		calendar.set(Calendar.SECOND, 18);
		calendar.set(Calendar.MILLISECOND, 23);
		String result = template.render("pattern ${0}", calendar.getTime());
		assertThat(result).isEqualTo("pattern 2001-01-10 19:32:18");
	}
	
	@Test
	public void render_should_include_formatted_calendar() throws Exception {
		Calendar calendar = Calendar.getInstance();
		calendar.set(Calendar.YEAR, 2001);
		calendar.set(Calendar.MONTH, Calendar.JANUARY);
		calendar.set(Calendar.DAY_OF_MONTH, 10);
		calendar.set(Calendar.HOUR_OF_DAY, 19);
		calendar.set(Calendar.MINUTE, 32);
		calendar.set(Calendar.SECOND, 18);
		calendar.set(Calendar.MILLISECOND, 23);
		String result = template.render("pattern ${0}", calendar);
		assertThat(result).isEqualTo("pattern 2001-01-10 19:32:18");
	}
	
	@Test
	public void render_should_include_to_string_for_object() throws Exception {
		StringBuilder object = new StringBuilder();
		object.append("string value");
		String result = template.render("pattern ${0}", object);
		assertThat(result).isEqualTo("pattern string value");
	}
	
	@Test
	public void render_should_include_multiple_parameters() throws Exception {
		String result = template.render("pattern ${0} ${1} ${2} ${3}", 12, 5.2, "test", true);
		assertThat(result).isEqualTo("pattern 12 5,20 test true");
	}
	
	@Test
	public void render_should_skip_unused_and_unspecified_parameters() throws Exception {
		String result = template.render("pattern ${0} ${2} ${3}", 12, 5.2, "test");
		assertThat(result).isEqualTo("pattern 12 test ${3}");
	}
	
}
