using System;
using System.IO;
using System.Text;

namespace Example5
{
    /*
     Создать массив строк и записать его в файл
     */
    class Program
    {
        static void Main(string[] args)
        {
            // создаем массив строк
            string[] fileLines = new string[]
            {
                "Это строка 1",
                "Это строка 2",
                "Это строка 3"
            };

            // путь к файлу
            // здесь нужно чтобы у вас были права записи в файл
            string filePath = @"D:\2.txt";
            // этот метод создает новый файл или полностью перезаписывает существующий
            // первый аргумент это путь к файлу
            // второй - собственно содержимое которое мы хотим записать
            // третий - кодировка
            File.WriteAllLines(filePath, fileLines, Encoding.UTF8);

            // чтобы добавить в конец файла содержимое можно использовать следующий метод
            // в этот раз файл не будет перезаписан а к нему добавятся новая строка "This append string"
            File.AppendAllLines(filePath, new string[] { "This append string" }, Encoding.UTF8);

            // также можно использовать для записи следующий метод
            // но он записывает целиком строку
            // поэтому если хотите видеть разбиение на строки нужно их разделить символами \r\n
            // или Environment.NewLine
            string fileContent = $"This is first line\r\nThis is second line{Environment.NewLine}This is third line\r\n";
            File.WriteAllText(@"D:\3.txt", fileContent, Encoding.UTF8);

            // также есть метод для добавления только строки по аналогии с File.AppendAllLines
            File.AppendAllText(@"D:\3.txt", "This is another line", Encoding.UTF8);
        }
    }
}
