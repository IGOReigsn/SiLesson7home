/*Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.*/

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
double[,] FillMatrixDouble(int rows, int cols)
{
Random rand = new Random();
double[,] matr = new double[rows, cols];
for (int i = 0; i < rows; i++)
{
for (int j = 0; j < cols; j++)
{
matr[i, j] = rand.Next(0, 100);//ДЕЛАЕМ ЦЕЛЫЕ ЗНАЧЕНИЯ ДЛЯ УДОБСТВА ПРОВЕРКИ
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
void CalcAndPrintAvgInColumnsInMatrix(double[,] matrix)//
{int m=matrix.GetLength(0);//Что бы не вызывать много раз метод и для удобочитаемости
int n=matrix.GetLength(1);
double [] agvarr =new double[n] ;
for (int j=0; j<n; j++)//обнуляем массив для результатов
{
    agvarr[j]=0;
}

for (int j=0; j<n; j++)
    {
        for (int i=0; i<m; i++)
        {agvarr[j]=agvarr[j]+matrix[i,j];}
    }
for (int j=0; j<n; j++)//
    {
    agvarr[j]=Math.Round(agvarr[j]/m,2);
    System.Console.Write(agvarr[j] + "\t");
    }
}
//------------------------------------------------------------------------------------------------------
// -------------------ОСНОВНАЯ ПРОГРАММА----------------------------------------------------------------------------
int m=InputNumberWithFilter("Введите m - количество СТРОК массива:", false, false);
int n=InputNumberWithFilter("Введите n - количество СТОЛБЦОВ(КОЛОНОК) массива:", false, false);
double[,] matr = FillMatrixDouble(m, n);
System.Console.WriteLine();
PrintMatrixDouble(matr);
CalcAndPrintAvgInColumnsInMatrix(matr);//конечно, можно расчет и печать разнести. Тогда добавтся еще один цикл до n