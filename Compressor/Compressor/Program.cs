using System;

namespace Compressor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text =
                @"рыба плыла рыба плыла а потом сплыла
                вот и сказочке конец вот и сказочке а кто слушал молодец
                акула плыла по морю а потом сплыла";
            string compressedText = text;

            var words = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var dictionary = new string[words.Length];
            foreach (var word in words)
            {
                for (int index = 0; index < dictionary.Length; index++)
                {
                    if (dictionary[index] == word.Trim())
                    {
                        break;
                    }
                    if (string.IsNullOrEmpty(dictionary[index]))
                    {
                        dictionary[index] = word.Trim();
                        break;
                    }
                }
            }

            for (int index = 0; index < dictionary.Length; index++)
            {
                string dictWord = dictionary[index];
                if (string.IsNullOrEmpty(dictWord)) break;

                compressedText = compressedText.Replace(dictWord, index.ToString());
            }

            compressedText += "\r\n" + string.Join(" ", dictionary);
        }
    }
}
