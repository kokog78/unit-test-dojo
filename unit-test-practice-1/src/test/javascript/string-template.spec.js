var StringTemplate = require('../../main/javascript/string-template');

describe('StringTemplate', function() {

    var stringTemplate;

    beforeEach(function() {
        stringTemplate = new StringTemplate();
    });

    describe('render()', function() {

        it('should return null if pattern is null', function() {
            var result = stringTemplate.render(null, []);
            expect(result).toBeNull();
        });

        it('should return pattern without parameters', function() {
            var result1 = stringTemplate.render('pattern');
            var result2 = stringTemplate.render('pattern', []);
            expect(result1).toBe('pattern');
            expect(result2).toBe('pattern');
        });

        it('should include empty string for null', function() {
            var result = stringTemplate.render('pattern ${0}', [null]);
            expect(result).toBe('pattern ');
        });

        it('should include empty string for undefined', function() {
            var result = stringTemplate.render('pattern ${0}', [undefined]);
            expect(result).toBe('pattern ');
        });

        it('should include string', function() {
            var result = stringTemplate.render('pattern ${0}', ['test']);
            expect(result).toBe('pattern test');
        });

        it('should include boolean', function() {
            var result1 = stringTemplate.render('pattern ${0}', [true]);
            var result2 = stringTemplate.render('pattern ${0}', [false]);
            expect(result1).toBe('pattern true');
            expect(result2).toBe('pattern false');
        });

        it('should include formatted decimal number', function() {
            var result1 = stringTemplate.render('pattern ${0}', [0.1]);
            var result2 = stringTemplate.render('pattern ${0}', [123456.12]);
            expect(result1).toBe('pattern 0,10');
            expect(result2).toBe('pattern 123456,12');
        });

        it('should include integer', function() {
            var result = stringTemplate.render('pattern ${0}', [123456]);
            expect(result).toBe('pattern 123456');
        });

        it('should include formatted date', function() {
            var date = new Date(2001, 1, 10, 19, 32, 18, 23);
            var result = stringTemplate.render('pattern ${0}', [date]);
            expect(result).toBe('pattern 2001-01-10 19:32:18');
        });

        it('should include question mark for object', function() {
            var result = stringTemplate.render('pattern', [{}]);
            expect(result).toBe('pattern ?');
        });

        it('should include multiple parameters', function() {
            var result = stringTemplate.render('pattern ${0} ${1} ${2} ${3}', [12, 5.2, 'test', true]);
            expect(result).toBe('pattern 12 5,20 test true');
        });

        it('should skip unused and unspecified parameters', function() {
            var result = stringTemplate.render('pattern ${0} ${2} ${3}', [12, 5.2, 'test']);
            expect(result).toBe('pattern 12 test ${3}');
        });

    });

});