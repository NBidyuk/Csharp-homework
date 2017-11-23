using System;

namespace Arrays
{

    struct pos_p
    {
        public int r;
        public int c;
    };

    class Program
    {
        static char wrag_ = Convert.ToChar(0x41E);
        static char gold_ = Convert.ToChar(0x160);
        static char ramka_ = Convert.ToChar(0x2593);
        static char stenka_ = Convert.ToChar(0x2592);
        static char player_ = Convert.ToChar(0xA4);
        static char nul = Convert.ToChar(0xA0);



        public static void spiral(char[,] arr, int row, int col)
        {

            Random rand = new Random();
            Random rand_gold = new Random();
            Random rand_wrag = new Random();

            int wall;
            int gold;
            int wrag;

            for (int i = 0; i < row - 1; i++)
            {

                for (int y = 0; y < col; y++)
                {
                    if (y == 0 || y == col - 1 || i == 0 || i == row - 2)
                    {
                        arr[i, y] = ramka_; // рамка
                    }
                    else
                    {
                        arr[i, y] = nul;
                        if (i == 1 && y == 1)
                            arr[i, y] = player_; // игрок
                        else
                        {
                            wall = rand.Next(10);
                            if (wall > 7)
                            {
                                if (i != 1 || y != 1)
                                    arr[i, y] = stenka_;      // стенки                                                                                 
                            }
                            else
                            {
                                gold = rand_gold.Next(10);
                                if (gold > 8)
                                    arr[i, y] = gold_;      // золото   
                                else if (gold <= 8)
                                {
                                    wrag = rand_wrag.Next(100);
                                    if (wrag == 1)
                                        arr[i, y] = wrag_;      // враги   
                                }

                            }
                        }

                    }

                }

            }
        }



        static void Main(string[] args)
        {
            int row = 30;
            int col = 70;
            char[,] intArray1 = new char[row, col];
            spiral(intArray1, row, col);

            pos_p pos_player;
            pos_player.c = 1;
            pos_player.r = 1;

            Random rand_move = new Random();
            int move;


            int game = 1;
            while (game == 1)
            {

                for (int i = 0; i < row; i++)
                {
                    for (int y = 0; y < col; y++)
                    {
                        if (intArray1[i, y] != (0x2593))
                        {
                            if (intArray1[i, y] == player_)
                                Console.ForegroundColor = ConsoleColor.Blue; // ирок
                            else if (intArray1[i, y] == gold_)
                                Console.ForegroundColor = ConsoleColor.Yellow;  // голд
                            else if (intArray1[i, y] == stenka_)
                                Console.ForegroundColor = ConsoleColor.Green; // стенка
                            else
                                Console.ForegroundColor = ConsoleColor.Red; // враг 
                            Console.Write("{0}", intArray1[i, y]);
                            Console.ResetColor();
                        }
                        else
                            Console.Write("{0}", intArray1[i, y]);     // стенка
                    }

                    Console.WriteLine();
                }

                move = rand_move.Next(3);

                if (intArray1[pos_player.r, pos_player.c + 1] == nul || intArray1[pos_player.r, pos_player.c + 1] == gold_)
                {
                    if (intArray1[pos_player.r, pos_player.c + 1] == wrag_)
                    {
                        game = 0;
                        break;
                    }
                    intArray1[pos_player.r, pos_player.c + 1] = player_;
                    intArray1[pos_player.r, pos_player.c] = ' ';
                    pos_player.c++;
                }
                else if (intArray1[pos_player.r + 1, pos_player.c] == nul || intArray1[pos_player.r + 1, pos_player.c] == gold_)
                {
                    if (intArray1[pos_player.r + 1, pos_player.c] == wrag_)
                    {
                        game = 0;
                        break;
                    }
                    intArray1[pos_player.r + 1, pos_player.c] = player_;
                    intArray1[pos_player.r, pos_player.c] = ' ';
                    pos_player.r++;
                }
                else if (intArray1[pos_player.r, pos_player.c - 1] == nul || intArray1[pos_player.r, pos_player.c - 1] == gold_)
                {
                    if (intArray1[pos_player.r, pos_player.c - 1] == wrag_)
                    {
                        game = 0;
                        break;
                    }
                    intArray1[pos_player.r, pos_player.c - 1] = player_;
                    intArray1[pos_player.r, pos_player.c] = ' ';
                    pos_player.c--;
                }
                else if (intArray1[pos_player.r - 1, pos_player.c] == nul || intArray1[pos_player.r - 1, pos_player.c] == gold_)
                {
                    if (intArray1[pos_player.r - 1, pos_player.c] == wrag_)
                    {
                        game = 0;
                        break;
                    }
                    intArray1[pos_player.r - 1, pos_player.c] = player_;
                    intArray1[pos_player.r, pos_player.c] = ' ';
                    pos_player.r--;
                }

                System.Threading.Thread.Sleep(500);
                Console.Clear();

            }
        }
    }

}
