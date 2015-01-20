using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoritm
{
    class Program
    {
        static void Main()
        {

            int[] integers = ParseFile(@"number.txt");


            QuickSort(integers, 0, integers.Length - 1);
            //MergeSort(integers, 0, integers.Length - 1);
            //SelectionSort(integers);

            PrintArray(integers);
        }

        static int[] ParseFile(string filepath)
        {
            string[] fileConten = File.ReadAllText(filepath).Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int[] integers = new int[fileConten.Length];
            for (int i = 0; i < fileConten.Length; i++)
            {
                integers[i] = int.Parse(fileConten[i]);
            }
            return integers;
        }

        static void PrintArray(int[] input)
        {
            Console.WriteLine("Вывод отсортированного массива: ");
            foreach (int i in input)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        static int[] BubbleSort(int[] input)
        {
            //Самый простой алгоритм, сложность O(n^2). Самый неоптимальный

            for (int i = 0; i < input.Length; i++)
            {
                //Сравниваем попрано 2 значения, если левое больше, меняем местами
                for (int j = i + 1; j < input.Length; j++)
                {

                    if (input[i] > input[j])
                    {
                        int temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }
            return input;
        }

        static int[] InsertSort(int[] input)
        {
            /*
             * Сложность O(n^2)
             * Выбираем один элемент, и вставляем в нужную позицию уже отсортированного списка
             * Берем элемент и последовательно сравниваем с левымы, в случае если он больше, вставляем его вместо сравниваемого.
             */

            for (int i = 1, j; i < input.Length; i++)
            {
                var value = input[i];

                for (j = i - 1; j >= 0 && input[j] > value; j--)
                {
                    input[j + 1] = input[j];
                }
                input[j + 1] = value;
            }
            return input;
        }

        static int[] SelectionSort(int[] integers)
        {
            /*
             * Сложность O(n^2)
             * Берем одно значение (первое) и сравниваем, как находим меньше, меняем местами и
             * продалжаем дальше сравнивать
             */

            for (int i = 0; i < integers.Length - 1; i++)
            {
                int min_i = i;
                for (int j = i + 1; j < integers.Length; j++)
                {
                    if (integers[j] < integers[min_i])
                    {
                        min_i = j;
                    }
                }
                int temp = integers[i];
                integers[i] = integers[min_i];
                integers[min_i] = temp;
            }
            return integers;
        }

        static void MergeSortArray(int[] input, int left, int mid, int right)
        {
            /* Делим массивы пока не останется 1, потом сравниваем,
             * и формируем другой масси поочередно
             * Создаем пустой массив для слияния
             * sum of size of both array to be merged)*/
            int[] temp = new int[right - left + 1];

            int i = left, j = mid + 1, k = 0;
            // ищем наименьшие элементы в 2 массивах, и формируем из них массив
            while (i <= mid && j <= right)
            {
                if (input[i] < input[j])
                {
                    temp[k] = input[i];
                    k++;
                    i++;
                }
                else
                {
                    temp[k] = input[j];
                    k++;
                    j++;
                }
            }
            // Если в первом массиве остались еще элементы, добавляем их в промежуточный
            while (i <= mid)
            {
                temp[k] = input[i];
                k++;
                i++;
            }
            // Если во втором массиве остались еще элементы, добавляем их в промежуточный
            while (j <= right)
            {
                temp[k] = input[j];
                k++;
                j++;
            }
            // Теперь в промежуточном массиве отсортированны

            // Соединиям промежуточный массив с основным
            k = 0;
            i = left;
            while (k < temp.Length && i <= right)
            {
                input[i] = temp[k];
                i++;
                k++;
            }
        }
        static int[] MergeSort(int[] input, int left, int right)
        {
            /*
             * Сложность O(n log(n))
             * Шаги алгоритма: разбиваем на части, сортируем каждую часть отдельно, соеденяем в один массив 
             */

            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(input, left, mid);
                MergeSort(input, mid + 1, right);
                MergeSortArray(input, left, mid, right);
            }

            return input;
        }

        static int[] QuickSort(int[] input, int first, int last)
        {
            int middle = first + (last - first) / 2;
            int pivot = input[middle];

            int i = first, j = last;

            //make left < pivot and right > pivot
            while (i <= j)
            {
                while (input[i] < pivot)
                {
                    i++;
                }

                while (input[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = input[i];
                    input[i] = input[j];
                    input[j] = temp;
                    i++;
                    j--;
                }
            }

            //recursively sort two sub parts
            if (first < j)
                QuickSort(input, first, j);

            if (last > i)
                QuickSort(input, i, last);

            return input;
        }


        static int[] ShellSort(int[] input)
        {
            int mid = input.Length / 2;
            while (mid > 0)
            {
                for (int i = 0; i < input.Length - mid; i++)
                {
                    int j = i + mid;
                    int temp = input[j];
                    while (j >= mid && temp > input[j - mid])
                    {
                        input[j] = input[j - mid];
                        j -= mid;
                    }
                    input[j] = temp;
                }
                if (mid == 2)
                {
                    mid = 1;
                }
                else
                {
                    mid = (int)(mid / 2.2);
                }
            }
            return input;
        }

    }
}
