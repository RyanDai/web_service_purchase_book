using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public string GetData(int value)
    {
        return string.Format("You entered: {0}", value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        if (composite == null)
        {
            throw new ArgumentNullException("composite");
        }
        if (composite.BoolValue)
        {
            composite.StringValue += "Suffix";
        }
        return composite;
    }

    public List<Book> GetAllBooks()
    {
        List<Book> books = new List<Book>();
        string text = System.IO.File.ReadAllText(@"H:\INFS3204\books.txt");
        string[] textArray = text.Split('\n');

        for (int i = 0; i < textArray.Length; i++)
        {
            try
            {
                Book thisBook = new Book();
                string[] bookElement = textArray[i].Split(',');
                //Console.WriteLine(bookElement.Length + '\n');
                thisBook.ID = bookElement[0];
                thisBook.name = bookElement[1];
                thisBook.author = bookElement[2];
                thisBook.year = Convert.ToInt16(bookElement[3]);

                string bookPrice = bookElement[4];
                bookPrice = bookPrice.Substring(1);
                try
                {
                    thisBook.price = float.Parse(bookPrice);
                }
                catch
                {

                }

                thisBook.stock = Convert.ToInt16(bookElement[5]);
                books.Add(thisBook);
            }
            catch { }
        }
        return books;
    }

    public bool AddBook(string id, string name, string author, int year, float price, int stock)
    {
        string yearStr = Convert.ToString(year);
        string priceStr = Convert.ToString(price);
        string stockStr = Convert.ToString(stock);
        string bookDesc = id + "," + name + "," + author + "," + yearStr + "," + "$" + priceStr + "," + stockStr;

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"H:\INFS3204\books.txt", true))
        {
            file.WriteLine(bookDesc);
        }
        //System.IO.File.WriteAllText(@"H:\INFS3204\books.txt", bookDesc);
        return true;
    }

    public bool DeleteBook(string choice, string input)
    {
        List<Book> books = GetAllBooks();
        if (choice.Equals("Year"))
        {
            System.IO.File.WriteAllText(@"H:\INFS3204\books.txt", string.Empty);
            try
            {
                int year = Convert.ToInt16(input);
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].year != year)
                    {
                        string bookDesc = books[i].ID + "," + books[i].name + "," + books[i].author + "," + books[i].year + "," + "$" + books[i].price + "," + books[i].stock;
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"H:\INFS3204\books.txt", true))
                        {
                            file.WriteLine(bookDesc);
                        }
                    }
                }
                return true;
            } catch
            {

            }
            
        }

        if (choice.Equals("ID"))
        {
            System.IO.File.WriteAllText(@"H:\INFS3204\books.txt", string.Empty);
            for (int i = 0; i < books.Count; i++)
            {
                if (!(books[i].ID.Equals(input)))
                {
                    string bookDesc = books[i].ID + "," + books[i].name + "," + books[i].author + "," + books[i].year + "," + "$" + books[i].price + "," + books[i].stock;
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"H:\INFS3204\books.txt", true))
                    {
                        file.WriteLine(bookDesc);
                    }
                }
            }
            return true;
        }

        if (choice.Equals("Num"))
        {
            System.IO.File.WriteAllText(@"H:\INFS3204\books.txt", string.Empty);
            int index = 1;
            try
            {
                int number = Convert.ToInt16(input);
                Dictionary<int, Book> dict = new Dictionary<int, Book>();
                for (int i = 0; i < books.Count; i++)
                {
                    dict.Add(index, books[i]);
                    index++;
                }
                try
                {
                    foreach (KeyValuePair<int, Book> pair in dict)
                    {
                        if (pair.Key == number)
                        {
                            dict.Remove(pair.Key);
                        }
                    }
                }
                catch { }

                foreach (KeyValuePair<int, Book> pair in dict)
                {
                    string bookDesc = pair.Value.ID + "," + pair.Value.name + "," + pair.Value.author + "," + pair.Value.year + "," + "$" + pair.Value.price + "," + pair.Value.stock;
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"H:\INFS3204\books.txt", true))
                    {
                        file.WriteLine(bookDesc);
                    }
                }
                return false;
            }



            catch
            {

            }
        }
        return true;

    }

    public List<Book> SearchBook(string choice, string input)
    {
        List<Book> result = new List<Book>();
        List<Book> books = GetAllBooks();

        if (choice.Equals("Name"))
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].name.ToLower().Contains(input.ToLower()))
                   
                {
                    result.Add(books[i]);
                }
            }
            return result;
        }

        if (choice.Equals("ID"))
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ID.Equals(input))
                {
                    result.Add(books[i]);
                }
            }
            return result;
        }

        if (choice.Equals("Author"))
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].author.Contains(input) || string.Equals(books[i].author, input, StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(books[i]);
                }
            }
            return result;
        }

        if (choice.Equals("Year"))
        {
            try {
                int year = Convert.ToInt16(input);
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].year == year)
                    {
                        result.Add(books[i]);
                    }
                }
                return result;
            }
            catch { }
            
        }
        return result;

    }

    public BookPurchaseResponse PurchaseBooks(BookPurchaseInfo info)
    {
        BookPurchaseResponse responce = new BookPurchaseResponse();
        List<Book> books = GetAllBooks();
        float budget = info.budget;
        Dictionary<int, int> items = info.items;
        float totalPrice = 0.0f;

        foreach (var item in items)
        {
            int key = item.Key;
            int value = item.Value;
            if (key > books.Count || key <= 0)
            {
                throw new Exception("Input is invalid");
            }
            if (value > books[key - 1].stock)
            {
                responce.result = false;
                responce.response = "No enough stocks";
                return responce;
            }
            totalPrice = totalPrice + value * books[key - 1].price;
        }

        if (totalPrice > info.budget)
        {
            responce.response = "No enough money";
            responce.result = false;
            return responce;
        }

        responce.response = Convert.ToString(info.budget - totalPrice);
        responce.result = true;
        return responce;
    }
}
