using System.Security;

namespace CopyCodeFromTheDirectory {
  internal class SaveFile {
    static public void SaveData(Dictionary<string, List<String>> files) {
      string path;
      do {
        path = GetPath();
      } while (!CheckPath(path));
      StreamWriter fileWrite = new StreamWriter(path);
      foreach (var file in files) {
        fileWrite.WriteLine("");
        fileWrite.WriteLine("Название файла \"" + file.Key + "\"");
        foreach(var line in file.Value) {
          fileWrite.WriteLine(line);
        }
        fileWrite.WriteLine("");
      }
      fileWrite.Close();
    }

    static private string GetPath() {
      Console.WriteLine("Введите путь к файлу, куда нужно сохранить данные:");
      string path = Console.ReadLine()!;
      return path;
    }

    static private bool CheckPath(in string path) {
      FileStream file = null;
      try {
        file = new FileStream(path, FileMode.Append);
        if (file.Length != 0)
          throw new NotAnEmptyFileException("В файле есть данные!\n Введите другой файл,\n либо удалите данные из этого файла!");
      }
      catch (NotAnEmptyFileException e) {
        Console.WriteLine(e.Message);
        return false;
      }
      catch (ArgumentException) {
        Console.WriteLine("Файл введен некорректно!");
        return false;
      }
      catch (SecurityException) {
        Console.WriteLine("Файл доступен только для чтения!");
        return false;
      }
      catch (DirectoryNotFoundException) {
        Console.WriteLine("Данной директории не существует!");
        return false;
      }
      catch (IOException) {
        Console.WriteLine("Файл недоступен!");
        return false;
      }
      finally {
        if(file != null)
          file.Close();
      }
      return true;
    }
  }
}
