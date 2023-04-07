using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCodeFromTheDirectory.WorkWithTheFile {
  internal class CopyFiles {
    
    static public Dictionary<string, List<string>> GetFiles(DirectoryInfo directory, in string expansion) {
      Dictionary<string, List<string>> files = new Dictionary<string, List<string>>();
      IEnumerable<DirectoryInfo> folders = directory.EnumerateDirectories();
      IEnumerable<FileInfo> filesInDirectory =  directory.EnumerateFiles();
      InsertFilesFromThisFolder(files, filesInDirectory, expansion);
      foreach (var catalogItem in folders) {
        filesInDirectory = catalogItem.GetFiles();
        InsertFilesFromThisFolder(files, filesInDirectory, expansion);
      }
      return files;
    }

    static private void InsertFilesFromThisFolder(Dictionary<string, List<string>> files,
                                                  IEnumerable<FileInfo> filesInDirectory,
                                                  in string expansion) {
      foreach(var file in filesInDirectory) {
        if (expansion == file.Extension) {
          StreamReader text = file.OpenText();
          List<string> textStr = readFile(text);
          files.Add(file.Name, textStr);
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
  }
}
