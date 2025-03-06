namespace dojo;

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Merges the given .gitignore file with the stored template.
/// Rules:
/// <list type="bullet">
/// <item>Every path specified in the template should be in the result.</item>
/// <item>If the file already has a path from the template, it should not be added to it.</item>
/// <item>New paths should be added to the end of the file.</item>
/// </list>
/// </summary>
public class GitignoreMergeTool
{
    /// <summary>
    /// Merges the given .gitignore file with the stored template.
    /// If the file does not exist, it just creates it and copies the template's content into it.
    /// If the file cannot be created or updated, it throws an IOException.
    /// </summary>
    /// <param name="filePath">The path of the file to be merged.</param>
    public void Merge(string filePath)
    {
        //TODO
    }

    private Stream GetTemplate()
    {
        return File.OpenRead("gitignore");
    }

}
