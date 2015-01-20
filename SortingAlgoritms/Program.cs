using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using SortingAlgoritms;

namespace SortingAlgoritm
{
    class Program
    {
        static void Main()
        {
            var integers = ParseFile(@"number.txt");

            Console.WriteLine("BubbleSort - 1 \nInsertSort - 2 \nSelectionSort - 3 \nMergeSort - 4 \nQuickSort - 5 \nShellSort - 6");
            Console.WriteLine("Введите номер сортировки: ");
            string num = Console.ReadLine();
            SelectAlgoritm(num, integers);
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
            foreach (int i in input)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        static void SelectAlgoritm(string num, int[] integers)
        {
            var algoritms = new AlgoritmsImplementation();

            switch (num)
            {
                case "1":
                    Console.WriteLine("BubbleSort: ");
                    algoritms.BubbleSort(integers);
                    break;
                case "2":
                    Console.WriteLine("InsertSort: ");
                    algoritms.InsertSort(integers);
                    break;
                case "3":
                    Console.WriteLine("SelectionSort: ");
                    algoritms.SelectionSort(integers);
                    break;
                case "4":
                    Console.WriteLine("MergeSort: ");
                    algoritms.MergeSort(integers, 0, integers.Length -1 );
                    break;
                case "5":
                    Console.WriteLine("QuickSort: ");
                    algoritms.QuickSort(integers, 0, integers.Length-1);
                    break;
                case "6":
                    Console.WriteLine("ShellSort: ");
                    algoritms.ShellSort(integers);
                    break;
                default:
                    Console.WriteLine("Неправильный номер!");
                    break;
                
            }
        }

        

    }
}
