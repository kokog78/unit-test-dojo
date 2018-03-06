module.exports = function() {
	/**
	 * Római számok előállítására szolgáló osztályka. A római számok előállításának szabályai:
	 * - 0 és negatív szám esetén nem értelmezett,
	 * - 3000 vagy afölötti szám esetén nem értelmezett.
	 * - 1 = I
	 * - 5 = V
	 * - 10 = X
	 * - 50 = L
	 * - 100 = C
	 * - 500 = D
	 * - 1000 = M
	 * - I, X, C és M egymás mellett csak maximum 3-szor állhatnak. (De egy számon belül 3-nál többször is előfordulhatnak, ha nem
	 *   egymás mellett állnak, pl. XXXIX.)
	 * - V, L és D nem ismétlődhetnek.
	 * - Egy nagyobb helyiértékű számból egyetlen kisebb helyiértékű vonható le.
	 * - I csak V-ből és X-ből vonható le.
	 * - X csak L-ből és C-ből vonható le.
	 * - C csak D-ből és M-ből vonható le.
	 * - Egy arab számot számjegyekre lehet bontani és számjegyenként lehet ábrázolni. A 0 számjegyet ki kell hagyni.
	 *   Pl. 1903 felbontható: 1, 9, 0 és 3. 1000 = M, 900 = CM, 3 = III. Ezért 1903 = MCMIII.
	 */
    this.generate = function(number) {
        
    };
};