namespace Activity8.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerInfoCollection customerCollection = new CustomerInfoCollection();

            CustomerInfo customer1 = new CustomerInfo(1, "John Doe", "123 Main St", "john@example.com");
            CustomerInfo customer2 = new CustomerInfo(2, "Jane Smith", "456 Oak Ave", "jane@example.com");
            customerCollection.Insert(0, customer1);
            customerCollection.Insert(1, customer2);

            string outputFile = "output.txt";
            FileHandling fileHandler = new FileHandling(outputFile);

            try
            {
                fileHandler.WriteToDisk("----- CustomerInfoCollection Test Output -----\n");

                CustomerInfo newCustomer = new CustomerInfo(3, "Bob Johnson", "789 Elm St", "bob@example.com");
                customerCollection.Insert(1, newCustomer);
                fileHandler.WriteToDisk($"Inserted customer at index 1: {customerCollection[1].Name}\n");

                customerCollection.Remove(customer2);
                fileHandler.WriteToDisk($"Customer2 removed: {customer2.Name}\n");

                bool containsCustomer = customerCollection.Contains(customer1);
                fileHandler.WriteToDisk($"Contains customer1: {containsCustomer}\n");

                int index = customerCollection.IndexOf(newCustomer);
                fileHandler.WriteToDisk($"Index of new customer: {index}\n");
            }
            catch (Exception ex)
            {
                fileHandler.WriteToDisk($"Error occurred: {ex.Message}\n");
            }

            string contentRead = fileHandler.ReadFromDisk();
            System.Console.WriteLine(contentRead);
        }
    }
}