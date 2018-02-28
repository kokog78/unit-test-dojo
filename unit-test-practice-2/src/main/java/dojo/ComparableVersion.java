package dojo;

import java.util.HashSet;

/**
 * Ezt az osztályt arra szeretnénk majd használni, hogy konfigurációs fájlokban megadott
 * verziószámokkal tudjunk műveleteket megadni. Egyrészről össze szeretnénk hasonlítani
 * két verziószámot - erre való a {@link #compareTo(ComparableVersion)} metódus.
 * Másrészről az egyes verziószámokat engedélyezni vagy tiltani szeretnénk - erre való
 * a {@link #setEnabled(boolean)} ill. az {@link #isEnabled()} metódus.
 */
public class ComparableVersion implements Comparable<ComparableVersion> {

	private static HashSet<ComparableVersion> enabledVersions = new HashSet<>();
	private final int[] parts;
	
	public ComparableVersion(String version) {
		this.parts = createParts(version);
	}

	@Override
	public int compareTo(ComparableVersion otherVersion) {
		int limit = Math.min(parts.length, otherVersion.parts.length);
		for (int i=0; i < limit; i++) {
			int currentResult = parts[i] - otherVersion.parts[i];
			if (currentResult != 0) {
				return currentResult;
			}
		}
		return otherVersion.parts.length - parts.length;
	}
	
	@Override
	public boolean equals(Object otherObject) {
		return (otherObject instanceof ComparableVersion) && compareTo((ComparableVersion)otherObject) == 0;
	}
	
	/**
	 * A verziószám engedélyezett?
	 */
	public boolean isEnabled() {
		synchronized (enabledVersions) {
			return enabledVersions.contains(this);	
		}
	}

	/**
	 * Engedélyezi vagy tiltja a verziószámot.
	 * Ha a paraméter <code>true</code>: engedélyezi.
	 * Ha a paraméter <code>false</code>: tiltja.
	 */
	public void setEnabled(boolean enabled) {
		synchronized (enabledVersions) {
			if (enabled) {
				enabledVersions.add(this);
			} else {
				enabledVersions.remove(this);
			}
		}
	}
	
	private final int[] createParts(String version) {
		String[] strArray = version.split("\\.");
		int[] result = new int[strArray.length];
		for (int i=0; i < strArray.length; i++) {
			result[i] = Integer.parseInt(strArray[i]);
		}
		return result;
	}
}
