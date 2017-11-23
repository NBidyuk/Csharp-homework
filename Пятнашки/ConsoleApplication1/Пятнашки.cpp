//���� ��������

#include <iostream> 
#include <conio.h>  
#include <windows.h> 
#include <time.h> 
#include <iomanip>  

using namespace std;

HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);

enum ConsoleColor
{
	Black = 0, Blue, Green, Cyan, Red , Magenta,Brown ,LightGray,DarkGray,LightBlue,LightGreen,
	LightCyan,LightRed, LightMagenta,Yellow,White 
};

enum { UP = 72, DOWN = 80, LEFT = 75, RIGHT = 77, ENTER = 13, ESC = 27, CODE = 224 };

void Shuffle(int** a, unsigned rows, unsigned cols);

void Table(int);
void Fill_Table(int** array, unsigned rows, unsigned cols);
void Fill(int** array, unsigned rows, unsigned cols);
bool Full(int** array, unsigned rows, unsigned cols);
void Move(int** a, unsigned rows, unsigned cols);
void Del(int** array, unsigned rows);

void SetColor(ConsoleColor text, ConsoleColor background)
{
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}
void GotoXY(int X, int Y)
{
	COORD coord = { X, Y };
	SetConsoleCursorPosition(hStdOut, coord);
}

void WriteDig(int X, int Y, int a) //������� ����� ��� ��������� ���� � ������ ����� �������
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
	cout << "\t\t\t\t���� ��������" << endl << endl;

	SetColor(LightRed, Black);
	cout << "������� ����:" << endl;
	cout << "���������� ����������� �������� ���� ��������� ��� � ����� 19 ����.";
	cout << "������������ ������� ���� ������������ ����� ������� 4�4 ������, �� ������� �� �������(����� - ������� � ������ - ����) ������������� ����� �� 1 �� 15. ";
	cout << "��������� ������ � ������.������ �������������� ������������ �������, � ������ ������ ������� � ���, ����� ������������ �� �������������� ���������� ������������ 1-15.";
	cout << "������ ��� ����� ���� ����� ����������� �� ������ ������ ������, �������� � ��� ������(������������� �����, ������, ������ ��� ����� �� ������)." << endl << endl;
	SetColor(LightGreen, Black);
	cout << "\t\t\ ������� ENTER, ����� ������ ����!" << endl << endl;
	
	cout << "\t\t\ ������� ESC, ����� ����� �� ����!" << endl;
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
	if (key == ESC)
	{
		system("cls");
		return;
	}

	unsigned int rows = 4, cols = 4;
	int** array = new int*[rows];
		for (unsigned int i = 0; i<rows; i++)
	{
		array[i] = new int[cols];
	}

	SetColor(Black, LightGreen);
	Table(28);
	
    Fill(array, rows, cols);
	
	srand((unsigned)time(NULL));
	Shuffle(array, rows, cols);

	
	Move(array, rows, cols);

	Del(array,rows);
	_getch();
}

enum Symbol { Single_Vert = 166, Single_Horz = 151 };

void Table (int w) // ������ �������
{
	int i, j, k, l;
	for (l = 1; l <= 4; l++)
	{
		for (i = 1; i <= w + 5; i++) {


			cout << (char)Single_Horz;
		}

		for (k = 1; k <= 4; k++)
		{
			int count = 0;
			cout << endl;

			for (i = 1; i <= 5; i++)
			{
				if (count < 4)
				{
					cout << (char)Single_Vert;
					for (j = 1; j <= w / 4; j++)
					{
						cout << " ";
					}
					
				}

				else
				{
					cout << (char)Single_Vert;

				}
				count++;
			}
			count = 0;
		}
		cout << endl;
	}
	for (int i = 1; i <= w+5; i++)
	{
		cout << (char)Single_Horz;
	}
}


void Fill(int** array, unsigned rows, unsigned cols) //��������� ������ �� 1 �� 15 � ��������� 0
{
	int num = 1;
	for (unsigned int i = 0; i < rows; i++)
	{
	
		for (unsigned int j = 0; j < cols; j++)
		{
			if (num == 16)
			{
				array[i][j] = 0;
			}
			else {
				array[i][j] = num;
				num++;
			}
		}
		
	}
}

void Shuffle(int** a, unsigned rows, unsigned cols) // ��������� ������ �����
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
			if (X < rows - 1)
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
			if (Y < cols - 1)
			{
				a[X][Y] = a[X][Y + 1];
				a[X][Y + 1] = 0;
				Y++;
				count++;
			}
			break;
		}
	} while (count < 300);
}

void Fill_Table(int** array, unsigned rows, unsigned cols) // ����������� ����� � �������

{
	
	for (unsigned int i = 0; i < rows; i++)
	{

		for (unsigned int j = 0; j < cols; j++)

		{
			WriteDig(j * 8 + 4, i * 5 + 2, array[i][j]);
		}
	}
	cout << endl;
}

bool Full(int** a, unsigned rows, unsigned cols) // ��������� �������� �� ������ �� 1 �� 15
{
	bool flag = false;
	int count = 1;
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
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

void Move(int** a, unsigned rows, unsigned cols)//��� ��� ����
{
	int X, Y;
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
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
	int key;
	do
	{
		Fill_Table(a, rows, cols);
		
		key = _getch();

		if (key == CODE)
		{
			key = _getch();
		}
		switch (key)
		{
		case DOWN:
			if (X != 0)
			{
				a[X][Y] = a[X - 1][Y];
				a[X - 1][Y] = 0;
				X--;
				count++;
				
			}
			break;

		case UP:
			if (X < 3)
			{
				a[X][Y] = a[X + 1][Y];
				a[X + 1][Y] = 0;
				X++;
				count++;
			
			}
			break;

		case RIGHT:
			if (Y != 0)
			{
				a[X][Y] = a[X][Y - 1];
				a[X][Y - 1] = 0;
				Y--;
				count++;
				
			}
			break;

		case LEFT:
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
		if (!Full(a, rows, cols))
		{
			
			system("cls");
			
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					SetColor(Black, Black);
					a[i][j] = 0;
				}
			}
			system("cls");
			SetColor(Yellow, Black);
			cout << "\n\n\t\t\t �����������! �� ��������!\n\n" << endl << endl;
			SetColor(LightGreen, Black);
			cout << "\t\t\t �� �������: " << count << " �����";
			cout << endl << endl;
			SetColor(LightGreen, Black);
			
		}

	} while (key != ESC);

	if (key == ESC)
		return;

	_getch();
}

void Del(int** array, unsigned rows)// ������� ������
{

	for (unsigned int i = 0; i<rows - 1; i++)
	{
		delete[] array[i];
	}
	delete[] array;
	array = NULL;
}