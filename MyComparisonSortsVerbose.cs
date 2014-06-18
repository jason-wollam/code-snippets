using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPrograms
{
    class MyComparisonSortsVerbose
    {
        int counter = 0;
        /// <summary>
        /// Main method containing test code for sorting algos
        /// </summary>
        static void Main()
        {
            long[] inputArray;

            MyComparisonSortsVerbose mArray = new MyComparisonSortsVerbose();

            mArray.Reset(out inputArray);
            mArray.BubbleSort(inputArray);

            Console.ReadLine();

            mArray.Reset(out inputArray);
            mArray.SelectionSort(inputArray);

            Console.ReadLine();

            mArray.Reset(out inputArray);
            mArray.InsertionSort(inputArray);

            Console.ReadLine();

            mArray.Reset(out inputArray);
            mArray.ShellSort(inputArray);

            Console.ReadLine();

            mArray.Reset(out inputArray);
            mArray.MergeSort(inputArray);

            Console.ReadLine();

            mArray.Reset(out inputArray);
            mArray.HeapSort(inputArray);

            Console.ReadLine();

            mArray.Reset(out inputArray);
            mArray.QuickSort(inputArray);

            Console.ReadLine();
        }

        /// <summary>
        /// Reset input test array and initialize it to the hard coded values to perform sort
        /// </summary>
        /// <param name="inputArray"></param>
        private void Reset(out long[] inputArray)
        {
            inputArray = new long[10] { 6, 8, 7, 9, 2, 4, 3, 1, 0, 5 };
        }

        /// <summary>
        /// Re-usable Swap method for various swap based sorting algorithms
        /// </summary>
        /// <param name="valOne"></param>
        /// <param name="valTwo"></param>
        private void Swap(ref long valOne, ref long valTwo)
        {
            valOne = valOne + valTwo;
            valTwo = valOne - valTwo;
            valOne = valOne - valTwo;
        }

        private void SwapWithTemp(ref long valOne, ref long valTwo)
        {
            long temp = valOne;
            valOne = valTwo;
            valTwo = temp;
        }

        /// <summary>
        /// Simple display method to return contents of array in string form to print on screen
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        public string Display(long[] inputArray)
        {
            StringBuilder resultString = new StringBuilder();
            for (int i = 0; i < inputArray.Length; i++)
            {
                resultString.Append(inputArray[i].ToString() + "  ");
            }
            return resultString.ToString().Trim();
        }

        /// <summary>
        /// Parent Category - Comparison sort
        /// Category - Exchange sort
        /// Bubble sort - It is a straightforward and simplistic method of sorting data. The algorithm starts at the beginning of the data set. 
        /// It compares the first two elements, and if the first is greater than the second, then it swaps them. 
        /// It continues doing this for each pair of adjacent elements to the end of the data set. 
        /// It then starts again with the first two elements, repeating until no swaps have occurred on the last pass. 
        /// This algorithm is highly inefficient, and is rarely used.
        /// Best case - O(n)
        /// Average case - O(n^2)
        /// Worst case - O(n^2)
        /// </summary>
        /// <param name="inputArray"></param>
        private void BubbleSort(long[] inputArray)
        {
            Console.WriteLine("\nSorted Array { " + Display(inputArray) + "} using Bubble Sort");
            for (int iterator = 0; iterator < inputArray.Length; iterator++)
            {
                for (int index = 0; index < inputArray.Length - 1; index++)
                {
                    if (inputArray[index] > inputArray[index + 1])
                    {
                        Swap(ref inputArray[index], ref inputArray[index + 1]);
                    }

                    Console.WriteLine("\tAfter pass " + (index + 1) + ":");
                    Console.WriteLine("\t" + Display(inputArray));
                }
                Console.WriteLine("\nAfter iteration " + (iterator + 1) + ":");
                Console.WriteLine(Display(inputArray));
            }
        }

        /// <summary>
        /// Parent Category - Comparison sort
        /// Category - Insertion sort
        /// Insertion sort - It is a simple sorting algorithm that is relatively efficient for small lists and mostly-sorted lists, 
        /// and often is used as part of more sophisticated algorithms. 
        /// It works by taking elements from the list one by one and inserting them in their correct position into a new sorted list.
        /// Shell sort is a variant of insertion sort which is more efficient for larger lists because in arrays, insertion is expensive 
        /// and requires shifting of all elements over by one.
        /// Best case - O(n)
        /// Average case - O(n^2)
        /// Worst case - O(n^2) 
        /// </summary>
        /// <param name="inputArray"></param>
        private void InsertionSort(long[] inputArray)
        {
            long j = 0;
            long temp = 0;

            Console.WriteLine("\nSorted Array { " + Display(inputArray) + "} using Insertion Sort");

            for (int index = 1; index < inputArray.Length; index++)
            {
                j = index;
                temp = inputArray[index];

                while ((j > 0) && (inputArray[j - 1] > temp))
                {
                    inputArray[j] = inputArray[j - 1];
                    j = j - 1;
                    Console.WriteLine("\tAfter pass " + index + ":");
                    Console.WriteLine("\t" + Display(inputArray));
                }
                inputArray[j] = temp;
                Console.WriteLine("\nAfter iteration " + index + ":");
                Console.WriteLine(Display(inputArray));
            }
        }

        /// <summary>
        /// Parent Category - Comparison sort
        /// Category - Insertion sort
        /// Shell sort - It improves upon bubble sort and insertion sort by moving out of order elements more than one position at a time.
        /// It compares elements separated by a gap of several positions. This lets an element take "bigger steps" toward its expected position. 
        /// Multiple passes over the data are taken with smaller and smaller gap sizes. 
        /// The last step of Shell sort is a plain insertion sort, but by then, the array of data is guaranteed to be almost sorted.
        /// Best case - O(n)
        /// Average case - depends on gap sequence
        /// Worst case - O(n^2) or O(nlog^2 n) depends on gap sequence 
        /// </summary>
        /// <param name="inputArray"></param>
        private void ShellSort(long[] inputArray)
        {
            Console.WriteLine("\nSorted Array { " + Display(inputArray) + "} using Shell Sort");
            int iterator = 0;
            long j, temp = 0;
            int increment = (inputArray.Length) / 2;
            while (increment > 0)
            {
                for (int index = 0; index < inputArray.Length; index++)
                {
                    j = index;
                    temp = inputArray[index];
                    while ((j >= increment) && inputArray[j - increment] > temp)
                    {
                        inputArray[j] = inputArray[j - increment];
                        j = j - increment;
                    }
                    inputArray[j] = temp;
                    Console.WriteLine("\tAfter pass " + (index + 1) + ":");
                    Console.WriteLine("\t" + Display(inputArray));
                }

                if (increment / 2 != 0)
                    increment = increment / 2;
                else if (increment == 1)
                    increment = 0;
                else
                    increment = 1;
                iterator++;
                Console.WriteLine("\nAfter iteration " + (iterator) + ":");
                Console.WriteLine(Display(inputArray));
            }
        }

        /// <summary>
        /// Parent Category - Comparison sort
        /// Category - Selection sort
        /// Selection sort - in-place comparison sort.
        /// It has O(n2) complexity, making it inefficient on large lists, and generally performs worse than the similar insertion sort. 
        /// Selection sort is noted for its simplicity, and also has performance advantages over more complicated algorithms in certain situations.
        /// Better than bubble sort in almost all cases
        /// Best case - O(n^2)
        /// Average case - O(n^2)
        /// Worst case - O(n^2)  
        /// </summary>
        /// <param name="inputArray"></param>
        private void SelectionSort(long[] inputArray)
        {
            Console.WriteLine("\nSorted Array { " + Display(inputArray) + "} using Selection Sort");
            long index_of_min = 0;
            for (int iterator = 0; iterator < inputArray.Length - 1; iterator++)
            {
                index_of_min = iterator;
                for (int index = iterator + 1; index < inputArray.Length; index++)
                {
                    if (inputArray[index] < inputArray[index_of_min])
                        index_of_min = index;
                    Console.WriteLine("\tAfter pass " + index + ":");
                    Console.WriteLine("\tMinimum value is " + inputArray[index_of_min] + " at index " + index_of_min);
                }
                Swap(ref inputArray[iterator], ref inputArray[index_of_min]);
                Console.WriteLine("\nAfter iteration " + (iterator + 1) + ":");
                Console.WriteLine(Display(inputArray));
            }
        }

        /// <summary>
        /// Parent Category - Comparison sort
        /// Category - Merge sort
        /// Merge sort - It takes advantage of the ease of merging already sorted lists into a new sorted list. 
        /// It starts by comparing every two elements (i.e., 1 with 2, then 3 with 4...) and swapping them if the first should come after the second. 
        /// It then merges each of the resulting lists of two into lists of four, then merges those lists of four, and so on; 
        /// until at last two lists are merged into the final sorted list.
        /// In most implementations it is stable, meaning that it preserves the input order of equal elements in the sorted output. 
        /// It is an example of the divide and conquer algorithmic paradigm.
        /// Best case - O(n) or O(n log n)
        /// Average case - O(n log n)
        /// Worst case - O(n log n)  
        /// </summary>
        /// <param name="inputArray"></param>
        private void MergeSort(long[] inputArray)
        {
            Console.WriteLine("\nSorted Array { " + Display(inputArray) + "} using Merge Sort");
            int left = 0;
            int right = inputArray.Length - 1;
            InternalMergeSort(inputArray, left, right);
            Console.WriteLine(Display(inputArray));
        }

        /// <summary>
        /// Internal recursive sort algorithm for merge sort using divide and conquer
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private void InternalMergeSort(long[] inputArray, int left, int right)
        {
            int mid = 0;

            if (left < right)
            {
                mid = (left + right) / 2;
                InternalMergeSort(inputArray, left, mid);
                InternalMergeSort(inputArray, (mid + 1), right);

                MergeSortedArray(inputArray, left, mid, right);
                Console.WriteLine("\tAfter pass " + (counter++) + ":");
                Console.WriteLine("\t" + Display(inputArray));
            }
        }

        /// <summary>
        /// Merging two sorted lists into a big sorted list step by step i.e. each of the resulting lists of two into lists of four, 
        /// then merges those lists of four, and so on; 
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="left"></param>
        /// <param name="mid"></param>
        /// <param name="right"></param>
        private void MergeSortedArray(long[] inputArray, int left, int mid, int right)
        {
            int index = 0;
            int total_elements = right - left + 1; //BODMAS rule
            int right_start = mid + 1;
            int temp_location = left;
            long[] tempArray = new long[total_elements];

            while ((left <= mid) && right_start <= right)
            {
                if (inputArray[left] <= inputArray[right_start])
                {
                    tempArray[index++] = inputArray[left++];
                }
                else
                {
                    tempArray[index++] = inputArray[right_start++];
                }
            }

            if (left > mid)
            {
                for (int j = right_start; j <= right; j++)
                    tempArray[index++] = inputArray[right_start++];
            }
            else
            {
                for (int j = left; j <= mid; j++)
                    tempArray[index++] = inputArray[left++];
            }

            //Array.Copy(tempArray, 0, inputArray, temp_location, total_elements); // just another way of accomplishing things (in-built copy)
            for (int i = 0, j = temp_location; i < total_elements; i++, j++)
            {
                inputArray[j] = tempArray[i];
            }
        }

        /// <summary>
        /// Parent Category - Comparison sort
        /// Category - Selection sort
        /// Heap sort - It is a comparison-based sorting algorithm, and is part of the selection sort family. 
        /// Although somewhat slower in practice on most machines than a good implementation of quicksort, 
        /// it has the advantage of a more favorable worst-case Θ(n log n) runtime. Heapsort is an in-place algorithm, 
        /// but is not a stable sort.
        /// Best case - O(n log n)
        /// Average case - O(n log n)
        /// Worst case - O(n log n)  
        /// </summary>
        /// <param name="inputArray"></param>
        private void HeapSort(long[] inputArray)
        {
            Console.WriteLine("\nSorted Array { " + Display(inputArray) + "} using Heap Sort");
            for (int index = (inputArray.Length / 2) - 1; index >= 0; index--)
                Heapify(inputArray, index, inputArray.Length);

            for (int index = inputArray.Length - 1; index >= 1; index--)
            {
                SwapWithTemp(ref inputArray[0], ref inputArray[index]);
                Heapify(inputArray, 0, index - 1);
            }
            Console.WriteLine(Display(inputArray));
        }

        /// <summary>
        /// Heapify method to build a heap data structure out of array contents.
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="root"></param>
        /// <param name="bottom"></param>
        private void Heapify(long[] inputArray, int root, int bottom)
        {
            bool completed = false;
            int maxChild;

            while ((root * 2 <= bottom) && (!completed))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (inputArray[root * 2] > inputArray[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;

                if (inputArray[root] < inputArray[maxChild])
                {
                    Swap(ref inputArray[root], ref inputArray[maxChild]);
                    root = maxChild;
                    Console.WriteLine("\tHeapifying :" + Display(inputArray));
                }
                else
                {
                    completed = true;
                }
            }
        }

        /// <summary>
        /// Parent Category - Comparison sort
        /// Category - Exchange sort
        /// Quick Sort - It is a divide and conquer algorithm which relies on a partition operation: 
        /// To partition an array, choose an element, called a pivot, move all smaller elements before the pivot, 
        /// and move all greater elements after it. This can be done efficiently in linear time and in-place. 
        /// Later recursively sort the lesser and greater sublists.
        /// Best case - O(n log n)
        /// Average case - O(n log n)
        /// Worst case - O(n^2)  
        /// </summary>
        /// <param name="inputArray"></param>
        private void QuickSort(long[] inputArray)
        {
            Console.WriteLine("\nSorted Array { " + Display(inputArray) + "} using Quick Sort");
            int left = 0;
            int right = inputArray.Length - 1;
            InternalQuickSort(inputArray, left, right);
            Console.WriteLine(Display(inputArray));
        }

        /// <summary>
        /// Internal recursive sort algorithm for quick sort using divide and conquer. Sorting is done based on pivot
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private void InternalQuickSort(long[] inputArray, int left, int right)
        {
            int pivotNewIndex = Partition(inputArray, left, right);

            long pivot = inputArray[(left + right) / 2];

            if (left < pivotNewIndex - 1)
                InternalQuickSort(inputArray, left, pivotNewIndex - 1);

            if (pivotNewIndex < right)
                InternalQuickSort(inputArray, pivotNewIndex, right);
        }

        /// <summary>
        /// This operation returns a new pivot everytime it is called recursively and swaps the array elements based on pivot value comparison
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int Partition(long[] inputArray, int left, int right)
        {
            int i = left, j = right;
            long pivot = inputArray[(left + right) / 2];

            while (i <= j)
            {
                while (inputArray[i] < pivot)
                    i++;
                while (inputArray[j] > pivot)
                    j--;
                if (i <= j)
                {
                    SwapWithTemp(ref inputArray[i], ref inputArray[j]);
                    i++; j--;
                }
            }
            return i;
        }

        #region Array Supporting functions

        /// <summary>
        /// Min - to find the minimum value from array contents
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        private long Min(long[] inputArray)
        {
            long min = inputArray[0];
            for (int iterator = 0; iterator < inputArray.Length; iterator++)
            {
                if (inputArray[iterator] < min)
                    min = inputArray[iterator];
            }
            return min;
        }

        /// <summary>
        /// Max - to find the maximum value from array contents
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        private long Max(long[] inputArray)
        {
            long max = inputArray[0];
            for (int iterator = 0; iterator < inputArray.Length; iterator++)
            {
                if (inputArray[iterator] > max)
                    max = inputArray[iterator];
            }
            return max;
        }

        #endregion
    }
}
