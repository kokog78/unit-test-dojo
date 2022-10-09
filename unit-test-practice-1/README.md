# Projekt előkészítés

## Java

IntelliJ: Open > Open as Gradle project

Eclipse: Import > Gradle > Existing Gradle Project

Fájlok

```
src/main/java/dojo/StringTemplate.java
src/test/java/dojo/StringTemplateTest.java
```

Fordítás parancssorból:

```
gradlew classes testClasses
```

vagy:

```
./gradlew classes testClasses
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
