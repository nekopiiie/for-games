using System;
using System.Collections.Generic;

public class MorseCodeConverter
{
    private static Dictionary<char, string> _morseCodeDictionary = new Dictionary<char, string>()
    {
        {'а', ".-"}, {'б', "-..."}, {'в', ".--"}, {'г', "--."}, {'д', "-.."},
        {'е', "."}, {'ж', "...-"}, {'з', "--.."}, {'и', ".."}, {'й', ".---"},
        {'к', "-.-"}, {'л', ".-.."}, {'м', "--"}, {'н', "-."}, {'о', "---"},
        {'п', ".--."}, {'р', ".-."}, {'с', "..."}, {'т', "-"}, {'у', "..-"},
        {'ф', "..-."}, {'х', "...."}, {'ц', "-.-."}, {'ч', "---."}, {'ш', "----"},
        {'щ', "--.-"}, {'ъ', ".--.-."}, {'ы', "-.--"}, {'ь', "-..-"}, {'э', "..-.."},
        {'ю', "..--"}, {'я', ".-.-"},
    };
    // метод для шифрования текста в код Морзе
    public static string Encrypt(string text)
    {
        // преобразование текста в нижний регистр
        text = text.ToLower();
        string morseCode = "";
        // итерация по символам текста
        foreach (char letter in text)
        {
            // проверка, есть ли символ в словаре
            if (_morseCodeDictionary.ContainsKey(letter))
            {
                // добавление кода Морзе для символа
                morseCode += _morseCodeDictionary[letter] + " ";
            }
        }
        // возврат зашифрованного текста
        return morseCode.Trim();
    }

    // метод для дешифрования кода Морзе в текст
    public static string Decrypt(string morseCode)
    {
        // разделение кода Морзе на отдельные символы
        string[] morseCodeSymbols = morseCode.Split(' ');
        string plainText = "";
        // итерация по символам кода Морзе
        foreach (string symbol in morseCodeSymbols)
        {
            // проверка, не пустой ли символ
            if (!string.IsNullOrEmpty(symbol))
            {
                // поиск символа в словаре (обратный словарь)
                foreach (var kvp in _morseCodeDictionary)
                {
                    if (kvp.Value == symbol)
                    {
                        // добавление найденного символа в текст
                        plainText += kvp.Key;
                        break;
                    }
                }
            }
        }
        // возврат расшифрованного текста
        return plainText;
    }

    // основная функция для демонстрации работы
    public static void Main(string[] args)
    {
        // пример шифрования
        Console.WriteLine("Введите текст для шифрования:");
        string text = Console.ReadLine();
        string encryptedText = Encrypt(text);
        Console.WriteLine($"Зашифрованный текст: {encryptedText}");

        // пример дешифрования
        Console.WriteLine("Введите код Морзе для дешифрования:");
        string morseCode = Console.ReadLine();
        string decryptedText = Decrypt(morseCode);
        Console.WriteLine($"Расшифрованный текст: {decryptedText}");
    }
}