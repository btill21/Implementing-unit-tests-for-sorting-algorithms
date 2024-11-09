using System;
using Xunit;

public class BubbleSortTests
{

    // Tests that the bubble sort algorithm correctly sorts a given array of integers.
    [Fact]
    public void PositiveCase_shouldSortArray()
    {
        int[] array = { 5, 1, 4, 2, 8 };
        int[] expected = { 1, 2, 4, 5, 8 };
        Sorting.BubbleSort(array);
    
        Assert.Equal(expected, array);
    }


    // Tests that the bubble sort algorithm handles null input.
    [Fact]
    public void NegativeCase_shouldHandleNull()
    {
        int[] array = null;
        var exception = Record.Exception(() => Sorting.BubbleSort(array));
        Assert.Null(exception);
    }

    // Tests the performance of the bubble sort algorithm with a large array.
    // Generates an array of 1000 random integers, sorts it using bubble sort,
    // and compares the result with the expected sorted array.
    [Fact]
    public void PerformanceCase_shouldSortLargeArray()
    {
        int size = 1000;
        int[] array = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(size);
        }

        int[] expected = (int[])array.Clone();
        Array.Sort(expected);
        Sorting.BubbleSort(array);

        Assert.Equal(expected, array);
    }


    // Tests that the bubble sort algorithm handles various edge cases. 
    [Fact]
    public void BoundaryCase_shouldHandleEdgeCases()
    {
        int[] emptyArray = { };
        Sorting.BubbleSort(emptyArray);
        Assert.Empty(emptyArray);

        int[] singleElementArray = { 7 };
        Sorting.BubbleSort(singleElementArray);
        Assert.Equal(new int[] { 7 }, singleElementArray);

        int[] duplicateArray = { 3, 1, 2, 1, 3, 2 };
        int[] expectedDuplicates = { 1, 1, 2, 2, 3, 3 };
        Sorting.BubbleSort(duplicateArray);
        Assert.Equal(expectedDuplicates, duplicateArray);

        int[] sortedArray = { 1, 2, 3, 4, 5 };
        int[] expectedSortedArray = { 1, 2, 3, 4, 5 };
        Sorting.BubbleSort(sortedArray);
        Assert.Equal(expectedSortedArray, sortedArray);

        int[] reverseArray = { 5, 4, 3, 2, 1 };
        int[] expectedReverseArray = { 1, 2, 3, 4, 5 };
        Sorting.BubbleSort(reverseArray);
        Assert.Equal(expectedReverseArray, reverseArray);
    }

   
    // Tests that the bubble sort algorithm is idempotent. 
    // The output of the algorithm should not change after calling it multiple times.
    
    [Fact]
    public void IdempotencyCase_shouldSortArrayMultipleTimes()
    {
        int[] array = { 9, 3, 7, 2, 5 };
        int[] expected = { 2, 3, 5, 7, 9 };

        Sorting.BubbleSort(array);
        Sorting.BubbleSort(array); 

        Assert.Equal(expected, array);
    }
}
