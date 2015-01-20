using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgoritms
{
    public class AlgoritmsImplementation
    {
        public void BubbleSort(int[] input)
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
            
        }

        public void InsertSort(int[] input)
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
            
        }

        public void SelectionSort(int[] integers)
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
            
        }

        private void MergeSortArray(int[] input, int left, int mid, int right)
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
        public void MergeSort(int[] input, int left, int right)
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

            
        }

        public void QuickSort(int[] input, int first, int last)
        {
            /*
             * Сложность: средняя O(n log(n)), худшая O(n^2)
             * Улучешнная версия пузырьковой сортировки
             * Выбираем опорный элемент (pivot), делим массив чтобы все что меньше опорного было слева, все что больше справа
             * Рекурсивно упорядочиваем массивы слева и справа
             */

            int middle = first + (last - first) / 2;
            //создаем опорный элемент
            int pivot = input[middle];

            int i = first, j = last;

            //делаем left < pivot and right > pivot
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

            //рекурсивно сортируем 2 подмассива
            if (first < j)
                QuickSort(input, first, j);

            if (last > i)
                QuickSort(input, i, last);

            
        }

        public void ShellSort(int[] input)
        {
            /*
             * Сложность: (n logn(n)). Часто медленне QuickSort, но потребляет меньше памяти, и не так сильно деградирует
             * Сравниваем разделенные (mid) части массива, затем сортируем вставками
             */


            int mid = input.Length / 2;

            while (mid > 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    int j = i;
                    int temp = input[i];
                    while (j >= mid && temp < input[j - mid])
                    {
                        input[j] = input[j - mid];
                        j -= mid;
                    }
                    input[j] = temp;
                }
                if (mid / 2 != 0)
                {
                    mid = mid / 2;
                }
                else if (mid == 1)
                {
                    mid = 0;
                }
                else
                {
                    mid = 1;
                }
            }
            
        }
    }
}
