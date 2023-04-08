using CopyCodeFromTheDirectory;
using CopyCodeFromTheDirectory.WorkWithTheFile;
class Program {
  static void Main() {
    DirectoryInfo directory = InputDirectory.EnterDirectory();
    string extension = WriteExtension.writeExtension();
    Dictionary<string, List<String>> files = CopyFiles.GetFiles(directory, extension);
    SaveFile.SaveToWord(files);
  }
}