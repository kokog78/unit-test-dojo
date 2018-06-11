# Projekt előkészítés

## Java

IntelliJ: `pom.xml` > Add as Maven Project > ...

Eclipse: Import > Maven > Existing Maven Projects > ...

Fájlok

```
src/main/java/dojo/Parser.java
src/main/resources/dojo/parser.txt
src/test/java/dojo/ParserTest_JUnit.java   // JUnit tesztekhez
src/test/java/dojo/ParserTest_TestNG.java  // TestNG tesztekhez
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

Fájlok

```
src/main/javascript/parser.js   // a produkciós kód javascript nyelven íródott
src/main/javascript/data.js
src/test/typescript/parser.spec.ts
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
before('Code', () => {

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