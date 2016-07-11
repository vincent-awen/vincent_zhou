
using System;
namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arrayInt = { 1, 2, 3, 5, 9, 11, 14, 21, 28, 29, 32, 34, 35, 36, 39, 41, 42, 53, 67, 100, 132 };
            ////Console.WriteLine(BinarySearch1(arrayInt, 0, arrayInt.Length - 1, 10));
            //Console.WriteLine(BinarySearch2(arrayInt, 0, arrayInt.Length - 1, 32));
            int[] unSortedArrayInt = { 3, 2, 1, 9, 5, 100, 4, 6, 7, 83 };
            //BubbleSort(unSortedArrayInt);
            //InsertSort(unSortedArrayInt);
            //QuickSort(unSortedArrayInt, 0, unSortedArrayInt.Length - 1);
            //QuickSort3(unSortedArrayInt, 0, unSortedArrayInt.Length - 1);
            SelectionSort(unSortedArrayInt);
            foreach (var item in unSortedArrayInt)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static int BinarySearch1(int[] array, int start, int end, int value)
        {
            if (start > end)
            {
                return -1;
            }
            int middle = start + (end - start) / 2;
            if (array[middle] < value)
            {
                return BinarySearch1(array, middle + 1, end, value);
            }
            else if (array[middle] > value)
            {
                return BinarySearch1(array, start, middle - 1, value);
            }
            else
            {
                return middle;
            }
        }

        static int BinarySearch2(int[] array, int start, int end, int value)
        {
            int middle;
            while (start <= end)
            {
                middle = start + (end - start) / 2;
                if (array[middle] < value)
                {
                    start = middle + 1;
                }
                else if (array[middle] > value)
                {
                    end = middle - 1;
                }
                else
                {
                    return middle;
                }
            }
            return -1;
        }

        static void BubbleSort(int[] arrayInt)
        {
            int tmp = 0;
            for (int i = 0; i < arrayInt.Length - 1; i++)
            {
                for (int j = 0; j < arrayInt.Length - i - 1; j++)
                {
                    if (arrayInt[j] > arrayInt[j + 1])
                    {
                        tmp = arrayInt[j];
                        arrayInt[j] = arrayInt[j + 1];
                        arrayInt[j + 1] = tmp;
                    }
                }
            }
        }

        static void InsertSort(int[] arrayInt)
        {
            int i, j, temp;
            for (i = 1; i < arrayInt.Length; i++)
            {
                temp = arrayInt[i];
                for (j = i - 1; j >= 0 && arrayInt[j] > temp; j--)
                {
                    arrayInt[j + 1] = arrayInt[j];
                }
                arrayInt[j + 1] = temp;
            }
        }

        //static void QuickSort(int[] arrayInt, int left, int right)
        //{
        //    if (left >= right)
        //    {
        //        return;
        //    }
        //    int middle = arrayInt[(left + right) / 2];
        //    int i = left - 1;
        //    int j = right + 1;
        //    while (true)
        //    {
        //        while (arrayInt[++i] < middle) ;
        //        while (arrayInt[--j] > middle) ;
        //        if (i > j)
        //            break;

        //        Swap(arrayInt, i, j);
        //    }
        //    QuickSort(arrayInt, left, i - 1);
        //    QuickSort(arrayInt, j + 1, right);
        //}

        //static void QuickSort2(int[] arrayInt, int left, int right)
        //{
        //    if (left >= right)
        //    {
        //        return;
        //    }
        //    int middle = arrayInt[left];
        //    int i = left + 1;
        //    int j = right;
        //    while (true)
        //    {
        //        while (arrayInt[j] > middle)
        //        {
        //            j--;
        //        }
        //        while (arrayInt[i] < middle && i < j && (i < arrayInt.Length - 1))
        //        {
        //            i++;
        //        }
        //        if (i > j)
        //            break;

        //        Swap(arrayInt, i, j);
        //        i++; j--;
        //    }
        //    if (j != left)
        //        Swap(arrayInt, left, j);
        //    QuickSort2(arrayInt, j + 1, right);
        //    QuickSort2(arrayInt, left, j - 1);
        //}

        static int GetSplitNum(int[] arrayInt, int left, int right)
        {
            int splitNum = arrayInt[left];
            while (left < right)
            {
                while (left < right && splitNum <= arrayInt[right])
                {
                    right--;
                }
                arrayInt[left] = arrayInt[right];
                while (left < right && splitNum >= arrayInt[left])
                {
                    left++;
                }
                arrayInt[right] = arrayInt[left];
            }
            arrayInt[left] = splitNum;
            return left;
        }

        static void QuickSort3(int[] arrayInt, int left, int right)
        {
            if (left < right)
            {
                int middle = GetSplitNum(arrayInt, left, right);
                QuickSort3(arrayInt, left, middle - 1);
                QuickSort3(arrayInt, middle + 1, right);
            }
        }

        static void Swap(int[] arrayInt, int i, int j)
        {
            int tmp = arrayInt[i];
            arrayInt[i] = arrayInt[j];
            arrayInt[j] = tmp;
        }

        static void SelectionSort(int[] arrayInt)
        {
            int min, tmp;
            for (int i = 0; i < arrayInt.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < arrayInt.Length; j++)
                {
                    if (arrayInt[min] > arrayInt[j])
                    {
                        min = j;
                    }
                }
                tmp = arrayInt[min];
                arrayInt[min] = arrayInt[i];
                arrayInt[i] = tmp;
            }
        }
    }
}
