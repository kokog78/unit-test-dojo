# Szituáció

Jelszó ellenőrzésére szolgáló osztályka megírása Test Driven Development (TDD) segítségével.

A `verify(...)` metódus kap egy jelszót, amit ellenőriz.
Ha az alábbi feltételek közül bármelyik NEM teljesül, akkor hibát/kivételt dob.

- A jelszó nem <code>null</code>.</li>
- A jelszó legalább 8 karakter hosszú.</li>
- A jelszó tartalmaz legalább egy számot.</li>
- A jelszó tartalmaz legalább egy kisbetűt.</li>
- A jelszó tartalmaz legalább egy nagybetűt.</li>

# Projekt előkészítés

## Java

IntelliJ: `pom.xml` > Add as Maven Project > ...

Eclipse: Import > Maven > Existing Maven Projects > ...

Fájlok

```
src/main/java/dojo/PasswordVerifier.java
src/test/java/dojo/PasswordVerifierTest.java
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
src/main/typescript/password-verifier.ts
src/test/typescript/password-verifier.spec.ts
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
Vagy ha telepítve van a `PHPUnit Test Explorer` akkor a tesztosztályban lévő play gomb megnyomásával.