using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using WebApplication1.ServiceReference1;
using WebApplication1.ServiceReference1;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.ServiceClient sc1 = new ServiceReference1.ServiceClient();
            List<Book> books = new List<Book>();
            int index = 1;
            //Dictionary<int, Book> dict = new Dictionary<int, Book>();

            foreach (Book book in sc1.GetAllBooks())
            {
                books.Add(book);
            }

            /*int index = 1;
            for (int i = 0; i < books.Count; i++)
            {
                dict.Add(index, books[i]);
                index++;
            }*/

            foreach (Book book in books)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();
                TableCell cell6 = new TableCell();
                TableCell cell7 = new TableCell();

                cell1.Text = Convert.ToString(index);
                index++;
                cell2.Text = book.ID;
                cell3.Text = book.name;
                cell4.Text = book.author;
                cell5.Text = Convert.ToString(book.year);
                cell6.Text = '$' + Convert.ToString(book.price);
                cell7.Text = Convert.ToString(book.stock);

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                row.Cells.Add(cell6);
                row.Cells.Add(cell7);

                Table1.Rows.Add(row);

                Panel1.Controls.Clear();
                AddMoreItem(count);

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServiceClient sc1 = new ServiceReference1.ServiceClient();
            Boolean valid = true;
            string ID = TextBox1.Text;
            string name = TextBox2.Text;
            string author = TextBox3.Text;
            try {
                int year = int.Parse(TextBox4.Text);
                int price = int.Parse(TextBox5.Text);
                int stock = int.Parse(TextBox6.Text);

                List<Book> books = new List<Book>();
                foreach (Book book in sc1.GetAllBooks())
                {
                    books.Add(book);
                }
                foreach (Book book in books)
                {
                    if (book.ID.Equals(ID))
                    {
                        valid = false;
                        TextBox13.Text = "Duplicate IDs";
                    }
                }
                if (year <= 0)
                {
                    valid = false;
                    TextBox13.Text = "Year must be positive";
                }
                if (price <= 0)
                {
                    valid = false;
                    TextBox13.Text = "Price must be positive";
                }
                if (stock <= 0)
                {
                    valid = false;
                    TextBox13.Text = "Stock must be positive";
                }
                foreach (Book book in books)
                {
                    if (book.ID.Equals(ID))
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    sc1.AddBook(ID, name, author, year, price, stock);
                    List<Book> newBooks = new List<Book>();
                    Table1.Rows.Clear();

                    int index = 1;


                    foreach (Book book in sc1.GetAllBooks())
                    {
                        newBooks.Add(book);
                    }

                    foreach (Book book in newBooks)
                    {
                        TableRow row = new TableRow();
                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        TableCell cell3 = new TableCell();
                        TableCell cell4 = new TableCell();
                        TableCell cell5 = new TableCell();
                        TableCell cell6 = new TableCell();
                        TableCell cell7 = new TableCell();

                        cell1.Text = Convert.ToString(index);
                        index++;
                        cell2.Text = book.ID;
                        cell3.Text = book.name;
                        cell4.Text = book.author;
                        cell5.Text = Convert.ToString(book.year);
                        cell6.Text = '$' + Convert.ToString(book.price);
                        cell7.Text = Convert.ToString(book.stock);

                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        row.Cells.Add(cell3);
                        row.Cells.Add(cell4);
                        row.Cells.Add(cell5);
                        row.Cells.Add(cell6);
                        row.Cells.Add(cell7);

                        Table1.Rows.Add(row);
                    }
                }
            } catch
            {
                TextBox13.Text = "invalid input";
            }
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServiceClient sc1 = new ServiceReference1.ServiceClient();
            string choice = DropDownList1.Text;
            string input = TextBox7.Text;

            
                /*int number = int.Parse(input);
                if (number <= 0)
                {

                    TextBox13.Text = "Input must be positive";
                }*/
                sc1.DeleteBook(choice, input);
                List<Book> newBooks = new List<Book>();
                Table1.Rows.Clear();

                int index = 1;


                foreach (Book book in sc1.GetAllBooks())
                {
                    newBooks.Add(book);
                }

                foreach (Book book in newBooks)
                {
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    TableCell cell5 = new TableCell();
                    TableCell cell6 = new TableCell();
                    TableCell cell7 = new TableCell();

                    cell1.Text = Convert.ToString(index);
                    index++;
                    cell2.Text = book.ID;
                    cell3.Text = book.name;
                    cell4.Text = book.author;
                    cell5.Text = Convert.ToString(book.year);
                    cell6.Text = '$' + Convert.ToString(book.price);
                    cell7.Text = Convert.ToString(book.stock);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    row.Cells.Add(cell6);
                    row.Cells.Add(cell7);

                    Table1.Rows.Add(row);
                }
            


            //sc1.DeleteBook(choice, input);


            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int index = 1;
            List<Book> result = new List<Book>();
            ServiceReference1.ServiceClient sc1 = new ServiceReference1.ServiceClient();
            string choice = DropDownList2.Text;
            string input = TextBox8.Text;

            
                
                foreach (Book book in sc1.SearchBook(choice, input))
                {
                    result.Add(book);
                }

                foreach (Book book in result)
                {
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    TableCell cell5 = new TableCell();
                    TableCell cell6 = new TableCell();
                    TableCell cell7 = new TableCell();

                    cell1.Text = Convert.ToString(index);
                    index++;
                    cell2.Text = book.ID;
                    cell3.Text = book.name;
                    cell4.Text = book.author;
                    cell5.Text = Convert.ToString(book.year);
                    cell6.Text = '$' + Convert.ToString(book.price);
                    cell7.Text = Convert.ToString(book.stock);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);
                    row.Cells.Add(cell6);
                    row.Cells.Add(cell7);

                    Table2.Rows.Add(row);
                }
            
            

            
        }


        protected void AddMoreItem(int number)
        {
            for (int i = 0; i < number; i++)
            {

                Panel1.Controls.Add(new LiteralControl("<br />"));
                Label label = new Label();
                label.Text = "BookNumber:";
				
				
                Panel1.Controls.Add(label);
                TextBox tb = new TextBox();
                tb.ID = "book" + i;
                Panel1.Controls.Add(tb);
                Label labelnew = new Label();
                labelnew.Text = "Amount:";
				
				
                Panel1.Controls.Add(labelnew);
                TextBox tbnew = new TextBox();
                tbnew.ID = "amount" + i;
                Panel1.Controls.Add(tbnew);
                LiteralControl linebreak = new LiteralControl("<br />");
                Panel1.Controls.Add(linebreak);
            }
        }


        static int count = 1;
        protected void Button4_Click(object sender, EventArgs e)
        {
            count++;
            Panel1.Controls.Clear();
            AddMoreItem(count);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServiceClient sc1 = new ServiceReference1.ServiceClient();
            BookPurchaseInfo info = new BookPurchaseInfo();
            BookPurchaseResponse responce = new BookPurchaseResponse();
            Boolean valid = true;

            try
            {
                float budget = float.Parse(TextBox9.Text);
                if (budget <= 0)
                {
                    TextBox13.Text = "budget must be positive";
                    return;
                }
                info.budget = budget;
                info.items = new Dictionary<int, int>();
                //info.items.Add(int.Parse(TextBox10.Text), int.Parse(TextBox11.Text));
                for (int j = 0; j < count; j++)
                {
                    TextBox tb1 = (TextBox)Panel1.FindControl("book" + j);
                    TextBox tb2 = (TextBox)Panel1.FindControl("amount" + j);
                    try
                    {
                        int key = int.Parse(tb1.Text);
                        int value = int.Parse(tb2.Text);
                        info.items.Add(key, value);
                    }
                    catch
                    {
                        TextBox13.Text = "Book number or amount is invalid";
                    }

                }

                responce.response = sc1.PurchaseBooks(info.budget, info.items, out responce.result);
                TextBox12.Text = responce.response;
            }
            catch
            {
                TextBox13.Text = "budget is invalid";
            }




        }


    }

}