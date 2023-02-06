/*Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9*/

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
           if(num>=0 || num==0 && zeroEnable || num<0 && negativEnable) break;
           Console.WriteLine("Введено не разрешенное значение.Попробуйте еще раз"); 
        }
    return num;  
        }
//-----------------------------МЕТОДЫ ДЛЯ ДЗ-7-------------------------------------------------------------------------
double[,] FillMatrixDouble(int rows, int cols)
{
Random rand = new Random();
double[,] matr = new double[rows, cols];
for (int i = 0; i < rows; i++)
{
for (int j = 0; j < cols; j++)
{
matr[i, j] = Math.Round(rand.Next(0, 100)+rand.NextDouble(),2);
}
}
return matr;
}
//------------------------------------------------------------------------------------------------------
void PrintMatrixDouble(double[,] matrix)//Печать массива
{
for (int i = 0; i < matrix.GetLength(0); i++)
{
for (int j = 0; j < matrix.GetLength(1); j++)
{
System.Console.Write(matrix[i, j] + "\t");
}
System.Console.WriteLine();
}
}

//------------------------------------------------------------------------------------------------------
// -------------------ОСНОВНАЯ ПРОГРАММА----------------------------------------------------------------------------
int m=InputNumberWithFilter("Введите m - количество СТРОК массива:", false, false);
int n=InputNumberWithFilter("Введите n - количество СТОЛБЦОВ(КОЛОНОК) массива:", false, false);
double[,] matrix = FillMatrixDouble(m, n);
System.Console.WriteLine();
PrintMatrixDouble(matrix);