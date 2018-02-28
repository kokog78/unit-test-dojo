var ComparableVersion = require('../../main/javascript/comparable-version');

describe('ComparableVersion', function() {

    it('example test', function() {
        var result = 12;
        // asszertálás példák:
        expect(result).toBe(12);
        expect(result).toBeGreaterThan(0);
        expect(result).toBeTruthy();
        expect(result).not.toBeLessThan(0);
        // asszertálás kivételre:
        expect(function() {
            throw new Error('err');
        }).toThrow();
        expect(function() {
            throw new Error('err');
        }).toThrowError('err');
    });

});