export class PathResolver {

	/**
	 * Egy abszolút útvonalat egységes formába alakít, eltávolítja belőle a <code>.</code> és a <code>..</code>
	 * útvonal-részeket. Az egyes útvonal-részeket a <code>/</code> karakter választja el egymástól. A <code>.</code>
	 * útvonal-rész nem változtatja meg az aktuális útvonalat. A <code>..</code> útvonal-rész hatására az aktuális
	 * útvonal egy szinttel feljebb kerül.
	 * @param absolutePath egy abszolút útvonal
	 * @return egységes formába alakított útvonal
	 */
	normalize(absolutePath: string): string {
		return null;
	}

	/**
	 * Egyesíti a két paraméterben megadott útvonalakat és egységes formára hozza az eredményt. Mindkét útvonal esetén
	 * kezeli a <code>.</code> és a <code>..</code> útvonal-részeket.
	 * @param absolutePath egy abszolút útvonal
	 * @param relativePath egy relatív útvonal
	 * @return az egyesített és egységes formába alakított útvonal
	 */
	resolve(absolutePath: string, relativePath: string): string {
		return null;
	}
}
