using NUnit.Framework;

namespace FileSupport.Tests
{
    [TestFixture]
    public class FileArgumentsHandlerShould
    {
        private readonly List<string> _fileLines = new() { "Wow", "RaceCar", "Madam" };
        private readonly string _testFolder = "Tests";
        private readonly string _inputFile = "WordsFile.txt";
        private readonly string _outputFile = "Output.txt";
        private readonly string _nonExistingPath = @"C:\arandompath";

        private void RemoveTempFiles()
        {
            var files = new List<string>
            { "FileDoesNotExist.txt",
                "ResultFilePathExistsNoFile.txt",
                "NonExistingInputFileTest.txt",
                "IsValidArgumentsPathButNoFile.txt",
                "GetLinesFileNotFoundOne.txt",
                "WriteLinesFileNotFoundOne.txt"
            };

            foreach (var file in files)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, file);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        [OneTimeSetUp]
        public void Init()
        {
            RemoveTempFiles();
        }

        #region FilePath
        [Test]
        [TestCase("WordsFile.txt")]
        [TestCase("madeup.txt")]
        public void ReturnTrueGivenPathExists(string fileName)
        {
            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, fileName);

            var result = handler.IsExistingPath(filePath);
            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("WordsFile.txt")]
        [TestCase("madeup.txt")]
        public void ReturnFalseGivenPathDoesntExist(string fileName)
        {
            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(_nonExistingPath, _testFolder, fileName);

            var result = handler.IsExistingPath(filePath);
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("WordsFile.txt")]
        public void ReturnTrueGivenFileExists(string fileName)
        {
            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, fileName);

            var result = handler.IsExistingFile(filePath);
            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("", "FileDoesNotExist.txt")]
        [TestCase(@"C:\arandompath", "FileDoesNotExist.txt")]
        public void ReturnFalseGivenFileDoesntExist(string pathName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(pathName))
            {
                pathName = Directory.GetCurrentDirectory();
            }

            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(pathName, _testFolder, fileName);

            var result = handler.IsExistingFile(filePath);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ReturnTrueGivenPathExistsAndFileExists()
        {
            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _inputFile);

            var result = handler.IsExistingFileOrPath(filePath);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnTrueGivenPathExistsAndFileDoesntExist()
        {
            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, "ResultFilePathExistsNoFile.txt");

            var result = handler.IsExistingFileOrPath(filePath);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnFalseGivenPathDoesntExistAndFileDoesntExist()
        {
            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(_nonExistingPath, _testFolder, "NonExistingPathOrFile.txt");

            var result = handler.IsExistingFileOrPath(filePath);
            Assert.That(result, Is.False);
        }
        #endregion

        #region IsValidFileArguments
        [Test]
        public void ReturnTrueInIsValidFileArgumentsWhenFilesExist()
        {
            var handler = new FileArgumentsHandler();
            var inputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _inputFile);
            var outputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _outputFile);

            var result = handler.IsValidFileArguments(inputFile, outputFile);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnFalseWhenInputFilePathDoesntExist()
        {
            var handler = new FileArgumentsHandler();
            var inputFile = Path.Combine(_nonExistingPath, _testFolder, _inputFile);
            var outputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _outputFile);

            Assert.Throws<ArgumentException>(() => handler.IsValidFileArguments(inputFile, outputFile));
        }

        [Test]
        public void RaiseErrorGivenInputFilePathExistsButFileDoesNotExist()
        {
            var handler = new FileArgumentsHandler();
            var inputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, "NonExistingInputFileTest.txt");
            var outputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _outputFile);

            Assert.Throws<ArgumentException>(() => handler.IsValidFileArguments(inputFile, outputFile));
        }

        [Test]
        public void ReturnTrueGivenOutputFilePathExistsButFileDoesNotExist()
        {
            var handler = new FileArgumentsHandler();
            var inputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _inputFile);
            var outputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, "IsValidArgumentsPathButNoFile.txt");

            var result = handler.IsValidFileArguments(inputFile, outputFile);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnFalseGivenOutputFilePathDoesNotExist()
        {
            var handler = new FileArgumentsHandler();
            var inputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _inputFile);
            var outputFile = Path.Combine(_nonExistingPath, _testFolder, _outputFile);

            Assert.Throws<ArgumentException>(() => handler.IsValidFileArguments(inputFile, outputFile));
        }

        [Test]
        public void RasieErrorGivenOutputFilePathExistsButNoFilePermission()
        {
            var handler = new FileArgumentsHandler();
            var inputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _inputFile);
            var outputFile = Path.Combine(@"C:\Windows\system32", "Madeup.txt");

            Assert.Throws<Exception>(() => handler.IsValidFileArguments(inputFile, outputFile));
        }

        [Test]
        public void RasieErrorGivenOutputFilePathExistsButInvalidFileName()
        {
            var handler = new FileArgumentsHandler();
            var inputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _inputFile);
            var outputFile = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, @"///\|*");

            Assert.Throws<ArgumentException>(() => handler.IsValidFileArguments(inputFile, outputFile));
        }

        #endregion

        #region ReadWriteFile

        [Test]
        public void ReturnLinesGivenValidFile()
        {
            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _inputFile);

            var results = handler.GetLines(filePath).ToList();
            Assert.That(results.Any(), Is.True);
            Assert.That(results.Count(), Is.EqualTo(24));
        }

        [Test]
        [TestCase("", "GetLinesFileNotFoundOne.txt")]
        [TestCase(@"C:\arandompath", "GetLinesFileNotFoundTwo.txt")]
        public void RaiseErrorInGetLinesGivenFileDoesntExist(string pathName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(pathName))
            {
                pathName = Directory.GetCurrentDirectory();
            }

            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(pathName, _testFolder, fileName);

            Assert.Throws<FileNotFoundException>(() => handler.GetLines(filePath).ToList());
        }

        [Test]
        public void WriteLinesGivenFileThatExists()
        {
            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _testFolder, _outputFile);

            handler.WriteLinesToFile(filePath, _fileLines);

        }

        [Test]
        [TestCase("", "WriteLinesFileNotFoundOne.txt")]
        [TestCase(@"C:\arandompath", "WriteLinesFileNotFoundTwo.txt")]
        public void RaiseErrorInWriteLinesToFileGivenResultsFileDoesntExist(string pathName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(pathName))
            {
                pathName = Directory.GetCurrentDirectory();
            }

            var handler = new FileArgumentsHandler();
            var filePath = Path.Combine(pathName, _testFolder, fileName);

            Assert.Throws<FileNotFoundException>(() => handler.WriteLinesToFile(filePath, _fileLines));
        }

        #endregion
    }
}
