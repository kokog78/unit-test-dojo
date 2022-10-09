# Projekt előkészítés

## Java

IntelliJ: Open > Open as Gradle project

Eclipse: Import > Gradle > Existing Gradle Project

Fájlok

```
src/main/java/dojo/Parser.java
src/main/resources/dojo/parser.txt
src/test/java/dojo/ParserTest_JUnit.java   // JUnit tesztekhez
src/test/java/dojo/ParserTest_TestNG.java  // TestNG tesztekhez
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
