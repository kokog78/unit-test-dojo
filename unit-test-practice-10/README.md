# Szituáció

Útvonal egységesítő és feloldó eszközök írása.

Felhasználási területek:

 - Fájlrendszer hivatkozások feloldása
 - Hivatkozások feloldása egy objektumfában
 - XPATH-szerű keresések egy dokumentumon belül

## Útvonal egységesítő eszköz írása

A `normalize(...)` metódus kap egy *abszolút* útvonalat, amit egységes formába hoz.
Az útvonal olyan sztring, amiben az egyes útvonal-részeket `/` karakter választja el egymástól.
Az abszolút útvonal maga is `/` karakterrel kezdődik. A `normalize(...)` metódus felismeri a
`.` és a `..` útvonal-részeket. A `.` mindig az aktuális útvonalat jelenti, a `..` pedig az egy
szinttel magasabban levőt.

Példák:

| Paraméter  | Eredmény   |
| ---------- | ---------- |
| /a/b/..    | /a         |
| /a/./b     | /a/b       |

A `normalize(...)` metódus hibát dob, ha a megadott paramétert nem lehet egységes útvonallá
alakítani.

## Útvonal feloldó eszköz írása

A `resolve(..., ...)` metódus egyesítí a paraméterében megadott két útvonalat, és az eredményt egységes formában
visszaadja. Az első paramétere egy *abszolút* útvonal, a második pedig egy *relatív* (ami nem `/` katakterrel kezdődik).

Példák:

| 1. paraméter | 2. paraméter | Eredmény   |
| ------------ | ------------ | ---------- |
| /a/b         | c            | /a/b/c     |
| /a/b         | ./c          | /a/b/c     |
| /a/b         | ../c         | /a/c       |

Az első paraméter természetesen tartalmazhat `.` és `..` útvonal-részeket is. Maga a `resolve(..., ...)` metódus használhatja a
`normalize(...)` metódust.

# Projekt előkészítés

## Java

IntelliJ: `pom.xml` > Add as Maven Project > ...

Eclipse: Import > Maven > Existing Maven Projects > ...

Fájlok

```
src/main/java/dojo/PathResolver.java
src/test/java/dojo/PathResolverTest.java
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
src/main/typescript/path-resolver.ts
src/test/typescript/path-resolver.spec.ts
```

## PHP

Mielőtt elkezdenéd, a következő eszközökre lesz szükséged a gépeden:

1.  PHP 8.0+
    * Ellenőrzés: `php -v`
    * Javaslat (Windows): A legegyszerűbb módja az [XAMPP](https://www.apachefriends.org/hu/index.html) telepítése. Ez automatikusan telepíti a PHP-t. Fontos, hogy ne védett könyvtárba történjen a telepítés. A telepítés után ne felejtsd el hozzáadni a telepítési mappát a Windows `PATH` környezeti változóihoz.
2.  Composer
    * Ellenőrzés: `composer -V`
    * Telepítés: Kövesd a [hivatalos telepítési útmutatót](https://getcomposer.org/download/). Ez a PHP csomagkezelője.
3.  (Ajánlott) VS Code Kiegészítők
    * `PHP Intelephense` (a kódkiegészítéshez)
    * `PHPUnit Test Explorer` (a tesztek grafikus futtatásához)

A projekt klónozása után a PHP függőségeket (pl. a PHPUnit-ot) telepítened kell. A Git nem tárolja ezeket a csomagokat, csak a `composer.json` fájlt, ami leírja, hogy mire van szükség.

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
Vagy ha telepítve van a `PHPUnit Test Explorer` akkor a tesztosztályban lévő play gomb megnyomásával.

# Kódlefedettség Beállítása PHP-hoz

Ahhoz, hogy a PHPUnit kódlefedettségi (coverage) riportokat tudjon generálni, szüksége van egy PHP kiterjesztésre, az **Xdebug**-ra.

### 1. Lépés: A `php.ini` fájl megkeresése

Először meg kell találnod, hogy a parancssor melyik `php.ini` konfigurációs fájlt használja.

1.  Nyiss egy terminált.
2.  Futtasd a következő parancsot:
    ```bash
    php --ini
    ```
3.  Keresd meg a `Loaded Configuration File:` sort a kimenetben. Ez megadja a fájl pontos elérési útját (pl. `C:\xampp\php\php.ini`).
4.  Nyisd meg ezt a fájlt egy szövegszerkesztőben (pl. VS Code).

### 2. Lépés: Az Xdebug Engedélyezése

#### A. Eset: Az Xdebug már szerepel a fájlban (de ki van kapcsolva)

Ez a gyakoribb eset XAMPP telepítéseknél.

1.  Keress rá (Ctrl+F) a `zend_extension=xdebug` (vagy `zend_extension=php_xdebug.dll`) sorra.
2.  Valószínűleg ki van kommentelve egy pontosvesszővel (`;`) a sor elején:
    ```ini
    ;zend_extension=xdebug
    ```
3.  Töröld a pontosvesszőt a sor elől, hogy élesítsd:
    ```ini
    zend_extension=xdebug
    ```
4.  Keress rá az `xdebug.mode` sorra. Ha nincs, add hozzá.
5.  Állítsd az értékét `coverage`-re:
    ```ini
    xdebug.mode = coverage
    ```
    *(Tipp: Ha később lépésenkénti hibakeresést (step-debugging) is szeretnél használni, állítsd `debug,coverage`-re.)*


#### B. Eset: Az Xdebug nem szerepel a fájlban

Ha a keresés nem ad találatot, manuálisan kell hozzáadnod.

1.  Ellenőrizd, hogy a fájl létezik-e:
    * Keresd meg a PHP kiterjesztések (extensions) mappáját. Ez általában a `php.ini` mellett, egy `ext` nevű mappában van (pl. `C:\xampp\php\ext\`).
    * Keresd meg a `php_xdebug.dll` nevű fájlt.

2.  Ha a `php_xdebug.dll` **LÉTEZIK**:
    * Görgess a `php.ini` fájl legaljára.
    * Illeszd be a következő sorokat:
        ```ini
        [Xdebug]
        zend_extension=xdebug
        xdebug.mode = coverage
        ```

3.  Ha a `php_xdebug.dll` **NEM LÉTEZIK**:
    * Akkor manuálisan kell letöltened a megfelelő verziót.
    * Nyisd meg a terminált, és futtasd: `php -i`
    * Másold ki a teljes kimenetet (az összes szöveget).
    * Nyisd meg az Xdebug "Varázsló" oldalát: [https://xdebug.org/wizard](https://xdebug.org/wizard)
    * Illeszd be a kimásolt szöveget a nagy szövegdobozba, és nyomj "Analyse".
    * Az oldal pontos utasításokat ad: letölti a megfelelő `.dll` fájlt (amit be kell másolnod `php_xdebug.dll` néven az `ext` mappába), és megmondja, mely sorokat kell a `php.ini` végére illesztened.
    * Győződj meg róla, hogy a `php.ini`-be írt sorok tartalmazzák az `xdebug.mode = coverage` beállítást.

### 3. Lépés: Ellenőrzés

1.  Mentsd el a `php.ini` fájlt.
2.  Indítsd újra a VS Code-ot és a benne futó terminálokat.
3.  Nyiss egy új terminált, és futtasd:
    ```bash
    php -v
    ```
4.  Ha sikeres voltál, a kimenetnek tartalmaznia kell egy plusz sort:
    ```
    PHP 8.2.12 (cli) ...
    Copyright (c) The PHP Group
    Zend Engine v4.2.12, Copyright (c) Zend Technologies
        with Xdebug v3.3.1, Copyright (c) 2002-2023, by Derick Rethans
    ```
Ha látod a `with Xdebug` sort, a kódlefedettség-mérés működni fog.