var enabledVersions = {};

/**
 * Ezt az osztályt arra szeretnénk majd használni, hogy konfigurációs fájlokban megadott
 * verziószámokkal tudjunk műveleteket megadni. Egyrészről össze szeretnénk hasonlítani
 * két verziószámot - erre való a compareTo(otherVersion) metódus.
 * Másrészről az egyes verziószámokat engedélyezni vagy tiltani szeretnénk - erre való
 * a setEnabled(boolean) ill. az isEnabled() metódus.
 */
module.exports = function(version) {

    this.version = version;
    this.parts = createParts(version);

    this.compareTo = function(otherVersion) {
        var limit = (this.parts.length < otherVersion.parts.length ? this.parts.length : otherVersion.parts.length);
        for (i=0; i<limit; i++) {
            var currentResult = this.parts[i] - otherVersion.parts[i];
            if (currentResult !== 0) {
                return currentResult;
            }
        }
        return otherVersion.parts.length - this.parts.length;
    };

    /**
     * A verziószám engedélyezett?
     */
    this.isEnabled = function() {
        return !!enabledVersions[this.version];
    };

    /**
     * Engedélyezi vagy tiltja a verziószámot.
     * Ha a paraméter true: engedélyezi.
     * Ha a paraméter false: tiltja.
     */
    this.setEnabled = function(enabled) {
        enabledVersions[this.version] = enabled;
    };

    function createParts(version) {
        var strArray = version.split('.');
        var result = [];
        for (i=0; i<strArray.length; i++) {
            result.push(+strArray[i].trim());
        }
        return result;
    }
};