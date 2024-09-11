using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace OP2Lab3
{
    public class Publication : IComparable<Publication>, IEquatable<Publication>, IPrintTableGeneraliser, IWebTableGeneraliser, IWebTableHeader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        /// <summary>
        /// displays how many subscribers are subscribed to the publication each month (the first value represent January and so on)
        /// </summary>
        private int[] SubscribersByMonth;
        public Publication(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
            SubscribersByMonth = new int[12];
        }
        public Publication() //used for headers
        {
            SubscribersByMonth = new int[12];
        }
        /// <summary>
        /// adds the ammount of publications to the months that the given subscriber subscribed for
        /// </summary>
        /// <param name="subscriber">the subscriber whose subscribtion will be added</param>
        public void UpdateSubscribers(Subscriber subscriber)
        {
            for (int i = subscriber.StartMonth - 1; i < subscriber.StartMonth + subscriber.SubscribtionLength - 1; i++) //goes through the subscriber months
            {
                SubscribersByMonth[i] += subscriber.PublicationCount;
            }
        }
        /// <summary>
        /// how much the publication earns in a year from all of their subscribers
        /// </summary>
        public double YearlyEarnings
        {
            get
            {
                int subscribers = 0;
                for (int i = 0; i < 12; i++)
                {
                    subscribers += SubscribersByMonth[i];
                }
                return subscribers * Price;
            }
        }
        /// <summary>
        /// counts how much the publication earned the given month
        /// </summary>
        /// <param name="month">the month number for which income will be calculated (1 being January, 12 December)</param>
        /// <returns>the total money that the publications eanrs the given month</returns>
        public double MonthlyEarning(int month)
        {
            return SubscribersByMonth[month - 1] * Price;
        }
        public override string ToString()
        {
            return String.Format("|{0,6}|{1,-20}|{2,6}|{3,7:0.00}|", Id, Name, Price, YearlyEarnings);
        }
        /// <summary>
        /// compares two publications by their price and if they are equal by their name
        /// </summary>
        /// <param name="other">the other publication that will be compared</param>
        /// <returns>
        /// 1 if this publication is more expensive than the other, -1 if it is cheaper,
        /// if their price is euqal then it returns the comparison of their names
        /// </returns>
        public int CompareTo(Publication other)
        {
            int priceComparison = this.Price.CompareTo(other.Price);
            if (priceComparison != 0)
            {
                return priceComparison;
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
        }
        /// <summary>
        /// checks if the given publication has the same Id as this one
        /// </summary>
        /// <param name="other">the other publication that will be compared</param>
        /// <returns>true if the ids are the same, false otherwise</returns>
        public bool Equals(Publication other)
        {
            return this.Id.Equals(other.Id);
        }

        //used for tables
        public string Header => String.Format("|{0,-6}|{1,-20}|{2,-6}|{3,7}|", "Id", "Pavadinimas", "Kaina", "Pajamos");

        /// <summary>
        /// gets the values of the publication that will be displayed in a table
        /// </summary>
        /// <returns>IEnumerable that gives each value</returns>
        public IEnumerable<object> CellValues()
        {
            yield return Id;
            yield return Name;
            yield return Price;
            yield return YearlyEarnings;
        }
        /// <summary>
        /// used to display a header for the publication table
        /// </summary>
        public TableRow TableHeader
        {
            get
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = "Id";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "Pavadinimas";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "Kaina";
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "Pajamos";
                row.Cells.Add(cell);

                return row;
            }
        }
    }
}