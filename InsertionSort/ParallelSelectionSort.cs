using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    public class ParallelSelectionSort
    {
        public static int[] PSelectionSort(int[] array, int partsCount)
        {
            List<int[]> arrays = Divide(array, partsCount);

            Parallel.For(0, partsCount, i =>
            {
                int currentIndex = 0;

                for (int j = 0; j < arrays[i].Length; j++)
                {
                    int MinElementIndex = currentIndex;

                    if (currentIndex == arrays[i].Length)
                        break;

                    for (var k = currentIndex; k < arrays[i].Length; ++k)
                    {
                        if (arrays[i][k] < arrays[i][MinElementIndex])
                        {
                            MinElementIndex = k;
                        }
                    }
                    if (MinElementIndex != currentIndex)
                    {
                        var t = arrays[i][MinElementIndex];
                        arrays[i][MinElementIndex] = arrays[i][currentIndex];
                     arrays[i][currentIndex] = t;
                    }

                    currentIndex++;
                }

            });

            int[] resultArray;
            resultArray = MergeSort.mergeArraysFromList(arrays);
            return resultArray;
        }

        public static List<int[]> Divide(int[] array, int partsCount)
        {
            List<int[]> arrays = new List<int[]>();

            int elelemetsPerPart = array.Length / partsCount;
            int counter = 0;

            for (int i = 0; i < partsCount; i++)
            {
                if (i < partsCount - 1)
                {
                    arrays.Add(new int[elelemetsPerPart]);
                }
                else
                {
                    arrays.Add(new int[array.Length - counter]);
                }
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    arrays[i][j] = array[counter];
                    counter++;
                }
            }
            return arrays;
        }
    }
}
