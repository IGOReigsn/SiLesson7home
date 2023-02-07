/*Задача 50. Напишите программу, которая на вход принимает число, возвращает индексы этого элемента в двумерном массиве или же указание, что такого числа нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
17 -> такого числа в массиве нет*/

// -------------------МЕТОДЫ----------------------------------------------------------------------------
// -------------------РАНЕЕ ИСПОЛЬЗОВАВШИЕСЯ МЕТОДЫ----------------------------------------------------------------------------
int InputNumber(string qwerStr)//проверяет "численность"."Не выпускает" без ввода ЧИСЛА
    {int num;
    string? text;
    while(true)
        {
            Console.WriteLine(qwerStr);
            text=Console.ReadLine();
           if(int.TryParse(text,out num)) break;
           Console.WriteLine("Введено некорректное значение.Попробуйте еще раз"); 
        }
    return num;  
    }
//------------------------------------------------------------------------------------------------------
int InputNumberWithFilter(string qwerStr, bool zeroEnable, bool negativEnable)//Пропускает положительные. 0 и отрицательные пропускает в соответствии со булевыми значениями zeroEnable,negativEnable
    {int num;
    while(true)
        {
            num=InputNumber(qwerStr);//проверяет "численность"."Не выпускает" без ввода ЧИСЛА
           if(num>0 || num==0 && zeroEnable || num<0 && negativEnable) break;
           Console.WriteLine("Введено не разрешенное значение.Попробуйте еще раз"); 
        }
    return num;  
        }
//-----------------------------МЕТОДЫ ДЛЯ ДЗ-7-------------------------------------------------------------------------
int[,] FillMatrix(int rows, int cols)
{
Random rand = new Random();
int[,] matr = new int[rows, cols];

for (int i = 0; i < rows; i++)
{
for (int j = 0; j < cols; j++)
{
matr[i, j] = rand.Next(0, 100);
}
}
return matr;
}
//------------------------------------------------------------------------------------------------------
void PrintMatrix(int[,] matr)
{
for (int i = 0; i < matr.GetLength(0); i++)
{
for (int j = 0; j < matr.GetLength(1); j++)
{
System.Console.Write(matr[i, j] + "\t");
}
System.Console.WriteLine();
}
}
//------------------------------------------------------------------------------------------------------
void FindNum(int[,] matr, int num)
{
int m=matr.GetLength(0);
int n=matr.GetLength(1);
for (int i=0;i<m;i++)
    {
      for (int j=0;j<n;j++)  
        {
            if(matr[i,j]==num)
                {
                    Console.WriteLine($"Индексы введенного числа: первый {i} второй: {j}");
                    Console.WriteLine($"что соответствует строке: {i+1} столбцу(колонке): {j+1}");
                    return;//Выход по первому результату
                }
        }
    }
Console.WriteLine("Такое число в массиве (матрице)не найдено");
}
//------------------------------------------------------------------------------------------------------
// -------------------ОСНОВНАЯ ПРОГРАММА----------------------------------------------------------------------------
int m=InputNumberWithFilter("Введите m - количество СТРОК массива (матрицы):", false, false);
int n=InputNumberWithFilter("Введите n - количество СТОЛБЦОВ(КОЛОНОК) массива (матрицы):", false, false);
int[,] matrix = FillMatrix(m, n);
System.Console.WriteLine();
PrintMatrix(matrix);
int num=InputNumberWithFilter("Введите число которое надо найти:", true,true);
FindNum(matrix,num);
