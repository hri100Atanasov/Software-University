using NUnit.Framework;
using System;

public class Class1
{
    private int[] collection = new int[] { 5, 2, 1, 3, 6, 4, 7, -1, -2, -3, 0 };
    private BubbleSort bubble;
    [SetUp]
    public void InitializeBubbleSort()
    {
        bubble = new BubbleSort(collection);
        bubble.Sort();
    }

    [Test]
    public void SortTest()
    {
        var sortedCollection = new int[] { 5, 2, 1, 3, 6, 4, 7, -1, -2, -3, 0 };
        Array.Sort(sortedCollection);

        Assert.AreEqual(sortedCollection, bubble.Collection);
    }
}

