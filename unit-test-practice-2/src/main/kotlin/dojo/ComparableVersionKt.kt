package dojo

import java.util.Collections
import java.util.concurrent.ConcurrentHashMap

/**
 * Ezt az osztályt arra szeretnénk majd használni, hogy konfigurációs fájlokban megadott
 * verziószámokkal tudjunk műveleteket megadni. Egyrészről össze szeretnénk hasonlítani
 * két verziószámot - erre való a [compareTo] metódus.
 * Másrészről az egyes verziószámokat engedélyezni vagy tiltani szeretnénk - erre való
 * a [setEnabled] ill. az [isEnabled] metódus.
 */
class ComparableVersionKt(version: String) : Comparable<ComparableVersionKt> {

    companion object {
        private val enabledVersions = Collections.newSetFromMap(ConcurrentHashMap<ComparableVersionKt, Boolean>())
    }

    private val parts: IntArray = createParts(version)

    override fun compareTo(other: ComparableVersionKt): Int {
        val limit = Math.min(parts.size, other.parts.size)
        for (i in 0 .. limit) {
            val currentResult = parts[i] - other.parts[i]
            if (currentResult != 0) {
                return currentResult
            }
        }
        return other.parts.size - parts.size
    }

    override fun equals(other: Any?): Boolean {
        return (other is ComparableVersionKt) && compareTo(other) == 0
    }

    override fun hashCode(): Int {
        return parts.hashCode()
    }

    /**
     * A verziószám engedélyezett?
     */
    fun isEnabled(): Boolean {
        return enabledVersions.contains(this)
    }

    /**
     * Engedélyezi vagy tiltja a verziószámot.
     * Ha a paraméter `true`: engedélyezi.
     * Ha a paraméter `false`: tiltja.
     */
    fun setEnabled(enabled: Boolean) {
        if (enabled) {
            enabledVersions.add(this)
        } else {
            enabledVersions.remove(this)
        }
    }

    private fun createParts(version: String): IntArray {
        return version.split(".").map { it.toInt() }.toIntArray()
    }
}