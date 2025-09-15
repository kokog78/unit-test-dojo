package dojo

class PathResolverKt {

    /**
     * Egy abszolút útvonalat egységes formába alakít, eltávolítja belőle a `.` és a `..`
     * útvonal-részeket. Az egyes útvonal-részeket a `/` karakter választja el egymástól. A `.`
     * útvonal-rész nem változtatja meg az aktuális útvonalat. A `..` útvonal-rész hatására az aktuális
     * útvonal egy szinttel feljebb kerül.
     * @param absolutePath egy abszolút útvonal
     * @return egységes formába alakított útvonal
     */
    fun normalize(absolutePath: String?): String? {
        return null
    }

    /**
     * Egyesíti a két paraméterben megadott útvonalakat és egységes formára hozza az eredményt. Mindkét útvonal esetén
     * kezeli a `.` és a `..` útvonal-részeket.
     * @param absolutePath egy abszolút útvonal
     * @param relativePath egy relatív útvonal
     * @return az egyesített és egységes formába alakított útvonal
     */
    fun resolve(absolutePath: String?, relativePath: String?): String? {
        return null
    }

}