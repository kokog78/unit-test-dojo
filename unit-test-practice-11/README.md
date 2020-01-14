# Unit test dojo #11

The task of this dojo is to create a tool (few java classes) with test-first approach.
Before you start, do some planning about the test.

## About the tool

This will be used to merge a gitignore file with a predefined template. The file may or may not exist.

A gitignore file contains relative file system paths (directories and/or files). Each non-empty line is considered as a path.

During the merge, you need to load the file's content and the template's content, and overwrite the file with the merged result.

Rules to create the result:

- If a path is in the input file, it should be in the result too, in the same position.
- If a path is in the template but not in the input file, should be added to the end of the result.

## About the planning

Your API depends on the `File` class. It receives a `File` instance. Do you want to mock it or not? If yes, how?
If not, how will you be able to specify the file content in your tests?

The template is coming from a java resource, as an `InputStream`. Do you want to mock it or not? If yes, how? If not, why?

What do you think: will you need some support methods in your test class to handle files and templates?
