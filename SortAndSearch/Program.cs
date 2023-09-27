// See https://aka.ms/new-console-template for more information


SortAlgorithms sa = new();
Helper h = new();


// Selection Sort
int[] arr1 = { 7, 3, 5, 8, 2, 9, 4, 15, 6 };

var sortedArr1 = sa.SortBySelectionSort(arr1);
h.WriteTheResult(sortedArr1);


// Insertion Sort
int[] arr2 = { 22, 27, 16, 2, 18, 6 };

var sortedArr2 = sa.SortByInsertionSort(arr2);
h.WriteTheResult(sortedArr2);


// Merge Sort
int[] arr3 = { 16, 21, 11, 8, 12, 22};

var sortedArr3 = sa.SortByMergeSort(arr3);
h.WriteTheResult(sortedArr3);



Console.ReadLine();



public class SortAlgorithms
{
    public int[] SortBySelectionSort(int[] ssArr)
    {
        for (int i = 0; i < ssArr.Length; i++) // n times => O(n)
        {
            int min = i;
            for (int j = i + 1; j < ssArr.Length; j++) // 1.step; (n-1) times, 2.step; (n-2) times ..... (n-1).step; (n - n-1) = 1 times, n.step; (n-n) = 0 times executes.
            {                                          // (n-1) + (n-2) + ... 2 + 1 + 0 => ((n-1)(n-1 + 1))/2 = (n^2 -n)/2 => O(n^2)
                if (ssArr[min] > ssArr[j])
                    min = j;
            }

            if (min != i)
            {
                // Swap values using a temp variable
                //int less = ssArr[key];
                //ssArr[key] = ssArr[i];
                //ssArr[i] = less;

                // Swap values using Tuple
                (ssArr[i], ssArr[min]) = (ssArr[min], ssArr[i]);
            }
        }

        return ssArr;
    }

    public int[] SortByInsertionSort(int[] inArr)
    {
        for (int i = 1; i < inArr.Length; i++) // n-1 times => O(n)
        {
            for (int j = i - 1; j >= 0; j--)   // 1.step; 1 times, 2.step; 2 times, 3.step; 3 times ....... (n-1).step; (n-1) times executes
            {                                  // 1 + 2 + 3 + .... + (n-1) => ((n-1)(n-1 + 1))/2 => O(n^2)         
                if (inArr[j + 1] < inArr[j])
                    (inArr[j + 1], inArr[j]) = (inArr[j], inArr[j + 1]);
            }

        }

        return inArr;
    }

    public int[] SortByMergeSort(int[] meArr)
    {
        if (meArr.Length <= 1)
            return meArr;

        int mid = meArr.Length / 2;

        int[] leftSortedArr = SortByMergeSort(meArr.Take(mid).ToArray());
        int[] rightSortedArr = SortByMergeSort(meArr.Skip(mid).Take(meArr.Length - mid).ToArray());

        return MergeSortedArrays(leftSortedArr, rightSortedArr);
    }

    private int[] MergeSortedArrays(int[] arr1, int[] arr2)
    {
        int i1, i2, ir;
        i1 = i2 = ir = 0;

        int[] result = new int[arr1.Length + arr2.Length];

        while(i1 < arr1.Length && i2 < arr2.Length)
        {
            if (arr1[i1] < arr2[i2])
            {
                result[ir] = arr1[i1];
                i1++;
            }
            else
            {
                result[ir] = arr2[i2];
                i2++;
            }
            ir++;
        }

        while(i1 < arr1.Length)
        {
            result[ir] = arr1[i1];
            ir++;
            i1++;
        }

        while (i2 < arr2.Length)
        {
            result[ir] = arr2[i2];
            ir++;
            i2++;
        }

        return result;

    }
}

public class Helper
{
    public void WriteTheResult(int[] sortedArr)
    {
        Console.WriteLine(string.Join(", ", sortedArr.Select(e => e)));
        Console.WriteLine("----------------------------------------");
    }
}