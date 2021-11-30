using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace SF.ITOG_13_6.TASK2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Читаем весь файл с рабочего стола
            string text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Text1.txt");
            
            //Создаём словарь 
            var dictWords = new Dictionary<string, int>();

            //Убираем из текста знаки препинания
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // Сохраняем символы-разделители в массив
            char[] delimiters1 = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters1, StringSplitOptions.RemoveEmptyEntries);
            
            //Проходим по массиву слов
            foreach (var item in words)
            {
                if (dictWords.ContainsKey(item))
                {
                    //Увеличиваем количество найденных в словаре слов
                    dictWords[item]++; 
                }
                else
                {
                    //Добавляем новое слово в словарь
                    dictWords.Add(item, 1);
                }
            }
            //Сортировка словаря по значению в порядке убывания
            var sortedDict = from entry in dictWords orderby entry.Value descending select entry;

            Console.WriteLine("10 слов, которые чаще всего встречаются в тексте:");
            foreach (var wd in sortedDict.Take(10))
            {
                Console.WriteLine("'{0}' - {1} шт.", wd.Key, wd.Value);
            }
            Console.ReadKey();
        }
    }
}
