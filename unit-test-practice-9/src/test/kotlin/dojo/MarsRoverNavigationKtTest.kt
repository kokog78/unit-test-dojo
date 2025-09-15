package dojo

import org.assertj.core.api.Assertions.assertThat
import org.testng.annotations.Test

class MarsRoverNavigationKtTest {

    @Test
    fun shouldDoSomething() {
        val result = 12
        // asszertálás példák:
        assertThat(result).isEqualTo(12)
        assertThat(result).isPositive()
        assertThat(result).isNotNegative()
        assertThat(result).isNotZero()
    }

}