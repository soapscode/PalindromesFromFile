using FileSupport.Interfaces;

namespace FileSupport
{
    /// <summary>
    /// This class includes functionality to validate input file and result file arguments
    /// and also functionality to read strings (in lines) from the input file and output a collection of strings to the result file.
    /// </summary>
    public class FileArgumentsHandler : IFileArgumentsHandler
    {
        private Dictionary<string, bool> _validatedFiles;
        private bool _resultsFileCreated;

        public FileArgumentsHandler()
        {
            _validatedFiles = new Dictionary<string, bool>();
        }

        public bool IsValidFileArguments(string inputFile, string resultsFile)
        {
            if (!IsExistingFile(inputFile))
            {
                throw new ArgumentException(string.Format("{0} is an invalid input file.", inputFile));
            }

            if (!IsExistingFileOrPath(resultsFile))
            {
                throw new ArgumentException(string.Format("{0} is an invalid results file", resultsFile));
            }

            if (!_resultsFileCreated)
            {
                CreateResultsFile(resultsFile);
            }

            _validatedFiles.Add(inputFile, true);
            _validatedFiles.Add(resultsFile, true);

            return true;
        }

        private void CreateResultsFile(string resultsFile)
        {
            try
            {
                File.Create(resultsFile);
            }
            catch
            {
                throw new Exception(string.Format("Could not create results file {0}", resultsFile));
            }
        }

        public IEnumerable<string> GetLines(string filePath)
        {
            if (!_validatedFiles.Keys.Contains(filePath) && !IsExistingFile(filePath))
            {
                throw new FileNotFoundException(string.Format("{0} is an invalid input file.", filePath));
            }

            IEnumerable<string> fileLines = File.ReadAllLines(filePath);
            return fileLines.AsEnumerable();
        }

        public void WriteLinesToFile(string filePath, IEnumerable<string> fileLines)
        {
            if (!_validatedFiles.Keys.Contains(filePath) && !IsExistingFile(filePath))
            {
                throw new FileNotFoundException(string.Format("{0} is an invalid input file.", filePath));
            }

            File.WriteAllLines(filePath, fileLines);
        }

        public bool IsExistingFileOrPath(string filePath)
        {
            if (IsExistingFile(filePath))
            {
                _resultsFileCreated = true;
                return true;
            }

            //file doesn't exist, now check the path exists
            return IsExistingPath(filePath);
        }

        public bool IsExistingPath(string filePath)
        {
            var path = String.Empty;

            try
            {
                path = Path.GetDirectoryName(filePath);
            }
            catch
            {
                return false;
            }

            return Path.Exists(path);
        }

        public bool IsExistingFile(string filePath)
        {
            try
            {
                var test = new FileInfo(filePath);
                return File.Exists(filePath);
            }
            catch
            {
                return false;
            }
        }
    }
}
