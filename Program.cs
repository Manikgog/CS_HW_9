using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_9
{
    
    internal class Program
    {
        /*
         Программа «Анализатор кода»
        Прочитать текстC#-программы(выбрать самостоятельно)
        и все слова public в объявлении полей классов заменить
        на слово private. В исходном коде в каждом слове длиннее
        двух символов все строчные символы заменить прописными. 
        Также в коде программы удалить все «лишние»
        пробелы и табуляции, оставив только необходимые для
        разделения операторов. Записать символы каждой строки
        программы в другой файл в обратном порядке. 
         */
        static string path = "C:\\Users\\Maksim\\source\\repos\\CS_HW_9\\prog.txt";
        static string new_path = "C:\\Users\\Maksim\\source\\repos\\CS_HW_9\\new_prog.txt";
        static async Task Main(string[] args)
        {
            List<string[]> listOfListsOfWords = new List<string[]>();           // буфер для дальнейшего хранения и обработки текста. Динамический массив массивов слов
            UnicodeEncoding unicode = new UnicodeEncoding();                    // объект для задания кодировки для считывания и записи
            using (StreamReader reader = new StreamReader(path, unicode))
            {
                
                string line;
                int counterOflines = 0;
                while ((line = await reader.ReadLineAsync()) != null)           // считываем построчно до конца файла
                {
                    string[] strArr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);        // делим строку на слова 
                    if (strArr != null && strArr.Length > 0)            // не записываем пустые строки
                    {
                        listOfListsOfWords.Add(strArr);
                        counterOflines++;
                    }
                    
                }
            }
           
            for(int i = 0; i < listOfListsOfWords.Count; i++)                   // цикл для преобразования содержания буфера
            {
                for(int j = 0; j < listOfListsOfWords[i].Length; j++)
                {
                    if (listOfListsOfWords[i][j].Equals("public"))              // меняем слово public на слово private
                    {
                        listOfListsOfWords[i][j] = "private";
                    }
                    if (listOfListsOfWords[i][j].Length > 2)                    // преобразовываем слова длиннее 2 букв в верхний регистр
                    {
                        listOfListsOfWords[i][j] = listOfListsOfWords[i][j].ToUpper();
                    }
                    StringBuilder word = new StringBuilder();
                    for(int k = listOfListsOfWords[i][j].Length - 1; k >= 0; k--)   // переворачиваем каждое слово
                    {
                        word.Append(listOfListsOfWords[i][j][k]);
                    }
                    listOfListsOfWords[i][j] = word.ToString();                   // перезаписываем элемент массива слов перевёрнутым словом
                    Console.Write(listOfListsOfWords[i][j] + " ");
                }
                Console.WriteLine();
            }
            
            using (StreamWriter writer = new StreamWriter(new_path, false, unicode))    // запись буфера в файл
            {
                for (int i = 0; i < listOfListsOfWords.Count; i++)                      // цикл для построчной записи
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int j = 0; j < listOfListsOfWords[i].Length; j++)              // цикл для формирования строки для записи
                    {
                        stringBuilder.Append(listOfListsOfWords[i][j] + " ");
                    }
                    writer.WriteLine(stringBuilder.ToString());                         // запись строки в файл
                }
            }

        }
    }
}
