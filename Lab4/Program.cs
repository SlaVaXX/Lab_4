using System;

namespace Lab4 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Matrix matrix = new Matrix();
            int row = 0, col = 0;
            for (int i = 0;;)
            {
                Console.WriteLine();
                Console.WriteLine("Введіть допустиму команду:" +
                                  "\n(new - створити/заново створити матрицю)" +
                                  "\n(index - порахувати добуток елементів ствовпця за індексом)" +
                                  "\n(sum - середнє значення суми всіх елементів)" +
                                  "\n(matrix - вивести матрицю на консоль" +
                                  "\n(clear - почистити консоль)" +
                                  "\n(end - закінчити виконання програми)"
                );
                string temp = Console.ReadLine().ToLower();
                if (temp == "new")
                {
                    for (int j = 0; j < 2;)
                    {
                        if (j == 0)
                        {
                            Console.Write("Введіть кількість рядків матриці: ");
                            try
                            {
                                row = int.Parse(Console.ReadLine());
                                if (row <= 0)
                                {
                                    throw new Exception();
                                }

                                j++;
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                continue;
                            }
                        }

                        if (j == 1)
                        {
                            try
                            {
                                Console.Write("Введіть кількість стовпців: ");
                                col = int.Parse(Console.ReadLine());
                                if (col <= 0)
                                {
                                    throw new Exception();
                                }

                                j++;
                                Console.Clear();
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                continue;
                            }
                        }

                        matrix = new Matrix(row, col); //end init
                    }

                    i++;
                }//end new
                else if (temp == "index" && i > 0)
                {
                    IndexSum(matrix,col);
                }
                else if (temp == "sum" && i > 0)
                {
                    Console.WriteLine($"\nСереднє значення всіх елементів = {matrix.ArraySum}");
                }
                else if(temp == "matrix" && i > 0)
                {
                    matrix.print();
                }
                else if (temp == "clear")
                {
                    Console.Clear();
                }
                else if (temp == "end")
                {
                    Console.Clear();
                    break;
                }
            }
        }
        static void IndexSum(Matrix matrix, int col)
        {
            int indexTemp = 0;
            Console.WriteLine("\nВведіть індекс стовпня:\nдопустимі індекси:");
            for (int j = 0; j < col; j++)
            {
                Console.Write($"{j} ");
            }
                    
            Console.WriteLine();
            try
            {
                indexTemp = int.Parse(Console.ReadLine());
                if (indexTemp < 0 || indexTemp > col)
                {
                    throw new Exception();
                }

                Console.WriteLine($"\nДобуток елементів = {matrix[indexTemp]}");
            }
            catch (Exception)
            {
                Console.WriteLine("\nНекоректний індекс");
                IndexSum(matrix,col);
            }
        }
    }
}