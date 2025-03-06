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
Tesztek futtatásához:

```
dotnet test src/test/csharp/dojo.Tests
```
