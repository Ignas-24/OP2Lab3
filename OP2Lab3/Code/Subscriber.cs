using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace OP2Lab3
{
    public class Subscriber : IPrintTableGeneraliser, IWebTableGeneraliser, IWebTableHeader, IComparable<Subscriber>, IEquatable<Subscriber>
    {
        public string LastName { get; set; }
        public string Adress { get; set; }
        /// <summary>
        /// the month that the subscriber begins their subscribtion (1 through 12)
        /// </summary>
        public int StartMonth { get; set; }
        /// <summary>
        /// how many months did the subscriber subscribe for (subscribtion length can't exceed the end of the year)
        /// </summary>
        public int SubscribtionLength { get; set; }
        /// <summary>
        /// the publications id that the subscriber subscribed to
        /// </summary>
        public int PublicationId { get; set; }
        /// <summary>
        /// how many publications the subscriber subscribed for
        /// </summary>
        public int PublicationCount { get; set; }
        public Subscriber(string lastName, string Adress, int startMonth, int length, int publicationId, int publicatonCount)
        {
            this.LastName = lastName;
            this.Adress = Adress;
            this.StartMonth = startMonth;
            this.SubscribtionLength = length;
            this.PublicationId = publicationId;
            this.PublicationCount = publicatonCount;
        }
        public Subscriber() //used for headers
        {

        }

        //used for printing formatted tables
        public string Header => String.Format("|{0,-12}|{1,-25}|{2,-7}|{3,-5}|{4,-6}|{5,-8}|", "Pavardė", "Adresas", "Pradžia", "Trukmė", "Id", "Skaičius");

        public override string ToString()
        {
            return String.Format("|{0,-12}|{1,-25}|{2,7}|{3,5}|{4,6}|{5,8}|", LastName, Adress, StartMonth, SubscribtionLength, PublicationId, PublicationCount);
        }
        /// <summary>
        /// gets the values of the subscriber that will be displayed in a table
        /// </summary>
        /// <returns>IEnumerable that gives each value</returns>
        public IEnumerable<object> CellValues()
        {
            yield return LastName;
            yield return Adress;
            yield return StartMonth;
            yield return SubscribtionLength;
            yield return PublicationId;
            yield return PublicationCount;
        }
        /// <summary>
        /// gets the header for a web table
        /// </summary>
        public TableRow TableHeader
        {
            get
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = "Pavardė";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "Adresas";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "Pradžia";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "Trukmė";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "Id";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "Skaičius";
                row.Cells.Add(cell);

                return row;
            }
        }
        /// <summary>
        /// compares two subscribers by their last names
        /// </summary>
        /// <param name="other">the other subscriber that will be compared</param>
        /// <returns>1 if this subscriber's last name is greater than the other's, -1 if it is smaller, 0 if they are equal</returns>
        public int CompareTo(Subscriber other)
        {
            return this.LastName.CompareTo(other.LastName);
        }
        /// <summary>
        /// checks if the given subscriber has the same last name as this one
        /// </summary>
        /// <param name="other">the other subscriber that will be checked</param>
        /// <returns>true if the last names match, false otherwise</returns>
        public bool Equals(Subscriber other)
        {
            return this.LastName.Equals(other.LastName);
        }
    }
}