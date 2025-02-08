using FileSupport.Interfaces;
using Moq;
using NUnit.Framework;

namespace StringOperations.Tests
{


    [TestFixture]
    public class PalindromeShould
    {
        private readonly List<string> _containsPalindromes = new() { "Repaper", "Radar", "Madam", "Escape", "Level", "Racecar", "Noon", "Turntable", "Rotator", "Wow" };
        private readonly List<string> _palindromes = new() { "Repaper", "Radar", "Madam", "Level", "Racecar", "Noon", "Rotator", "Wow" };
        private readonly List<string> _nonPalindromes = new() { "Escape", "River", "Porcupine", "Telescope", "Escalate", "Turntable" };
        private readonly string _testFolder = "Tests";
        private readonly string _inputFile = "WordsFile.txt";
        private readonly string _inputFileNoPalindromes = "WordsFileNoPalindromes.txt";
        private readonly string _outputFile = "Output.txt";

        [Test]
        [TestCase("As2//d")]
        [TestCase("235")]
        [TestCase("4325113")]
        [TestCase("28340")]
        [TestCase("df//%55")]
        [TestCase("!w/?mlm")]
        [TestCase("Eclipse")]
        [TestCase("Spoon")]
        [TestCase("Table")]
        [TestCase("4leT45")]
        [TestCase("Escape")]
        [TestCase("River")]
        [TestCase("Porcupine")]
        [TestCase("Telescope")]
        [TestCase("Escalate")]
        [TestCase("Turntable")]
        public void ReturnFalseWhenWordNotAPalindrome(string word)
        {
            var palindrome = new Palindrome();

            var result = palindrome.IsPalindrome(word);
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("Repaper")]
        [TestCase("Radar")]
        [TestCase("Madam")]
        [TestCase("Level")]
        [TestCase("Racecar")]
        [TestCase("Noon")]
        [TestCase("Rotator")]
        [TestCase("Wow")]
        public void ReturnTrueGivenWordIsAPalindrome(string word)
        {
            var palindrome = new Palindrome();

            var result = palindrome.IsPalindrome(word);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnNoWordsGivenNoPalindromes()
        {
            var palindrome = new Palindrome();

            var result = palindrome.GetPalindromeWords(_nonPalindromes);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void ReturnWordsGivenThereArePalindromes()
        {
            var palindrome = new Palindrome();

            var result = palindrome.GetPalindromeWords(_containsPalindromes);
            Assert.That(result.Count(), Is.EqualTo(_palindromes.Count));
        }

        [Test]
        public void ReturnNumberOfWordsGivenFilesWithNoPalindromes()
        {
            var inputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _inputFileNoPalindromes);
            var resultsFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _outputFile);

            var handlerMoq = new Mock<IFileArgumentsHandler>();
            handlerMoq.Setup(hm => hm.IsValidFileArguments(inputFile, resultsFile)).Returns(true);
            handlerMoq.Setup(hm => hm.GetLines(inputFile)).Returns(new List<string> { });

            var palindrome = new Palindrome(handlerMoq.Object);
            var result = palindrome.GetPalindromesFromFile(inputFile, resultsFile);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ReturnNumberOfWordsGivenFilesWithPalindromes()
        {
            var inputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _inputFile);
            var resultsFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _outputFile);

            var handlerMoq = new Mock<IFileArgumentsHandler>();
            handlerMoq.Setup(hm => hm.IsValidFileArguments(inputFile, resultsFile)).Returns(true);
            handlerMoq.Setup(hm => hm.GetLines(inputFile)).Returns(_palindromes);

            var palindrome = new Palindrome(handlerMoq.Object);
            var result = palindrome.GetPalindromesFromFile(inputFile, resultsFile);

            Assert.That(result, Is.EqualTo(_palindromes.Count));
        }
    }
}
