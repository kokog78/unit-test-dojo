# A marsjáró-kihívás
(Eredeti származási hely: https://github.com/eXigentCoder/dojo-tdd)

Marsjárókat a marsi terep felmérése miatt küldenek a Marsra. Az egyik ilyen eszköz navigációs rendszerét te fogod programozni.
Ezeket az instrukciókat kaptad:

 - A Mars felszíne zónákra osztható. Minden zóna egy kétdimenziós derékszögű koordináta-rendszerrel modellezhető.
   Az egyes zónákat korábban gondosan feltérképezték, így a zónahatárok közötti felderítés teljesen biztonságos.
   A marsjáró pozícióját egyetlen derékszögű koordináta jelöli, pl. (5,5).
 - A marsjáró képes az égtájak értelmezésére. Vagy kelet felé (`E`), vagy nyugat felé (`W`), vagy észak felé (`N`), vagy pedig
   dél felé (`S`) áll.
 - A marsjáró az alábbi parancsokat érti meg:
    - `M`: mozgás egy egységgel előre (abba az irányba, amerre éppen áll)
    - `R`: fordulás 90 fokkal jobbra
    - `L`: fordulás 90 fokkal balra
 - Az átviteli idő miatt a marsjáróval történő kommunikáció lassú, csupán arra van lehetőség, hogy parancsok sorozatát küldd el.
   A marsjáró egymás után végrehajtja ezeket a parancsokat, és a végén visszaküldi az aktuális pozícióját az irányítóközpontnak.

Egy példa a marsjárónak küldött parancsokra:

```
8 8
1 2 E
MMLMRMMRRMML
```

A marsjáró így értelmezi a paracsokat:

 - Az első sor arról ad információt, hogy az aktuális zóna milyen nagy. A zóna határpontja a 8,8 derékszögű koordinátával rendelkezik,
   vagyis a zóna 64 blokkból áll.
 - A második sor a marsjáró kezdeti pozícióját és orientációját jelöli. A marsjáró az első (`1`) horizontális és a második (`2`) vertikális
   pocícióból indul, és kelet felé (`E`) néz.
 - A harmadik sor a végrehajtandó parancsok listája. Ezek egyaránt tartalmaznak mozgási és forgási parancsokat.

A marsjáró `1 2 E`-ből indulva és a fenti parancsokat végrehajtva `3 3 S`-be érkezik. Ez a navigációs művelet végeredménye.

Készítened kell egy programot, ami egy szövegfájlból beolvassa a fentihez hasonló parancsokat, és kiírja a marsjáró befejező
pocícióját a konzolra.

# Projekt előkészítés

## Java

IntelliJ: `pom.xml` > Add as Maven Project > ...

Eclipse: Import > Maven > Existing Maven Projects > ...

Fájlok:

```
src/main/java/dojo/MarsRoverNavigation.java
src/test/java/dojo/MarsRoverNavigationTest.java
```

## Typescript

NPM frissítése:

```
npm install npm -g
```

Projekt függőségek telepítése:

```
npm install
```

Folyamatos fordítás:

```
npx tsc --watch
```

vagy (ha az `npx` parancs nem érhető el):

```
node_modules/.bin/tsc --watch
```

Tesztek futtatása:

```
npx karma start
```

vagy (ha az `npx` parancs nem érhető el):

```
node_modules/.bin/karma start --watch
```

Tesztlefedettség-riport:

```
coverage/index.html
```

Fájlok:

```
src/main/typescript/mars-rover-navigation.ts
src/test/typescript/mars-rover-navigation.spec.ts
```

## PHP

Mielőtt elkezdenéd, a következő eszközökre lesz szükséged a gépeden:

1.  PHP 8.0+
    * Ellenőrzés: `php -v`
    * Javaslat (Windows): A legegyszerűbb módja az [XAMPP](https://www.apachefriends.org/hu/index.html) telepítése. Ez automatikusan telepíti a PHP-t. A telepítés után ne felejtsd el hozzáadni a telepítési mappát a Windows `PATH` környezeti változóihoz.
2.  Composer
    * Ellenőrzés: `composer -V`
    * Telepítés: Kövesd a [hivatalos telepítési útmutatót](https://getcomposer.org/download/). Ez a PHP csomagkezelője.
3.  (Ajánlott) VS Code Kiegészítők
    * `PHP Intelephense` (a kódkiegészítéshez)
    * `PHPUnit Test Explorer` (a tesztek grafikus futtatásához)

A projekt klónozása után a PHP függőségeket (pl. a PHPUnit-ot telepítened kell. A Git nem tárolja ezeket a csomagokat, csak a `composer.json` fájlt, ami leírja, hogy mire van szükség.

1.  Nyiss egy terminált a projekt gyökérmappájában.
2.  Futtasd a következő parancsot a `vendor` mappa létrehozásához és az összes függőség letöltéséhez:

    ```bash
    composer install
    ```

# Emlékeztető

## Java

```java
@Test
public void method_should_do_something() {
  // given
  Code tested = ...;
  // when
  Object result = tested.method();
  // then
  assertThat(result).isNotNull();
}
```

## Typescript

```typescript
describe('Code', () => {

  let tested: Code = new Code();

  it('should do something', () => {
    // given
    ...
    // when
    let result: any = tested.method();
    // then
    expect(result).not.toBeNull();
  });
});
```

## C#
Tesztek futtatásához:

```
dotnet test src/test/csharp/dojo.Tests
```

## PHP

A legegyszerűbb és legbiztosabb módja a tesztek futtatásának. A projekt gyökeréből futtasd:

```bash
# macOS/Linux:
./vendor/bin/phpunit

# Windows:
vendor\bin\phpunit
```
