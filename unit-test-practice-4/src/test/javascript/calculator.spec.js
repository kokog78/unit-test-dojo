const Calculator = require('../../main/javascript/calculator');

describe('Calculator', function() {

    let calculator;

    beforeEach(function() {
    	calculator = new Calculator();
    });

    describe('calculate()', function() {

        it('should return NaN for null, undefined and empty string input', function() {
            expect(calculator.calculate(null)).toBeNaN();
            expect(calculator.calculate()).toBeNaN();
            expect(calculator.calculate('')).toBeNaN();
        });

        xit('should return NaN for input with only spaces', function() {
            expect(calculator.calculate(' \t\n')).toBeNaN();
        });

        xit('should return NaN for non-numeric input', function() {
            expect(calculator.calculate('a')).toBeNaN();
        });

        xit('should return the only integer input', function() {
            let result = calculator.calculate('1');
            expect(result).toBe(1);
        });

        xit('should add two integers', function() {
            let result = calculator.calculate('1+2');
            expect(result).toBe(3);
        });

        xit('should add three integers', function() {
            let result = calculator.calculate('1+2+3');
            expect(result).toBe(6);
        });

        xit('should add multiple integers', function() {
            let result = calculator.calculate('1+2+3+4+5+6');
            expect(result).toBe(21);
        });

        xit('should skip spaces between numbers', function() {
            let result = calculator.calculate('1 + 2\n+ 3\t+ 4');
            expect(result).toBe(10);
        });

        xit('should handle leading plus sign', function() {
            let result = calculator.calculate('+1 + 2');
            expect(result).toBe(3);
        });

        xit('should handle leading minus sign', function() {
            let result = calculator.calculate('-1 + 2');
            expect(result).toBe(1);
        });

        xit('should handle leading minus and plus signs', function() {
            let result = calculator.calculate('-1 + +2');
            expect(result).toBe(1);
        });

        xit('should do subtraction', function() {
            let result = calculator.calculate('1 - 2');
            expect(result).toBe(-1);
        });

        xit('should handle negative number', function() {
            let result = calculator.calculate('1 + -2-1');
            expect(result).toBe(-2);
        });

    });

});