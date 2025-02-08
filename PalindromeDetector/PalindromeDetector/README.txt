PalindromeDetector is a Console application which detects palindromes in the input file specified and outputs any palindromes that were found to the specified results file.
The application accepts two file arguments:
- input file - This will be the name of a text file which can contain strings on each line.  If the file does not reside in the exe directory, the full path and file name must be provided.
- results file - This will be a text file where the results will be added. The file does not have to exist, as the application can create the file - but if a path is provided, that path must exist and the file name must be a valid file name.

===== Example Usage =====
The application can be run from the command line with the pattern: 
PalindromeDetector.exe {inputfile} {resultsfile}

Example if the input file exists in the same path as PalindromeDetector.exe:
PalindromeDetector.exe WordsFile.txt Output.txt

Example if files should be in a different directory to PalindromeDetector.exe :
PalindromeDetector.exe C:\Temp\WordsFile.txt C:\Temp\Output.txt

===== Testing ===========
The application can be run from Visual Studio with parameters for the files included with the PalindromeDetector project:
- WordsFile.txt - contains a list of strings (including 8 palindromes).
- Output.txt - empty file to store the results.
