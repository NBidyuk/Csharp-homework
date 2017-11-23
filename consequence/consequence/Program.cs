// Дана последовательность 1,11,21,1211 ... Ввести число N, показать Nй элемент последовательности
using System; 
using System.Text; 


class Program
{
    static string Consequence (string n)
    {
        StringBuilder result = new StringBuilder();

        string number = "1";

        char repeat = number[0];
        int i = 0;
        int j = 0;
        int.TryParse(n, out j);
        int val = 1;

        if (j == 1)
            return j.ToString();
        else
        {
            while (i < j) 
            {
                number = number.Substring(1, number.Length - 1) + " ";
                foreach (char actual in number)


                {
                    if (actual != repeat)
                    {
                        result.Append(Convert.ToString(val) + repeat);
                        val = 1;
                        repeat = actual;
                    }
                    else
                    {
                        val += 1;
                    }
                }

                i++;
                number = result.ToString();
                val = 1;
                result.Clear();

            } 
        }
        return number.ToString();
        
    }

    static void Main(string[] args)
    {
        Console.Write("Введите число в для преобразования = ");
       string n = Console.ReadLine();
        Console.WriteLine(Consequence(n));
    }
}