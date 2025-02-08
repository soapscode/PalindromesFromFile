

using FileSupport.Interfaces;
using StringOperations.Interfaces;

namespace StringOperations
{
    /// <summary>
    /// This class includes the functionality to detect palindromes from a string, collection of strings, or from a file.
    /// </summary>
    public class Palindrome : IPalindrome
    {
        private readonly IFileArgumentsHandler? _fileArgumentsHandler;
        public Palindrome(IFileArgumentsHandler fileArgumentsHandler)
        {
            _fileArgumentsHandler = fileArgumentsHandler;
        }

        public Palindrome()
        {
        }

        public int GetPalindromesFromFile(string wordsFile, string resultsFile)
        {
            //establish if file locations exist and if so return List
            if (ReferenceEquals(null, _fileArgumentsHandler) || !_fileArgumentsHandler.IsValidFileArguments(wordsFile, resultsFile))
            {
                return 0;
            }

            var inputWords = _fileArgumentsHandler.GetLines(wordsFile);

            //Use List to return a List of Palindromes
            var palindromeWords = GetPalindromeWords(inputWords);

            //Write these to the results file
            _fileArgumentsHandler.WriteLinesToFile(resultsFile, palindromeWords);

            return palindromeWords.Count();
        }

        public IEnumerable<string> GetPalindromeWords(IEnumerable<string> words)
        {
            var palindromeWords = new List<string>();

            if (!words.Any())
            {
                return palindromeWords;
            }

            foreach (var word in words)
            {
                if (IsPalindrome(word))
                {
                    palindromeWords.Add(word);
                }
            }

            return palindromeWords;
        }

        public bool IsPalindrome(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }

            word = word.Trim();
            var length = word.Length;
            var midPoint = length / 2;

            // Move left pointer from start to mid point of the word &
            // right pointer from the end to the mid point. Compare the two
            for (int i = 0; i < midPoint; i++)
            {
                if (!char.IsLetterOrDigit(word[i]) || !char.IsLetterOrDigit(word[length - i - 1]) ||
                    char.ToUpperInvariant(word[i]) != char.ToUpperInvariant(word[length - i - 1]))
                    return false;
            }

            return true;
        }
    }
}
