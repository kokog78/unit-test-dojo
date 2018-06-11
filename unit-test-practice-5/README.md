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

Fájlok

```
src/main/typescript/password-verifier.ts
src/test/typescript/password-verifier.spec.ts
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