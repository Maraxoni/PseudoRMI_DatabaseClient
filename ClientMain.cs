using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace PseudoRMI_DatabaseClient
{
    class DatabaseClient
    {
        static void Main(string[] args)
        {
            // Communication method
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            // Defining address
            //System.ServiceModel.EndpointAddress httpEndpoint = new System.ServiceModel.EndpointAddress("http://192.168.50.183:8080/DatabaseService");
            System.ServiceModel.EndpointAddress httpEndpoint = new System.ServiceModel.EndpointAddress("http://localhost:8080/DatabaseService");
            // Dynamically creating channels that implement interface
            ChannelFactory<IDatabaseService> myChannelFactory = new ChannelFactory<IDatabaseService>(httpBinding, httpEndpoint);

            IDatabaseService wcfClient1 = myChannelFactory.CreateChannel();

            while (true)
            {
                Console.WriteLine("Enter product name, '1' to list all products or 'exit' to quit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                try
                {
                    if (input.ToLower() == "1")
                    {
                        List<Product> products = wcfClient1.GetProducts(); // Przykładowe pobranie listy produktów
                        foreach (Product product in products)
                        {
                            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Description: {product.Description}");
                        }
                    }
                    else
                    {
                        Product result = wcfClient1.GetProductByName(input);

                        if (result != null)
                        {
                            Console.WriteLine($"Product found: {result.ToString()}");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            myChannelFactory.Close();
        }
    }
}