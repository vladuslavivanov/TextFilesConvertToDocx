using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCodeFromTheDirectory.WorkWithTheFile {
  internal class CopyFiles {
    static public Dictionary<string, List<string>> GetFiles(DirectoryInfo directory, in string expansion) {
      Dictionary<string, List<string>> files = new Dictionary<string, List<string>>();
      RecursionSearchFiles(directory, expansion, ref files);
      return files;
    }
    static private void InsertFilesFromThisFolder(ref Dictionary<string, List<string>> files,
                                                  IEnumerable<FileInfo> filesInDirectory,
                                                  in string expansion) {
      foreach(var file in filesInDirectory) {
        if (expansion == file.Extension) {
          StreamReader text = file.OpenText();
          List<string> textStr = readFile(text);
          if (files.ContainsKey(file.Name)) {
            if (files[file.Name] != textStr) {
              files.Add(file.FullName, textStr);
            }
            else continue;
          }
          else files.Add(file.Name, textStr);
        }
      }
    }

    static private List<string> readFile(StreamReader text) {
      List<string> file = new List<string>();
      string? str = text.ReadLine()!;
      while (!(str == null)) {
        file.Add(str);
        str = text.ReadLine();
      }
      return file;
    }

    static private void RecursionSearchFiles(DirectoryInfo directory,
                                            string expansion,
                                            ref Dictionary<string, List<string>> files) {
      IEnumerable<DirectoryInfo> folders = directory.EnumerateDirectories();
      int countFolders = folders.Count(folders => folders.Name.ToString().Length > 0);
      if (countFolders != 0) {
        foreach (var folder in folders) {
          RecursionSearchFiles(folder, expansion, ref files);
        }
      }
      IEnumerable<FileInfo> filesInDirectory = directory.EnumerateFiles();
      InsertFilesFromThisFolder(ref files,filesInDirectory, expansion);
    }
  }
}
