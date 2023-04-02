namespace Lab4;

public class Matrix
{
    private int[,] _array;
    private float _sumAll;

    public Matrix()
    {
    }

    public Matrix(int i, int j)
    {
        _array = new int[i, j];
        Console.WriteLine("Введіть ціле значення елементу матриці: ");
        int temp;
        for (int k = 0; k < i; k++)
        {
            for (int l = 0; l < j;)
            {
                try
                {
                    Console.Write($"Matrix[{k},{l}] = ");
                    temp = Convert.ToInt32(Console.ReadLine());
                    _array[k, l] = temp;
                    l++;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        } //end init

        print();
        SumAll(_array);
    }

    public int this[int index]
    {
        get => Sum(_array, index);
    }

    public float ArraySum => _sumAll / _array.Length;

    private int Sum(int[,] arr, int i)
    {
        int result = 1;
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            result *= arr[j, i];
        }

        return result;
    }

    public void print()
    {
        Console.Clear();
        Console.WriteLine("Матриця:");
        for (int i = 0; i < _array.GetLength(0); i++)
        {
            for (int j = 0; j < _array.GetLength(1); j++)
            {
                Console.Write($"{_array[i, j]}\t");
            }

            Console.WriteLine();
        }
    }

    private void SumAll(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                _sumAll += _array[i, j];
            }
        }
    }
}