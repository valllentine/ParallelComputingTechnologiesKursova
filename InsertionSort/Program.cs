using InsertionSort;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static int[] CreatingArray(int count)
    {
        Random rnd = new Random();
        int[] array = new int[count];

        for (int i = 0; i <= array.Length - 1; i++)
        {
            array[i] = rnd.Next(0, 10000);
        }
        return array;
    }

    static int IndexOfMin(int[] array, int n)
    {
        int result = n;
        for (var i = n; i < array.Length; ++i)
        {
            if (array[i] < array[result])
            {
                result = i;
            }
        }

        return result;
    }

    static int[] SelectionSort(int[] array)
    {
        int currentIndex = 0;
        for (int i = 0; i <= array.Length; i++)
        {
            if (currentIndex == array.Length)
                return array;

            var index = IndexOfMin(array, currentIndex);

            if (index != currentIndex)
            {
                var t = array[index];
                array[index] = array[currentIndex];
                array[currentIndex] = t;
            }
            currentIndex++;
        }
        return array;
    }

    static void ArrayWritter(int[] array, string consoleText)
    {
        Console.WriteLine(consoleText);
        foreach (int n in array)
            Console.Write(n + " ");
        Console.WriteLine();
        Console.WriteLine();
    }

    
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Уведiть бажану кiлькiсть елементiв в масивi: ");
            int count = Convert.ToInt32(Console.ReadLine());

            Console.Write("Уведiть кiлькiсть частин (потокiв), на якi буде подiлений вхiдний масив:: ");
            int partsCount = Convert.ToInt32(Console.ReadLine());


            int[] newArray = CreatingArray(count);
            ArrayWritter(newArray, "Вхідний масив:");

            var sw = new Stopwatch();
            //sw.Start();
            //int[] outputArray = SelectionSort(newArray);
            //sw.Stop();

            sw.Start();
            int[] result = ParallelSelectionSort.PSelectionSort(newArray, partsCount);
            sw.Stop();

            ArrayWritter(result, "Впорядкований масив:");

            Console.Write("Кiлькiсть елементiв у масивi: " + count + ". ");
            Console.Write("Кiлькість потокiв: " + partsCount + ". ");
            Console.Write("Час виконання алгоритму: " + sw.ElapsedMilliseconds + " мс.");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}