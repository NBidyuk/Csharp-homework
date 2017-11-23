using System;
using System.Text.RegularExpressions;

namespace String
{
    public class Program
    {
        static void Main(string[] args)

        {
            string inputString = checkInput();
            PalindromeChecker.PalindromeCheck(inputString);
            Console.WriteLine();

            inputString = checkInput();
            AnalizeString.Analize(inputString);
            Console.WriteLine();

            inputString = checkInput();
            string inputString2 = checkInput();
            AnagrammaChecker.AnagrammaCheck(inputString, inputString2);
            Console.WriteLine();

            inputString = checkInput();
            inputString = isOneWord(inputString);
            char[] charArray = inputString.ToCharArray();
            Permuter.Permute(charArray, 0, inputString.Length - 1);

        }
        static string checkInput()
        {

            Console.Write("Введите строку: ");
            string inputString = Console.ReadLine();
            while (string.IsNullOrEmpty(inputString))
            {

                Console.WriteLine("ОШИБКА! Вы не ввели строку!");
                Console.Write("Введите строку: ");
                inputString = Console.ReadLine();
            }
            return inputString;
        }

        static string isOneWord(string inputString)
        {
            Regex word = new Regex("[a-zA-ZА-Яа-яёЁ]+");
            MatchCollection Words = word.Matches(inputString);
            while (Words.Count != 1)
            {
                inputString=checkInput();
                Console.WriteLine("ОШИБКА! Введите 1 слово!");
            }

             return inputString;
        }
    }
    //1. Дана строка символов. Необходимо проверить, является ли эта строка палиндромом.
    public class PalindromeChecker
    {
        public static bool PalindromeCheck(string InputLine)
        {
            string String = DeleteSymbols(InputLine);
            int i = 0;
            int j = String.Length - 1;

            while (i <= j)
            {
                if (String[i++] != String[j--])
                {
                    Console.WriteLine("It is NOT a Palindrome");
                    return false;
                }

            }
            Console.WriteLine("It is a Palindrome");
            return true;
        }


        private static string DeleteSymbols(string InputLine)
        {
            string newString = InputLine.ToLower();

            string newText = Regex.Replace(newString, "[-.?!)(,:\\s]", "");
            //Console.WriteLine(newText);
            return newText;
        }
    }



    //////////////////////////////////////////////////////////////////////////////////////

    //2. Написать программу, подсчитывающую количество слов, гласных и согласных букв в строке, введёной пользователем.
    //Дополнительно выводить количество знаков пунктуации, цифр и др. символов.

    public class AnalizeString
    {
        public static void Analize(string InputLine)

        {
            string text = InputLine;


            // Создаем объект регулярного выражения
            Regex number = new Regex("(?:\\d*\\.)?\\d+");
            Regex word = new Regex("[a-zA-ZА-Яа-яёЁ]+");
            Regex punc = new Regex("[-.?!,:]");
            Regex con = new Regex("[б-джзк-нп-тф-щБ-ДЖЗК-НП-ТФ-ЩB-DF-HJ-NP-TV-XZb-df-hj-np-tv-xzЙй]");
            Regex vow = new Regex("[aeoiyuаюяеоуиыэёAEUIYOETУЕІАОЄЯИЮЕЁЫ]");

            // Получаем коллекцию совпадений
            MatchCollection Words = word.Matches(text);
            MatchCollection Vowels = vow.Matches(text);
            MatchCollection Consonants = con.Matches(text);
            MatchCollection Punctuation = punc.Matches(text);
            MatchCollection Numbers = number.Matches(text);

            // Формируем сообщение о найденных совпадениях
            Console.WriteLine("Всего символов: {0}", text.Length);
            Console.WriteLine("Из них: ");
            Console.WriteLine("Слов - {0}", Words.Count);
            Console.WriteLine("Чисел - {0}", Numbers.Count);
            Console.WriteLine("Согласных букв: {0}", Consonants.Count);
            Console.WriteLine("Гласных букв: {0}", Vowels.Count);
            Console.WriteLine("Знаков пунктуации: {0}", Punctuation.Count);
            Console.WriteLine("Остальных символов: {0}", text.Length - (Numbers.Count + Consonants.Count + Vowels.Count + Punctuation.Count));
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////

    //3. Написать программу, проверяющую, является ли одна строка анаграммой для другой строки 
    //(строка может состоять из нескольких слов и символов пунктуации). Пробелы и пунктуация, разница в больших и маленьких буквах должны игнорироваться.
    //Обе строки вводятся с клавиатуры.

    public class AnagrammaChecker
    {
        public static bool AnagrammaCheck(string InputLine1, string InputLine2)
        {
            string String1 = DeleteSymbols(InputLine1);
            string String2 = DeleteSymbols(InputLine2);

            if (String1.Length != String2.Length)
                return false;

            else
            {
                char[] Array1 = String1.ToCharArray();
                Array.Sort(Array1);
                Console.WriteLine(Array1);
                char[] Array2 = String2.ToCharArray();
                Array.Sort(Array2);
                Console.WriteLine(Array2);

                // String1 = Array1.ToString();
                // String2 = Array2.ToString();

                int i = 0;

                while (i <= String1.Length - 1)
                {
                    if (!(Array1[i++].Equals(Array2[i++])))
                    {
                        Console.WriteLine("It is NOT an anagramma");
                        return false;
                    }
                }
                Console.WriteLine("It is an anagramma");
                return true;
            }
        }

        private static string DeleteSymbols(string InputLine)
        {
            string newString = InputLine.ToLower();

            string newText = Regex.Replace(newString, "[-.?!)(,:\\s]", "");
            //Console.WriteLine(newText);
            return newText;
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////

    //4. Напишите программу, которая выведет на экран все перестановки символов в исходной строке.
    //Избежать повторений при перестановках. Примерами перестановки строки "AAB" могут быть "AAB", "ABA" и "BAA".c

    public class Permuter
    {
        public static void Permute(char[] array, int i, int n)
        {
            int j;
            if (i == n)
                Console.WriteLine(array);
            else
            {
                for (j = i; j <= n; j++)
                {
                    Swap(ref array[i], ref array[j]);
                    Permute(array, i + 1, n);
                    Swap(ref array[i], ref array[j]); //backtrack
                }
            }
        }

        static void Swap(ref char a, ref char b)
        {
            char tmp;
            tmp = a;
            a = b;
            b = tmp;
        }

      }

       
}




