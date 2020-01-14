# Unit test dojo #11

The task of this dojo is to create a tool (few java classes) with test-first approach.
Before you start, do some planning about the tests.

## About the tool

This will be used to merge a gitignore file with a predefined template. The file may or may not exist.

A gitignore file contains relative file system paths (directories and/or files). Each non-empty line is considered as a path.

During the merge, you need to load the file's content and the template's content, and overwrite the file with the merged result.

Rules to create the result:

- If a path is in the input file, it should be in the result too, in the same position.
- If a path is in the template but not in the input file, should be added to the end of the result.

## Classes

`dojo.gitignore.GitignoreMergeTool`: this is the tool you will implement.

`dojo.gitignore.GitignoreMergeToolTest`: here you will write your tests.

## Phases

### Phase #1: planning

Your API depends on the `File` class. It receives a `File` instance. Do you want to mock it or not? If yes, how?
If not, how will you be able to specify the file content in your tests?

The template is coming from a java resource, as an `InputStream`. Do you want to mock it or not? If yes, how? If not, why?

What do you think: will you need some support methods in your test class to handle files and templates?

### Phase #2: implementation

Now you implement the tool. Try to write a test before you implement a small addition to your production code!
Between the code additions, do some refactor - in the production code AND in the test code!

Do NOT build a starship at the beginning. Even if you see that you will need some code later (because you planned it), don't
create it until you really need it!

Code coverage with your tests should be 100%.

### Phase #3: extract stream merging tool

Extract a new class which can be used to merge two `InputStream`s together, and write the result into an `OutputStream`!
Use you tests to support your refactoring - do not write any new test!
Before you start the extraction, reshape your original class to have similar methods you will need in the new class!
