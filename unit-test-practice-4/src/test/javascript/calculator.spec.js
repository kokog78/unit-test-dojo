const Calculator = require('../../main/javascript/calculator');

describe('Calculator', function() {

    let calculator;

    beforeEach(function() {
    	calculator = new Calculator();
    });

    describe('calculate()', function() {

        it('should throw error for null, undefined and empty string input', function() {
            expect(function() {
                calculator.calculate(null);
            }).toThrow();
            expect(function() {
                calculator.calculate();
            }).toThrow();
            expect(function() {
                calculator.calculate('');
            }).toThrow();
        });

        xit('should throw error for input with only spaces', function() {
            expect(function() {
                calculator.calculate(' \t\n');
            }).toThrow();
        });

        xit('should throw error for non-numeric input', function() {
            expect(function() {
                calculator.calculate('a');
            }).toThrow();
        });

        xit('should return the only integer input', function() {
            let result = calculator.calculate('1');
            expect(result).toBe(1);
        });

        xit('should add two integers', function() {
            let result = calculator.calculate('1+2');
            expect(result).toBe(3);
        });

        xit('should add multiple integers', function() {
            let result = calculator.calculate('1+2+3+4+5+6');
            expect(result).toBe(21);
        });

        xit('should skip spaces between numbers', function() {
            let result = calculator.calculate('1 + 2\n+ 3\t+ 4');
            expect(result).toBe(10);
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