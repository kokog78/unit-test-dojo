var Parser = require('../../main/javascript/parser');

describe('Parser characterization test', function() {

    var parser;

    beforeEach(function() {
        parser = new Parser();
    });

    it('with good address', function() {
        test("2040 Budaörs Valami utca 5.", "2040", "Budaörs", "Valami utca 5.");
        test("Budaörs 2040 Valami utca 5.", "2040", "Budaörs", "Valami utca 5.");
        test("Valami utca 5. Budaörs 2040", "2040", "Budaörs", "Valami utca 5.");
        test("Valami utca 5. 2040 Budaörs", "2040", "Budaörs", "Valami utca 5.");
    });

    it('with bad address', function() {
        test("Valami 2040 Budaörs utca 5.", "2040", "Budaörs", "Valami utca 5.");
        test("Valami 2040 utca 5. Budaörs", "2040", "Budaörs", "Valami utca 5.");
        test("Valami Budaörs utca 5. 2040", "2040", "Budaörs", "Valami utca 5.");
        test("Budaörs Valami 2040 utca 5.", "2040", "Budaörs", "Valami utca 5.");
        test("2040 Valami Budaörs utca 5.", "2040", "Budaörs", "Valami utca 5.");
    });

    it('with duplicated parts address', function() {
        test("2040 Budaörs Valami utca 2040", "2040", "Budaörs", "Valami utca 2040");
        test("2040 Budaörs 2040 Valami utca", "2040", "Budaörs", "2040 Valami utca");
        test("Budaörs 2040 Budaörs utca 5.", "2040", "Budaörs", "Budaörs utca 5.");
        test("Budaörs Budaörs utca 5. 2040", "2040", "Budaörs", "Budaörs utca 5.");
        test("Budaörs Kis Budaörs utca 5. 2040", "2040", "Budaörs", "Kis Budaörs utca 5.");
    });

    it('with numbers', function() {
        test("123 1234", "1234", null, "123");
        test("1234 123", "1234", null, "123");
    });

    it('with address with whitespace', function() {
        test(" 2040", "2040", null, null);
        test("\t2040", "2040", null, null);
        test("\n2040", "2040", null, null);
        test("\r2040", "2040", null, null);
        test("2040 ", "2040", null, null);
        test("2040\t", "2040", null, null);
        test("2040\n", "2040", null, null);
        test("2040\r", "2040", null, null);
    });

    function test(input, out1, out2, out3) {
        expect(parser.parse(input)).toEqual([out1, out2, out3]);
    }
});