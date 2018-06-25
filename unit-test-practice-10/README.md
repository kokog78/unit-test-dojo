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
+------------+------------+
| /a/b/..    | /a         |
| /a/./b     | /a/b       |

A `normalize(...)` metódus hibát dob, ha a megadott paramétert nem lehet egységes útvonallá
alakítani.

## Útvonal feloldó eszköz írása

A `resolve(..., ...)` metódus egyesítí a paraméterében megadott két útvonalat, és az eredményt egységes formában
visszaadja. Az első paramétere egy *abszolút* útvonal, a második pedig egy *relatív* (ami nem `/` katakterrel kezdődik).

Példák:

| 1. paraméter | 2. paraméter | Eredmény   |
+--------------+--------------+------------+
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