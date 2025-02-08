The FileSupport library so far provides functionality to validate file arguments and some read/writes with collections of string.

===== FileArgumentsHandler.cs ==========
This class implements IFileArgumentsHandler interface, which implements the ICanReadFile, ICanValidateFile and ICanWriteFile interfaces (all in the Interfaces folder).
This class includes functionality to validate input file and result file arguments and also functionality to read strings (in lines) from the input file and output a collection of strings to the result file.
Methods:
- IsValidFileArguments - Validates the input file and results file arguments. Input file must exist, output file doesn't have to exist and it can be created - as long as it's path exists and the file name is valid.
- IsExistingFile - Returns True if the specified file exists.
- ISExistingPath - Returns True if the path from the specified file name exists.
- IsExistingFileOrPath - Returns True if either the specified file exists or the path from the specified file name exists
- CreateResultsFile - Creates the specified file.  This method will be invoked to create the results file - if the results file doesn't exist, but has a path which does exist.
- GetLines - Reads the lines of a specified file and returns the lines in a collection of strings.
- WriteLinesToFile - Writes a provided collection of strings, as lines, to a specified file.

===== FileArgumentsHandler.cs =====
This class in the Tests folder contains the NUnit unit tests for the FileArgumentsHandler functionality.
Also in the Tests folder are some files used for testing the functionality:
- WordsFile.txt - contains a list of strings.
- Output.txt - empty file to store the results.