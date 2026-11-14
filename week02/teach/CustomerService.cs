/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: The user shall specify the maximum size of the Customer Service Queue
        // when it is created. If the size is invalid (less than or equal to 0)
        // then the size shall default to 10.
        // Expected Result: 10
        Console.WriteLine("Test 1");
        CustomerService service = new CustomerService(0);
        Console.WriteLine(service._maxSize);

        // Defect(s) Found: None

        Console.WriteLine("=================");
        Console.WriteLine("Test 2");
        // Test 2
        // Scenario: Add 3 new customer and each customer shall be added to the end
        // of the queue. The AddNewCustomer method shall enqueue a new customer into the queue.
        // Expected Result: 3 customers in the queue
        service = new CustomerService(3);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();

        Console.WriteLine(service);

        // Defect(s) Found: None, customers added correctly to the queue

        Console.WriteLine("=================");
        Console.WriteLine("Test 3");
        // Test 3
        // Scenario: If the queue is full when trying to add a customer, then an error message will be displayed.
        // Expected Result: Message - "Maximum Number of Customers in Queue."
        service = new CustomerService(2);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();

        // Defect(s) Found: None, message displayed correctly when trying to add a customer to a full queue


        Console.WriteLine("=================");
        Console.WriteLine("Test 4");
        // Test 4 
        // Scenario: The ServeCustomer function shall dequeue the next customer from the queue and display the details.
        // Expected Result: list of queued customers before and after serving the next customer in the queue
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");

        // Defect(s) Found: _queue.RemoveAt(0); was relocated to save the customer data and serve it.

        Console.WriteLine("=================");
        Console.WriteLine("Test 4");
        // Test 4 
        // Scenario: The ServeCustomer function shall dequeue the next customer from the queue and display the details.
        // Expected Result: displayed message "No Customers in Queue."

        CustomerService service2 = new CustomerService(2);
        service2.ServeCustomer();

        // Defect(s) Found: None, message displayed correctly when trying to serve a customer

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);

    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {

        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        }
        else {
        var customer = _queue[0];
        Console.WriteLine($"serve coustomer before: {customer}");
        _queue.RemoveAt(0);

        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}