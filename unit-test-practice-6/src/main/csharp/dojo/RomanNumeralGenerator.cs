namespace dojo;

using System;
using System.Text;

// <summary>
/// Római számok előállítására szolgáló osztály.
/// A római számok előállításának szabályai:
/// <list type="bullet">
/// <item>0 és negatív szám esetén nem értelmezett.</item>
/// <item>3000 vagy afölötti szám esetén nem értelmezett.</item>
/// <item>1 = I</item>
/// <item>5 = V</item>
/// <item>10 = X</item>
/// <item>50 = L</item>
/// <item>100 = C</item>
/// <item>500 = D</item>
/// <item>1000 = M</item>
/// <item>I, X, C és M egymás mellett csak maximum 3-szor állhatnak.</item>
/// <item>V, L és D nem ismétlődhetnek.</item>
/// <item>Egy nagyobb helyiértékű számból egyetlen kisebb helyiértékű vonható le.</item>
/// <item>I csak V-ből és X-ből vonható le.</item>
/// <item>X csak L-ből és C-ből vonható le.</item>
/// <item>C csak D-ből és M-ből vonható le.</item>
/// <item>Egy arab számot számjegyekre lehet bontani és számjegyenként lehet ábrázolni.</item>
/// </list>
/// </summary>
public class RomanNumeralGenerator
{
    public string Generate(int number)
    {
        return null;
    }
}
