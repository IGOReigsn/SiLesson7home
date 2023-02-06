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
// -------------------ОСНОВНАЯ ПРОГРАММА----------------------------------------------------------------------------
int m=InputNumberWithFilter("Введите m - количество СТРОК массива:", false, false);
int n=InputNumberWithFilter("Введите n - количество СТОЛБЦОВ(КОЛОНОК) массива:", false, false);
int[,] matrix = FillMatrix(m, n);
System.Console.WriteLine();
PrintMatrix(matrix);
int n=InputNumberWithFilter("Введите число (индекс):", true, false);