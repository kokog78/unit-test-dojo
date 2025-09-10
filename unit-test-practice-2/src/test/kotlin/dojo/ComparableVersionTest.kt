package dojo

import org.assertj.core.api.Assertions.assertThat
import org.assertj.core.api.Assertions.assertThatThrownBy
import org.junit.jupiter.api.Test

class ComparableVersionTest {

    @Test
    fun `should do something`() {
        val result = 12
        // asszertálás példák:
        assertThat(result).isEqualTo(12)
        assertThat(result).isPositive()
        assertThat(result).isNotNegative()
        assertThat(result).isNotZero()
        // asszertálás kivételre:
        assertThatThrownBy {
            throw NullPointerException()
        }.isInstanceOf(NullPointerException::class.java)
    }
}