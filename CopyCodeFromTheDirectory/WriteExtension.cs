namespace CopyCodeFromTheDirectory; 

internal class WriteExtension {
    static public string writeExtension() {
      string value;
      do {
        Console.WriteLine("Введите расширение файла, файлы с которым нужно скопировать. \n Пример: \".txt\":");
        value = Console.ReadLine()!;
      } while (value[0] != '.');
      return value;
    } 
}
