import {Calculator} from "../../main/typescript/calculator.js";

describe('Calculator', () => {

    let calculator;

    beforeEach(() => {
    	calculator = new Calculator();
    });

    describe('calculate()', () => {

        it('should return NaN for null, undefined and empty string input', () => {
            expect(calculator.calculate(null)).toBeNaN();
            expect(calculator.calculate()).toBeNaN();
            expect(calculator.calculate('')).toBeNaN();
        });

        xit('should return NaN for input with only spaces', () => {
            expect(calculator.calculate(' \t\n')).toBeNaN();
        });

        xit('should return NaN for non-numeric input', () => {
            expect(calculator.calculate('a')).toBeNaN();
        });

        xit('should return the only integer input', () => {
            let result = calculator.calculate('1');
            expect(result).toBe(1);
        });

        xit('should add two integers', () => {
            let result = calculator.calculate('1+2');
            expect(result).toBe(3);
        });

        xit('should add three integers', () => {
            let result = calculator.calculate('1+2+3');
            expect(result).toBe(6);
        });

        xit('should add multiple integers', () => {
            let result = calculator.calculate('1+2+3+4+5+6');
            expect(result).toBe(21);
        });

        xit('should skip spaces between numbers', () => {
            let result = calculator.calculate('1 + 2\n+ 3\t+ 4');
            expect(result).toBe(10);
        });

        xit('should handle leading plus sign', () => {
            let result = calculator.calculate('+1 + 2');
            expect(result).toBe(3);
        });

        xit('should handle leading minus sign', () => {
            let result = calculator.calculate('-1 + 2');
            expect(result).toBe(1);
        });

        xit('should handle leading minus and plus signs', () => {
            let result = calculator.calculate('-1 + +2');
            expect(result).toBe(1);
        });

        xit('should do subtraction', () => {
            let result = calculator.calculate('1 - 2');
            expect(result).toBe(-1);
        });

        xit('should handle negative number', () => {
            let result = calculator.calculate('1 + -2-1');
            expect(result).toBe(-2);
        });

    });

});