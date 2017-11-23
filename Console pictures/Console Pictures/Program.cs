using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Steps
/*namespace Console_Pictures
{
    class Program
    {
        
        static void Steps(int number)
        {
            int n = 0;
            for (int k = 0; k < number ; k++)
            {
               
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" ");

                }
                Console.WriteLine("***");
               
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" ");

                }
                Console.WriteLine("  *");
                n += 2;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");

            }
            Console.WriteLine("***");

        }



        static void Main(string[] args)
        {

            Console.WriteLine("Введите число ступенек:");

            string Text = Console.ReadLine();

            bool Digits = true;

            foreach (var item in Text)
            {
                if (!Char.IsDigit(item))
                {
                    Digits = false;
                    Console.WriteLine("\nThe symbol  " + item + " is wrong. Only digits are allowed.\n");
                    break;
                }
            }


            if (Digits == true)
            {
                int number = Convert.ToInt32(Text);
                Steps(number);
            }


        }

    }
}
*/


    // Christmas Tree
namespace Console_Pictures
{
    class Program
    {
         static void ChristmasTree(int layer, int height)
        {
            int Width = (height * 2 - 1) + 2 * layer;
            int Count = 0;
            int n = 1;
            int X = 0;
            int Y = 5;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n");

            for (int k = 0; k < layer; k++)

            {
                Count = n;
                for (int i = 0; i < height; i++)
                {
                    int RightSide = (Width + Count) / 2;
                    int LeftSide = RightSide - Count + 1;
                    for (int j = 1; j <= Width; j++)
                    {
                        if (j >= LeftSide && j <= RightSide)
                            Console.Write("@");
                        else
                            Console.Write(" ");
                    }
                    Count += 2;

                    Console.Write("\n");
                    Y++;
                }
                Count = 1;
                n += 2;

            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            X = Width / 2 - 1;
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine("###");
                Y++;
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Введите число ярусов:");
            string Text = Console.ReadLine();

            Console.WriteLine("Введите высоту ярусов:");
            string Text2 = Console.ReadLine();
            
            bool Digits = true;

            foreach (var item in Text)
            {
                if (!Char.IsDigit(item))
                {
                    Digits = false;
                    Console.WriteLine("\nThe symbol  " + item + " is wrong. Only digits are allowed.\n");
                    break;
                }

            }

            foreach (var item in Text2)
            {
                if (!Char.IsDigit(item))
                {
                    Digits = false;
                    Console.WriteLine("\nThe symbol  " + item + " is wrong. Only digits are allowed.\n");
                    break;
                }

            }


            if (Digits == true)
            {
                int layer = Convert.ToInt32(Text);
                int height = Convert.ToInt32(Text2);
                ChristmasTree(layer, height);
            }
        }

    }
}

// Numbers

/*namespace Console_Pictures
{
    class Program
    {
        static int X = 0;
        static int Y = 0;
        
        static void Zero()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("  000  "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" 0   0 ");  Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("0     0"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("0     0"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("0     0"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" 0   0 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("  000  "); X += 8;
        }

        static void One()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("   1   "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("  11   "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" 1 1  "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("   1   "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("   1   "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("   1   "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" 11111 "); X += 8;
        }

           static void Two()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("  2222 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" 2    2"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("     2 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("    2  "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("   2   "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine("  2    "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" 222222"); X += 8;

        }

        static void Three()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.Write("  3333 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 3    3"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("      3"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("     3 "); Y++;
            Console.SetCursorPosition(X, Y);;
            Console.Write("      3"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 3    3"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  3333 "); X += 8;
            
        }

        static void Four()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.Write("     4 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("    44 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("   4 4 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  4  4 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 444444"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("     4 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("     4 "); X += 8;
            
        }

        static void Five()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 555555"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 5     "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 5     "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  5555 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("      5"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 5    5"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  5555 "); X += 8;
            
        }

        static void Six()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.Write("  6666 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 6    6"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 6     "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 66666 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 6    6"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 6    6"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  6666"); X += 8;

        }

        static void Seven()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 777777"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("      7"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("     7 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("    7  "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("   7   "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  7    "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  7    "); X += 8;
        }

        static void Eight()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.Write("  8888 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 8    8"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 8    8"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  8888 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 8    8"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 8    8"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  8888 "); X += 8;

        }

        static void Nine()
        {
            Y = 4;
            Console.SetCursorPosition(X, Y);
            Console.Write("  9999 "); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 9    9"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 9    9"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  99999"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("      9"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write(" 9    9"); Y++;
            Console.SetCursorPosition(X, Y);
            Console.Write("  9999 "); X += 8;
        }
        
        static void DrawNumbers(string Text)
        {
            int number = Convert.ToInt32(Text);
            int X = 0;
            int Y = 2;

            foreach (var item in Text)
            {
                Console.SetCursorPosition(X, Y);
                switch (item)
                {
                    case '0': Zero(); break;
                    case '1': One(); break;
                    case '2': Two(); break;
                    case '3': Three(); break;
                    case '4': Four(); break;
                    case '5': Five(); break;
                    case '6': Six(); break;
                    case '7': Seven(); break;
                    case '8': Eight(); break;
                    case '9': Nine(); break;
                }
                X += 8;
            }
        }
        

            static void Main (string[] args)
        {

            Console.WriteLine("Введите число:");

            string Text = Console.ReadLine();

            bool Digits = true;

            foreach (var item in Text)
            {
                if (!Char.IsDigit(item))
                {
                    Digits = false;
                    Console.WriteLine("\nThe symbol  " + item + " is wrong. Only digits are allowed.\n");
                    break;
                }
            }


            if (Digits == true)
            {
                
                DrawNumbers(Text);
            }


        }
    }
}*/
