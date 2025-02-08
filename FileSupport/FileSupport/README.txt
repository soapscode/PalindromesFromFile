The StringOperations library so far provides functionality to detect palindromes, along with some simple file argument checks.

===== Palindrome.cs =====
This class includes the functionality to detect palindromes in a number of ways, via the following methods:
- IsPalindrome - returns True if the string provided is a Palindrome.
- GetPalindromeWords - returns a collection of palindrome strings detected from the collection of strings provided.
- GetPalindromesFromFile - Makes use of IFileArgumentsHandler in order to examines each line in the provided file and writes any lines that are detected to be palindromes to the provided results file.
