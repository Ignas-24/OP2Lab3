using System;
using System.IO;

namespace OP2Lab3
{
    public static class InOutUtils
    {
        /// <summary>
        /// reads publications from the given file and puts them into a linked list
        /// </summary>
        /// <param name="file">the stream of the data</param>
        /// <returns>a custom linked list with the publications</returns>
        public static CustomLinkedList<Publication> ReadPublications(Stream file)
        {
            CustomLinkedList<Publication> publications = new CustomLinkedList<Publication>();
            string line;
            using (StreamReader sr = new StreamReader(file))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    int id = int.Parse(values[0]);
                    string name = values[1];
                    double price = double.Parse(values[2]);
                    Publication publication = new Publication(id, name, price);
                    publications.Append(publication);
                }
            }
            return publications;
        }
        /// <summary>
        /// reads the subscribers in the file and puts them into a linked list
        /// </summary>
        /// <param name="file">the stream of the data</param>
        /// <returns>a custom linked list with the read subscribers</returns>
        public static CustomLinkedList<Subscriber> ReadSubscribers(Stream file)
        {
            CustomLinkedList<Subscriber> subscribers = new CustomLinkedList<Subscriber>();
            string line;
            using (StreamReader sr = new StreamReader(file))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string name = values[0];
                    string adress = values[1];
                    int startMonth = int.Parse(values[2]);
                    int duration = int.Parse(values[3]);
                    int publicationID = int.Parse(values[4]);
                    int ammount = int.Parse(values[5]);
                    Subscriber sub = new Subscriber(name, adress, startMonth, duration, publicationID, ammount);
                    subscribers.Append(sub);
                }
            }
            return subscribers;
        }
        /// <summary>
        /// writes the content of the linked list to the file as a formatted table
        /// </summary>
        /// <typeparam name="T">the type of data in the list</typeparam>
        /// <param name="items">the data of type T that will be displayed</param>
        /// <param name="filename">the filepath of where the table will be written</param>
        /// <param name="title">a title of the table that will be displayed above</param>
        public static void WriteToFile<T>(CustomLinkedList<T> items, string filename, string title) where T : IComparable<T>, IEquatable<T>, IPrintTableGeneraliser, new()
        {
            string header = new T().Header;

            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(title);
                sw.WriteLine("+" + new string('-', header.Length - 2) + "+");
                sw.WriteLine(header);
                sw.WriteLine("+" + new string('-', header.Length - 2) + "+");
                foreach (T item in items)
                {
                    sw.WriteLine(item.ToString());
                }
                sw.WriteLine("+" + new string('-', header.Length - 2) + "+");
                sw.WriteLine();
            }
        }
        /// <summary>
        /// prints the publication names and monthly incomes next to the months in a table
        /// </summary>
        /// <param name="publications">a list of 12 publications that will be printed</param>
        /// <param name="filename">the filepath where the table will be appended to</param>
        /// <param name="header">the name of the table that will be printed above it</param>
        public static void PrintHighestMonthlyEarnears(CustomLinkedList<Publication> publications, string filename, string header)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int lineLength = 44;
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(header);
                sw.WriteLine("+" + new string('-', lineLength) + "+");
                sw.WriteLine(String.Format("|{0,-10}|{1,-25}|{2,-7}|", "Mėnesis", "Leidinys", "Pajamos"));
                sw.WriteLine("+" + new string('-', lineLength) + "+");
                int i = 0;
                foreach (Publication publication in publications)
                {
                    if (publication != null)
                    {
                        sw.WriteLine(String.Format("|{0,-10}|{1,-25}|{2,-7}|", months[i], publication.Name, publication.MonthlyEarning(i + 1)));
                    }
                    else
                    {
                        sw.WriteLine(String.Format("|{0,-10}|{1,-33}|", months[i], "Šį mėnęsį leidinių nenupirkta"));
                    }
                    i++;
                }
                sw.WriteLine("+" + new string('-', lineLength) + "+" + "\n");
            }
        }
    }
}
