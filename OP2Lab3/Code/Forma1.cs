using System;
using System.Web.UI.WebControls;

namespace OP2Lab3
{
    public partial class Forma1 : System.Web.UI.Page
    {
        /// <summary>
        /// displays the customlinkedlist items in a table
        /// </summary>
        /// <typeparam name="T">the type of the data in the list that will be displayed</typeparam>
        /// <param name="items">data of type T in a list</param>
        /// <param name="table">the table in which the data will be displayed</param>
        public void DisplayItemsInTable<T>(CustomLinkedList<T> items, Table table) where T : IWebTableGeneraliser, IWebTableHeader, IComparable<T>, IEquatable<T>, new()
        {
            TableRow tableRow = new T().TableHeader;
            table.Rows.Add(tableRow);

            foreach (T item in items)
            {
                tableRow = new TableRow();
                foreach (var cellContent in item.CellValues())
                {
                    TableCell cell = new TableCell();
                    cell.Text = cellContent.ToString();
                    tableRow.Cells.Add(cell);
                }
                table.Rows.Add(tableRow);
            }
        }


        /// <summary>
        /// fills up the labels in the page
        /// </summary>
        public void DisplayDataLabels()
        {
            Label2.Text = "Visi prenumeratoriai";
            Label3.Text = "Daugiausiai pajamų kiekvieną mėnesį turintys leidiniai";
            Label4.Text = "Leidiniai kurių pajamos nesiekia vidurkio";
        }
        /// <summary>
        /// displays months and one publication name and monthly income for that month inside table3 
        /// </summary>
        /// <param name="publications">linked list that should have 12 publications in it</param>
        public void DisplayHigestEarnerPublications(CustomLinkedList<Publication> publications)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            TableRow tableRow = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = "Mėnesis";
            tableRow.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = "Leidinys";
            tableRow.Cells.Add(cell);
            cell = new TableCell();
            cell.Text = "Mėnesio pajamos";
            tableRow.Cells.Add(cell);
            Table3.Rows.Add(tableRow);
            int i = 0;

            foreach (Publication publication in publications)
            {
                if (publication != null)
                {
                    tableRow = new TableRow();
                    cell = new TableCell();
                    cell.Text = months[i];
                    tableRow.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = publication.Name;
                    tableRow.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = publication.MonthlyEarning(i + 1).ToString();
                    cell.HorizontalAlign = HorizontalAlign.Right;
                    tableRow.Cells.Add(cell);
                    Table3.Rows.Add(tableRow);
                }
                else
                {
                    tableRow = new TableRow();
                    cell = new TableCell();
                    cell.Text = months[i];
                    tableRow.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = "Šį mėnesį leidinių nebuvo nupirkta";
                    tableRow.Cells.Add(cell);
                    Table3.Rows.Add(tableRow);
                }
                i++;
            }

        }
        /// <summary>
        /// fills up the dropdown list with all the months
        /// </summary>
        public void FillUpMonthDropDown()
        {
            DropDownList2.Items.Add(new ListItem("January", "1"));
            DropDownList2.Items.Add(new ListItem("February", "2"));
            DropDownList2.Items.Add(new ListItem("March", "3"));
            DropDownList2.Items.Add(new ListItem("April", "4"));
            DropDownList2.Items.Add(new ListItem("May", "5"));
            DropDownList2.Items.Add(new ListItem("June", "6"));
            DropDownList2.Items.Add(new ListItem("July", "7"));
            DropDownList2.Items.Add(new ListItem("August", "8"));
            DropDownList2.Items.Add(new ListItem("September", "9"));
            DropDownList2.Items.Add(new ListItem("October", "10"));
            DropDownList2.Items.Add(new ListItem("November", "11"));
            DropDownList2.Items.Add(new ListItem("December", "12"));
        }
        /// <summary>
        /// fills up the dropdown list with the names of the given publications
        /// </summary>
        /// <param name="publications">the publications whose names will be put in the dropdown</param>
        public void FillUpPublicationDropDown(CustomLinkedList<Publication> publications)
        {
            foreach (Publication publication in publications)
                DropDownList1.Items.Add(new ListItem(publication.Name));
        }
    }
}
