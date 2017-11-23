//Ввести число от 0 до 10000000. Озвучить его словами.


using System;

namespace Numbers_1_1000000
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите число:");
            int number = Convert.ToInt32(Console.ReadLine());

            int[] array_int = new int[3];
            array_int[0] = (number - (number % 1000000)) / 1000000;
            array_int[1] = ((number % 1000000) - (number % 1000)) / 1000;
            array_int[2] = (number % 1000);

            string[,] array_string = new string[3, 3] { {" миллион", " миллиона", " миллионов"}, {" тысяча", " тысячи", " тысяч"},  {"", "", ""}};
 
            string result = "";

            for (int i = 0; i < 3; i++)
            {
                int num = array_int[i];
                if (num != 0)
                {
                    if (((num - (num % 100)) / 100) != 0)
                        switch (((num - (num % 100)) / 100))
                        {
                            case 1: result += " сто"; break;
                            case 2: result += " двести"; break;
                            case 3: result += " триста"; break;
                            case 4: result += " четыреста"; break;
                            case 5: result += " пятьсот"; break;
                            case 6: result += " шестьсот"; break;
                            case 7: result += " семьсот"; break;
                            case 8: result += " восемьсот"; break;
                            case 9: result += " девятьсот"; break;
                        }
                    if (((num) - ((num % 100) % 10)) / 10 != 1)
                    {
                        switch (((num % 100) - ((num % 100) % 10)) / 10)
                        {
                            case 2: result += " двадцать"; break;
                            case 3: result += " тридцать"; break;
                            case 4: result += " сорок"; break;
                            case 5: result += " пятьдесят"; break;
                            case 6: result += " шестьдесят"; break;
                            case 7: result += " семьдесят"; break;
                            case 8: result += " восемьдесят"; break;
                            case 9: result += " девяносто"; break;
                        }
                    }
                    switch (num % 10)
                    {
                        case 1: if (i == 1) result += " одна"; else result += " один"; break;
                        case 2: if (i == 1) result += " две"; else result += " два"; break;
                        case 3: result += " три"; break;
                        case 4: result += " четыре"; break;
                        case 5: result += " пять"; break;
                        case 6: result += " шесть"; break;
                        case 7: result += " семь"; break;
                        case 8: result += " восемь"; break;
                        case 9: result += " девять"; break;
                    }
                }
                else
                    switch (num % 100)
                    {
                        case 10: result += " десять"; break;
                        case 11: result += " одиннадцать"; break;
                        case 12: result += " двенадцать"; break;
                        case 13: result += " тринадцать"; break;
                        case 14: result += " четырнадцать"; break;
                        case 15: result += " пятнадцать"; break;
                        case 16: result += " шестнадцать"; break;
                        case 17: result += " семнадцать"; break;
                        case 18: result += " восемннадцать"; break;
                        case 19: result += " девятнадцать"; break;
                    }
                if (num % 100 >= 10 && num % 100 <= 19)
                    result += " " + array_string[i, 2] + " ";
                else
                    switch (num % 10)
                    {
                        case 1: result += " " + array_string[i, 0] + " "; break;
                        case 2:
                        case 3:
                        case 4: result += " " + array_string[i, 1] + " "; break;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9: result += " " + array_string[i, 2] + " "; break;
                    }
            }
            Console.WriteLine(result);


        }
    }
}
