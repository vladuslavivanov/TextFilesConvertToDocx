using System.Reflection.Metadata;
using System.Security;
using System.Xml.Linq;
using CopyCodeFromTheDirectory.Exceptions;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace CopyCodeFromTheDirectory
{
    internal class SaveFile {
    static public void SaveToWord(Dictionary<string, List<String>> files) {
      string path;
      do {
        path = GetPath();
      } while (!CheckPath(path));
      DocX document = DocX.Create(path);
      
      foreach (var file in files) {
        Paragraph nameFile = document.InsertParagraph();
        nameFile.IndentationHanging = 28.5F + 28.5F / 4;
        nameFile.InsertText("\n");
        nameFile.FontSize(14).Font("Times New Roman").InsertText("Код с файла «" + file.Key + "»:");
        Paragraph code = document.InsertParagraph();
        foreach (var line in file.Value) {
          code.FontSize(10).Font("Courier New").InsertText(line+"\n");
        }
      }
      document.Save();
    }

    static private string GetPath() {
      Console.WriteLine("Введите путь к файлу (.docx), куда нужно сохранить данные:");
      string path = Console.ReadLine()!;
      return path;
    }

    static private bool CheckPath(in string path) {
      try {
        if (!path.EndsWith(".docx"))
          throw new ExtensionException("Введите файл с расширением \".docx\"!");
        DocX document = DocX.Load(path + ".docx");
      }
      catch(FileNotFoundException) {
        DocX document = DocX.Create(path);
        document.Save();
        return true;
      }
      catch (ExtensionException e) {
        Console.WriteLine(e.Message);
        return false;
      }
      catch (DirectoryNotFoundException) {
        Console.WriteLine("Данной директории не существует!");
        return false;
      }
      catch (IOException) {
        Console.WriteLine("Другой процесс пользуется вашим файлом!\n");
        return false;
      }
      catch (UnauthorizedAccessException) {
        Console.WriteLine("Вы ввели путь к папке!");
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
      return true;
    }
  }
}
