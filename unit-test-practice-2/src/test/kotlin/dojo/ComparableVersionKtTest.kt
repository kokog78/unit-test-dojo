package dojo

import org.assertj.core.api.Assertions.assertThat
import org.assertj.core.api.Assertions.assertThatThrownBy
import org.testng.annotations.Test

class ComparableVersionKtTest {

    @Test
    fun shouldDoSomething() {
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

        val v: ComparableVersionKt = ComparableVersionKt("1.2.3")
        v.compareTo(ComparableVersionKt("1.2.3"))
    }
}