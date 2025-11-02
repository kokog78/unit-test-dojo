# Projekt előkészítés

## Java

IntelliJ: Open > Open as Gradle project

Eclipse: Import > Gradle > Existing Gradle Project

Fájlok

```
src/main/java/dojo/ComparableVersion.java
src/test/java/dojo/ComparableVersionTest.java
```

Fordítás parancssorból:

```
gradlew classes testClasses
```

vagy:

```
./gradlew classes testClasses
```

## C#

A projekt fordításához egyszer le kell futtatni a teszteket:

```
cd src\test\csharp\dojo.Tests
dotnet test
```

vagy:

```bash
cd src/test/csharp/dojo.Tests
dotnet test
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
## C#

```csharp
[Test]
public void Method_should_do_something()
    {
      // given
      Code tested = ...;
      // when
      Object result = tested.Method();
      // then
      result.Should().BeNull();
    }
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