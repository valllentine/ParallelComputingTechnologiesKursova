using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class MergeSort
    {
        public static int[] mergeArraysFromList(List<int[]> arrays)
        {
            int[] array = arrays[0];
            for (int i = 1; i < arrays.Count; i++)
            {
                array = merge(array, arrays[i]);
            }

            return array;
        }

        private static int[] merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];

            int firstCount = 0;
            int secondCount = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (left[firstCount] < right[secondCount])
                {
                    result[i] = left[firstCount];
                    firstCount++;
                }
                else
                {
                    result[i] = right[secondCount];
                    secondCount++;
                }

                if (firstCount == left.Length)
                {
                    i++;
                    return finishMerge(result, right, i, secondCount);
                }
                if (secondCount == right.Length)
                {
                    i++;
                    return finishMerge(result, left, i, firstCount);
                }
            }

            return result;
        }

        private static int[] finishMerge(int[] main, int[] adit, int ind, int aditInd)
        {
            while (ind < main.Length)
            {
                main[ind] = adit[aditInd];
                ind++;
                aditInd++;
            }

            return main;
        }
    }
}
