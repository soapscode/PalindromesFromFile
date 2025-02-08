namespace StringOperations.Interfaces
{
    public interface IPalindrome
    {
        /// <summary>
        /// Return all palindromes from words listed in wordsFile and write them to resultsFile.
        /// </summary>
        /// <param name="wordsFile">Input file containing a list of words.</param>
        /// <param name="resultsFile">The output file which will contain all palindromes from wordsFile.</param>
        /// <returns>The number of pallindromes found.</returns>
        int GetPalindromesFromFile(string wordsFile, string resultsFile);
        
        /// <summary>
        /// Return a collection palindromes from the collection of strings provided.
        /// </summary>
        /// <param name="words">The collection of words to examine.</param>
        /// <returns>The collection of palindromes.</returns>
        IEnumerable<string> GetPalindromeWords(IEnumerable<string> words);

        /// <summary>
        /// Establishes if the provided string is a palindrome and contains only alphanumeric characters.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>True if the string is a palindrome and contains only alphanumeric characters.</returns>
        bool IsPalindrome(string word);
    }
}