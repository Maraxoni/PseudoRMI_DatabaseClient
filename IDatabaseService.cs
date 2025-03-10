using System.ServiceModel;

namespace PseudoRMI_DatabaseClient
{
    [ServiceContract]
    public interface IDatabaseService
    {
        // Pobranie listy produktów
        [OperationContract]
        List<Product> GetProducts();

        // Wyszukiwanie produktu po nazwie
        [OperationContract]
        Product GetProductByName(string name);
    }
}
