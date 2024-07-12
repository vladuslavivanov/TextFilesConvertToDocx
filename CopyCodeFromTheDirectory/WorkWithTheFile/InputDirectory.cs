namespace CopyCodeFromTheDirectory.WorkWithTheFile;

internal class InputDirectory {
    public static DirectoryInfo EnterDirectory() {
      DirectoryInfo? directory = null;
      do {
        Console.WriteLine("Введите путь к каталогу:");
        string path = Console.ReadLine()!;
        directory = new DirectoryInfo(path);
        if (!directory.Exists) {
          Console.WriteLine("Ошибка в названии пути, повторите попытку!");
          continue;
        }
        Console.WriteLine("Каталог введён!");
        break;
      } while (true);
      return directory;
    } 
}
