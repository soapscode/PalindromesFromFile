namespace FileSupport.Interfaces
{
    public interface ICanValidateFile
    {
        /// <summary>
        /// Establishes whether the specified file exists.
        /// </summary>
        /// <param name="filePath">The full file, which may be preceeded by the path if necessary.</param>
        /// <returns>True if the specified file exists.</returns>
        bool IsExistingFile(string filePath);

        /// <summary>
        /// Establishes whether the specified file exists, or the path in which the file will reside, exists.
        /// </summary>
        /// <param name="filePath">The full file, which may be preceeded by the path if necessary.</param>
        /// <returns>True if the specified file exists, or the path in which the file will reside, exists.</returns>
        bool IsExistingFileOrPath(string filePath);

        /// <summary>
        /// Establishes whether the path of the specified file exists.
        /// </summary>
        /// <param name="filePath">The full file name, which may be preceeded by the path if necessary.</param>
        /// <returns>True if the specified path exists.</returns>
        bool IsExistingPath(string filePath);

        /// <summary>
        /// Establishes whether the file arguments provided are valid.
        /// </summary>
        /// <param name="inputFile">The full file name of the input file, which may be preceeded by the path if necessary.</param>
        /// <param name="resultsFile">The full file name of the results file, which may be preceeded by the path if necessary.</param>
        /// <returns>True if all arguments are valid.</returns>
        bool IsValidFileArguments(string inputFile, string resultsFile);
    }
}