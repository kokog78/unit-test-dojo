var Parser = require('../../main/javascript/parser');

describe('Parser', function() {

    it('Example test', function() {
        var result = ['a', 'a', 'b'];
        // asszertálás példák:
        expect(result).toEqual(['a', 'a', 'b']);
        expect(result).toContain('a');
        expect(result).toContain(jasmine.any(String));
        expect(result).toEqual(jasmine.arrayContaining(['a', 'b']));
        expect(result.length).toBe(3);
        expect(result[0]).toBe('a');
        expect(result[1]).not.toBeNull();
        expect(result[2]).toBeDefined();
        // asszertálás kivételre:
        expect(function() {
            throw new Error('err');
        }).toThrow();
        expect(function() {
            throw new Error('err');
        }).toThrowError('err');
    });

});