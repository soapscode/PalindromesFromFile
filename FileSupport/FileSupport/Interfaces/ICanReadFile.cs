
namespace FileSupport.Interfaces
{
    public interface ICanReadFile
    {
        /// <summary>
        /// Returns a collection of strings from the lines in the specified file.
        /// </summary>
        /// <param name="filePath">The full file name, which may be preceeded by the path if necessary.</param>
        /// <returns>A collection of strings restrieved from the file.</returns>
        IEnumerable<string> GetLines(string filePath);
    }
}