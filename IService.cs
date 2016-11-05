using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    [OperationContract]
    string GetData(int value);

    [OperationContract]
    List<Book> GetAllBooks();



    [OperationContract]
    bool AddBook(string id, string name, string author, int year, float price, int stock);

    [OperationContract]
    bool DeleteBook(string choice, string input);

    [OperationContract]
    List<Book> SearchBook(string choice, string input);


    [OperationContract]
    CompositeType GetDataUsingDataContract(CompositeType composite);


    [OperationContract]
    BookPurchaseResponse PurchaseBooks(BookPurchaseInfo info);

    // TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class Book
{
    [DataMember]
    public string ID;
    [DataMember]
    public string name;
    [DataMember]
    public string author;
    [DataMember]
    public int year;
    [DataMember]
    public float price;
    [DataMember]
    public int stock;
}

[MessageContract]
public class BookPurchaseInfo
{
    [MessageBodyMember]
    public float budget;
    [MessageBodyMember]
    public Dictionary<int, int> items;

}

[MessageContract]
public class BookPurchaseResponse
{
    [MessageHeader]
    public bool result;
    [MessageHeader]
    public string response;
}

public class CompositeType
{
    bool boolValue = true;
    string stringValue = "Hello ";

    [DataMember]
    public bool BoolValue
    {
        get { return boolValue; }
        set { boolValue = value; }
    }

    [DataMember]
    public string StringValue
    {
        get { return stringValue; }
        set { stringValue = value; }
    }
}
