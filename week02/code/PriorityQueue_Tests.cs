using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Items are added to the back of the queue.
    // Expected Result: [Ana (Pri:2), Bob (Pri:5), Carlos (Pri:8)]
    // Items remain in insertion order, regardless of priority.
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Ana", 2);
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Carlos", 8);

        var result = priorityQueue.ToString();
        Assert.AreEqual("[Ana (Pri:2), Bob (Pri:5), Carlos (Pri:8)]", result);
    }

    [TestMethod]
    // Scenario: Verify that the highest-priority item is returned and removed.
    // Expected Result: Carlos
    // The item with the highest priority is returned and no longer exists in the queue.
    // Defect(s) Found:

    // 1) <Carlos> was expected, but <Bob> was returned.
    // -1 was deleted from Line 27 -> for (int index = 1; index < _queue.Count - 1; index++)
    // because the loop should iterate through the entire queue.
 
    //2) _queue.RemoveAt(highPriorityIndex); was added to remove the item with the highest priority from the queue after it is returned.


    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Ana", 2);
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Carlos", 8);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Carlos", result);

        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("Bob", result2);
    }

    [TestMethod]
    // Scenario: Verify FIFO when multiple items share the highest priority.
    // Expected Result: Gina
    // The item that was added first is removed first.
    // Defect(s) Found: <Gina> was expected, but <Carlos> was returned.

    // 1) <= was changed to < in Line 29 -> if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
    // in that way the first item with the highest priority is returned acomplish the FIFO behavior.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Gina", 8);
        priorityQueue.Enqueue("Ana", 2);
        priorityQueue.Enqueue("Carlos", 8);
        priorityQueue.Enqueue("Diana", 5);


        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Gina", result);

        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("Carlos", result2);
    }


    [TestMethod]
    // Scenario: Verify what happens when Dequeue() is called on an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the exact message "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

}