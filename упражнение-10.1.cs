using System;

interface ICipher
{
    string encode(string text);
    string decode(string text);
}

class ACipher : ICipher
{
    private string upper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    private string lower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

    public string encode(string text)
    {
        return Shift(text, 1);
    }

    public string decode(string text)
    {
        return Shift(text, -1);
    }

    private string Shift(string text, int step)
    {
        string result = "";

        foreach (char symbol in text)
        {
            int position = upper.IndexOf(symbol);
            string alphabet = upper;

            if (position == -1)
            {
                position = lower.IndexOf(symbol);
                alphabet = lower;
            }

            if (position == -1)
            {
                result = result + symbol;
            }
            else
            {
                int next = position + step;

                if (next == alphabet.Length)
                {
                    next = 0;
                }
                else if (next < 0)
                {
                    next = alphabet.Length - 1;
                }

                result = result + alphabet[next];
            }
        }

        return result;
    }
}

class BCipher : ICipher
{
    private string upper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    private string lower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

    public string encode(string text)
    {
        string result = "";

        foreach (char symbol in text)
        {
            int position = upper.IndexOf(symbol);
            string alphabet = upper;

            if (position == -1)
            {
                position = lower.IndexOf(symbol);
                alphabet = lower;
            }

            if (position == -1)
            {
                result = result + symbol;
            }
            else
            {
                int mirror = alphabet.Length - 1 - position;
                result = result + alphabet[mirror];
            }
        }

        return result;
    }

    public string decode(string text)
    {
        return encode(text);
    }
}

class Program
{
    static void ShowCipher(string name, ICipher cipher, string text)
    {
        string encoded = cipher.encode(text);

        Console.WriteLine($"{name}: {encoded}");
        Console.WriteLine($"Расшифровка: {cipher.decode(encoded)}");
    }

    static void Main()
    {
        Console.WriteLine("Упражнение 10.1. Шифрование строк.");
        Console.WriteLine("Текст задан в коде. Ввод не требуется.");

        string text = "АВЯ, абя! Ёё.";
        Console.WriteLine($"Исходный текст: {text}");

        ShowCipher("ACipher", new ACipher(), text);
        ShowCipher("BCipher", new BCipher(), text);
    }
}