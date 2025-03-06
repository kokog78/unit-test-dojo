namespace dojo;

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

/**
 * Merges the given gitignore file with the stored template.
 * Rules:
 * <ul>
 * <li>Every path specified in the template should be in the result.</li>
 * <li>If the file already has a path from the template, it should not be added to it.</li>
 * <li>New paths should be added to the end of the file.</li>
 * </ul>
 */
public class GitignoreMergeTool
{
	/**
	 * Merges the given gitignore file with the stored template.
	 * If the file does not exists, it just creates it and copies the template's content into it.
	 * If the file cannot be created or updated, it throws an {@link IOException}.
	 * @param file the file to be merged
	 */
     
    public void Merge(string filePath)
    {
        //TODO
    }

    private Stream GetTemplate()
    {
        return File.OpenRead("gitignore");
    }

}
