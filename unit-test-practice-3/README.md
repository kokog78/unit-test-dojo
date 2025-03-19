# Projekt előkészítés

## Java

### Maven

IntelliJ: `pom.xml` > Add as Maven Project > ...

Eclipse: Import > Maven > Existing Maven Projects > ...

### Gradle

IntelliJ: Open > Open as Gradle project

Eclipse: Import > Gradle > Existing Gradle Project

Fordítás parancssorból:

```
gradlew classes testClasses
```

vagy:

```
./gradlew classes testClasses
```

### Fájlok

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
src/main/javascript/parser.js   // a produkciós kód javascript nyelven íródott
src/main/javascript/data.js
src/test/typescript/parser.spec.ts
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
