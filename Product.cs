using System.Runtime.Serialization;


[DataContract]
public class Product
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public double Price { get; set; }
    [DataMember]
    public string Description { get; set; }

    public Product(int id, string name, double price, string description = "")
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price}, Description: {Description}";
    }
}