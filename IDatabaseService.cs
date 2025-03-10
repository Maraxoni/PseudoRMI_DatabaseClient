using System.ServiceModel;

namespace PseudoRMI_DatabaseClient
{
    [ServiceContract]
    public interface IDatabaseService
    {
        [OperationContract]
        List<Product> GetProducts();

        [OperationContract]
        Product GetProductByName(string name);
    }
}
