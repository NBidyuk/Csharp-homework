//игра пятнашки
/*#include <iostream> 
#include <conio.h>  
#include <windows.h> 
#include <time.h> 
#include <iomanip>  

using namespace std;

HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);

enum ConsoleColor
{
	Black = 0,
	Blue = 1,
	Green = 2,
	Cyan = 3,
	Red = 4,
	Magenta = 5,
	Brown = 6,
	LightGray = 7,
	DarkGray = 8,
	LightBlue = 9,
	LightGreen = 10,
	LightCyan = 11,
	LightRed = 12,
	LightMagenta = 13,
	Yellow = 14,
	White = 15
};

enum { UP = 72, DOWN = 80, LEFT = 75, RIGHT = 77, ENTER = 13, ESC = 27, CODE = 224 };

void Shuffle(int a[4][4]);
void Draw_line(int);
void Table();

bool Full(int a[4][4]);
void Move(int a[4][4], int x, int y, int wi, int wj);
void Fill_table(int a[4][4]);

void SetColor(ConsoleColor text, ConsoleColor background)
{
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}
void GotoXY(int X, int Y)
{
	COORD coord = { X, Y };
	SetConsoleCursorPosition(hStdOut, coord);
}

void WriteDig(int X, int Y, int a)
{
	GotoXY(X, Y);
	cout << "  " << flush;
	GotoXY(X, Y);
	if (a)
		cout << a << flush;
}



void main()

{
	setlocale(LC_ALL, "Russian");
	SetColor(LightGreen, Black);
	cout << endl << endl;
	cout << "\t\t\t\tИГРА ПЯТНАШКИ" << endl << endl;

	SetColor(LightRed, Black);
	cout << "ПРАВИЛА ИГРЫ:" << endl;
	cout << "Популярная головоломка ПЯТНАШКИ была придумана еще в конце 19 века.";
	cout << "Классическое игровое поле представляет собой матрицу 4х4 клеток, на котором по порядку(слева - направо и сверху - вниз) располагаются цифры от 1 до 15. ";
	cout << "Последняя клетка – пустая.Клетки перемешиваются определенным образом, и задача игрока состоит в том, чтобы восстановить их первоначальное правильное расположение.";
	cout << "Делать это можно лишь путем перемещения на пустую клетку другой, соседней с ней клетки(расположенной слева, справа, сверху или снизу от пустой)." << endl << endl;
	SetColor(LightGreen, Black);
	cout << "\t\t\ Нажмите ENTER, чтобы начать игру!" << endl;

	int key = 0;

	key = _getch();

	if (key == CODE)

	{
		key = _getch();
	}
	if (key == ENTER)
	{
		system("cls");
	}


	int array[4][4] = { { 1,2,3,4 },{ 5,6,7,8 },{ 9,10,11,12 },{ 13,14,15,0 } };
	srand((unsigned)time(NULL));
	Shuffle(array);
	int wi, wj;
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			if (array[i][j] == 0)
			{
				wi = i;
				wj = j;
				break;
			}
		}
	}
	int x = wi * 8 + 4, y = wj * 5 + 2;
	Table();
	SetColor(LightRed, Black);

	Move(array, x, y, wi, wj);

	_getch();
}




void Shuffle(int a[4][4])
{


	int X, Y;

	for (unsigned int i = 0; i < 4; i++)
	{
		for (unsigned int j = 0; j < 4; j++)
		{
			if (a[i][j] == 0)
			{
				X = i;
				Y = j;
				break;
			}
		}
	}


	int count = 0;
	int code = 0;
	const int up = 1;
	const int down = 2;
	const int right = 3;
	const int left = 4;

	do
	{

		code = rand() % 4 + 1;

		switch (code)
		{
		case up:
			if (X != 0)
			{
				a[X][Y] = a[X - 1][Y];
				a[X - 1][Y] = 0;
				X--;
				count++;
			}
			break;

		case down:
			if (X < 3)
			{
				a[X][Y] = a[X + 1][Y];
				a[X + 1][Y] = 0;
				X++;
				count++;
			}
			break;

		case left:
			if (Y != 0)
			{
				a[X][Y] = a[X][Y - 1];
				a[X][Y - 1] = 0;
				Y--;
				count++;
			}
			break;

		case right:
			if (Y < 3)
			{
				a[X][Y] = a[X][Y + 1];
				a[X][Y + 1] = 0;
				Y++;
				count++;
			}
			break;
			system("cls");

		}
	} while (count < 300);
}

enum Symbol { Single_Vert = 166, Single_Horz = 151 };

void Draw_line(int w)
{
	int i, j, k;
	for (i = 1; i <= w + 5; i++) {


		cout << (char)Single_Horz;
	}

	for (k = 1; k <= 4; k++)
	{
		cout << endl;
		for (i = 1; i <= 5; i++)
		{
			cout << (char)Single_Vert;
			for (j = 1; j <= w / 4; j++)
			{
				cout << " ";
			}
		}
	}
	cout << endl;

}

void Table()
{
	Draw_line(28);
	Draw_line(28);
	Draw_line(28);
	Draw_line(28);
	for (int i = 1; i <= 28 + 5; i++)
	{
		cout << (char)Single_Horz;
	}
}


void Fill_table(int a[4][4])
{
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			WriteDig(j * 8 + 4, i * 5 + 2, a[i][j]);
		
				
		}
		
	}
}

bool Full(int a[4][4])
{
	bool flag = false;
	int count = 1;
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			if (count == 16)
				break;

			if (a[i][j] != count)
				flag = true;
			count++;
		}
	}
	return flag;
}


void Move(int a[4][4], int x, int y, int wi, int wj)
{


	int count = 0;
	int key;
	do
	{
		Fill_table(a);
		WriteDig(x, y, 0);
		key = _getch();

		if (key == CODE)
		{
			key = _getch();
		}
		switch (key)
		{
		case DOWN:
			if (wi != 0)
			{
				a[wi][wj] = a[wi - 1][wj];
				a[wi - 1][wj] = 0;
				wi--;
				count++;
				WriteDig(x, y -= 5, 0);
			}
			break;

		case UP:
			if (wi < 3)
			{
				a[wi][wj] = a[wi + 1][wj];
				a[wi + 1][wj] = 0;
				wi++;
				count++;
				WriteDig(x, y+=5, 0);
			}
			break;

		case RIGHT:
			if (wj != 0)
			{
				a[wi][wj] = a[wi][wj - 1];
				a[wi][wj - 1] = 0;
				wj--;
				count++;
				WriteDig(x -= 8, y, 0);
			}
			break;

		case LEFT:
			if (wj < 3)
			{
				a[wi][wj] = a[wi][wj + 1];
				a[wi][wj + 1] = 0;
				wj++;
				count++;
				WriteDig(x += 8, y, 0);
			}
			break;
			

		}
		if (!Full(a))
		{
			system("cls");

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					a[i][j] = 0;
				}
			}

			SetColor(Yellow, Black);


			cout << "\n\n\t\t\t ПОЗДРАВЛЯЕМ! ВЫ ВЫИГРАЛИ!\n\n" << endl << endl;

			cout << "\t\t\t ВЫ СДЕЛАЛИ: " << count << " ХОДОВ";
			cout << endl << endl;

			SetColor(LightGreen, Black);
		}

	} while (key != 27);

	if (key == 27)
		return;

	_getch();
}*/