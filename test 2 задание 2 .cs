using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Имя файла с текстом и имя файла с результатом можно задать через аргументы командной строки
        // или же задать их жестко в коде.
        string inputFilename = args.Length > 0 ? args[0] : "war_and_peace.txt";
        string outputFilename = args.Length > 1 ? args[1] : "word_counts.txt";

        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        // Предварительная обработка текста: считываем файл, удаляем знаки препинания, приводим к нижнему регистру
        // и разбиваем текст на слова.
        string text = File.ReadAllText(inputFilename);
        text = Regex.Replace(text, @"[^\w\s]", "");
        string[] words = text.ToLower().Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // Считаем количество употреблений каждого слова.
        foreach (string word in words)
        {
            if (wordCounts.ContainsKey(word))
                wordCounts[word]++;
            else
                wordCounts.Add(word, 1);
        }

        // Сортируем слова по убыванию количества употреблений и пишем результат в файл.
        var sortedWords = wordCounts.OrderByDescending(pair => pair.Value);
        using (StreamWriter writer = new StreamWriter(outputFilename))
        {
            foreach (var pair in sortedWords)
            {
                writer.WriteLine("{0} {1}", pair.Key, pair.Value);
            }
        }
    }
}