package dojo;

/**
 * Római számok előállítására szolgáló osztályka. A római számok előállításának szabályai:
 * <ul>
 * <li>0 és negatív szám esetén nem értelmezett,</li>
 * <li>3000 vagy afölötti szám esetén nem értelmezett.</li>
 * <li>1 = I</li>
 * <li>5 = V</li>
 * <li>10 = X</li>
 * <li>50 = L</li>
 * <li>100 = C</li>
 * <li>500 = D</li>
 * <li>1000 = M</li>
 * <li>I, X, C és M egymás mellett csak maximum 3-szor állhatnak. (De egy számon belül 3-nál többször is előfordulhatnak, ha nem
 * egymás mellett állnak, pl. XXXIX.)</li>
 * <li>V, L és D nem ismétlődhetnek.</li>
 * <li>Egy nagyobb helyiértékű számból egyetlen kisebb helyiértékű vonható le.</li>
 * <li>I csak V-ből és X-ből vonható le.</li>
 * <li>X csak L-ből és C-ből vonható le.</li>
 * <li>C csak D-ből és M-ből vonható le.</li>
 * <li>Egy arab számot számjegyekre lehet bontani és számjegyenként lehet ábrázolni. A 0 számjegyet ki kell hagyni.
 * Pl. 1903 felbontható: 1, 9, 0 és 3. 1000 = M, 900 = CM, 3 = III. Ezért 1903 = MCMIII.</li>
 * </ul>
 */
public class RomanNumeralGenerator {
	
    public String generate(int number) {
    	return null;
    }
}
