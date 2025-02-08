PalindromeDetector is a Console application which detects palindromes in the input file specified and outputs any palindromes that were found to the specified results file.

The StringOperations and FileSupport project folders will need to be pulled to the same folder as PalindromeDetector solution includes references to these library projects.

The application accepts two file arguments:
- input file - This will be the name of a text file which can contain strings on each line.  If the file does not reside in the exe directory, the full path and file name must be provided.
- results file - This will be a text file where the results will be added. The file does not have to exist, as the application can create the file - but if a path is provided, that path must exist and the file name must be a valid file name.

===== Usage ========

The application can be run from the command line with the pattern: PalindromeDetector.exe {inputfile} {resultsfile}


===== Examples =====

PalindromeDetector.exe WordsFile.txt Output.txt

PalindromeDetector.exe C:\Temp\WordsFile.txt C:\Temp\Output.txt
