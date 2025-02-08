
namespace FileSupport.Interfaces
{
    public interface ICanWriteFile
    {
        /// <summary>
        /// Writes the provided collection of strings to the specified file.
        /// </summary>
        /// <param name="filePath">The full file name, which may be preceeded by the path if necessary.</param>
        /// <param name="fileLines">The collection of strings to write to the file.</param>
        void WriteLinesToFile(string filePath, IEnumerable<string> fileLines);
    }
}