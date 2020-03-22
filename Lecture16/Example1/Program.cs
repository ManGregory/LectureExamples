using System;
using System.IO;

namespace Example1
{
    /*
     Основные операции с папками:
        Проверить существование папки D:\test\ (или на другом диске)
        Если нет, то создать папку test на диске D:\ (если нет, то на любом другом)
        Создать папки D:\test\subdir1\, D:\test\subdir2\
        Вывести все папки в папке D:\test\ через запятую
        Создать в папке D:\test\ файл file0.txt, в папке D:\test\subdir1\ файл file1.txt и в папке D:\test\subdir2 файл file2.txt
        Вывести все файлы в папке D:\test\ через запятую. Также вывести все файлы в папке D:\test\ и в подпапках
        Удалить папку D:\test\
     */
    class Program
    {
        static void Main(string[] args)
        {
            // путь к папке
            const string DirPath = @"D:\test\";
            // проверка на существование папки
            if (!Directory.Exists(DirPath))
            {
                // создание папки
                Directory.CreateDirectory(DirPath);
                Directory.CreateDirectory(DirPath + @"subdir1\");
                Directory.CreateDirectory(DirPath + @"subdir2\");
            }
            // список всех папок
            // * - любое кол-во символов
            // ? - любой один символ
            // *subdir* - asdfasdfsubdirasdfasdf
            // subdir? - subdir1, subdir2, subdir3
            var subDirs = Directory.GetDirectories(DirPath, "subdir?", SearchOption.AllDirectories);
            // вывели список папок через запятую
            Console.WriteLine(string.Join(", ", subDirs));

            // Создать в папке D:\test\ файл file0.txt, в папке D:\test\subdir1\ файл file1.txt и в папке D:\test\subdir2 файл file2.txt
            File.WriteAllText(DirPath + "file0.txt", "");
            File.WriteAllText(DirPath + @"subdir1\file1.txt", "");
            File.WriteAllText(DirPath + @"subdir2\file2.txt", "");

            // Вывести все файлы в папке D:\test\ через запятую. Также вывести все файлы в папке D:\test\ и в подпапках
            // SearchOption.TopDirectory - вернет все файлы только в указанной папке (без подпапок)
            // SearchOption.AllDirectories - вернет все файлы во всех папках (в том числе вложенных)
            string[] files = Directory.GetFiles(DirPath, "", SearchOption.AllDirectories);

            // GetFiles возвращает полный путь к файлу
            // в этом цикле мы выделим только имя файла и запишем в массив files
            for (int index = 0; index < files.Length; index++)
            {
                // полный путь
                string fullPath = files[index];
                // индекс последнего слеша
                int lastIndexOfSlash = fullPath.LastIndexOf('\\');
                // выделяем имя файла
                string fileName = fullPath.Substring(lastIndexOfSlash + 1, fullPath.Length - lastIndexOfSlash - 1);
                // записываем в массив
                files[index] = fileName;
            }

            // выводим на консоль через запятую
            Console.WriteLine(string.Join(", ", files));

            // Удалить папку D:\test\
            // если второй параметр true, то удаляются все папки и подпапки
            Directory.Delete(DirPath, true);
        }
    }
}
