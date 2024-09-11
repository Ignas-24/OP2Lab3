namespace OP2Lab3
{
    public static class TaskUtils
    {
        /// <summary>
        /// finds the subscribers that have subscriber to the given publication and are subscribed in the given month
        /// </summary>
        /// <param name="publicationId">the id of the publication of which subscribers will be searched</param>
        /// <param name="month">the month in which the subscribers will have to be subscribed in</param>
        /// <param name="subscribers">the subscribers that will be seached</param>
        /// <returns>a custom linked list of only the subscribers that are subscribed to the publication</returns>
        public static CustomLinkedList<Subscriber> FindSubscribersByPublicationId(int publicationId, int month, CustomLinkedList<Subscriber> subscribers)
        {
            CustomLinkedList<Subscriber> chosenSubscribers = new CustomLinkedList<Subscriber>();

            foreach (Subscriber subscriber in subscribers)
            {
                if (subscriber.PublicationId == publicationId && month >= subscriber.StartMonth && month <= subscriber.StartMonth + subscriber.SubscribtionLength)
                    chosenSubscribers.Append(subscriber);
            }
            if (chosenSubscribers.Count == 0) { return null; }
            return chosenSubscribers;
        }

        /// <summary>
        /// the average income of all the publications
        /// </summary>
        /// <param name="publications">the publications of whose incomes will be summed</param>
        /// <returns>the average yearly income</returns>
        public static double Average(CustomLinkedList<Publication> publications)
        {
            double sum = 0;
            foreach (Publication publication in publications)
            {
                sum += publication.YearlyEarnings;
            }
            return sum / publications.Count;
        }

        /// <summary>
        /// adds the months in which subscribers are subscribed to the publications
        /// </summary>
        /// <param name="subscribers">the subscribers of whose publications will be added</param>
        /// <param name="publications">the publications that will be updated</param>
        public static void AddSubscribersToPublications(CustomLinkedList<Subscriber> subscribers, CustomLinkedList<Publication> publications)
        {
            foreach (Subscriber subscriber in subscribers)
            {
                if (subscriber != null)
                {
                    Publication publication = FindPublicationById(subscriber.PublicationId, publications);
                    if (publication != null)
                    {
                        publication.UpdateSubscribers(subscriber);
                    }
                }
            }
        }

        /// <summary>
        /// finds the node that has the publication with the given id
        /// </summary>
        /// <param name="id">the publication id that will be looked for</param>
        /// <returns>Publication that was found, null if it wasn't found</returns>
        private static Publication FindPublicationById(int id, CustomLinkedList<Publication> publications)
        {
            foreach (Publication publication in publications)
            {
                if (publication.Id == id)
                    return publication;
            }
            return null;
        }

        /// <summary>
        /// Finds the highest earning publication every month and adds the to the list
        /// </summary>
        /// <returns>a 12 long linked list where each position represents the highest earning publication for that month</returns>
        public static CustomLinkedList<Publication> FindHighestEarnersEveryMonth(CustomLinkedList<Publication> publications)
        {
            if (publications is null || publications.Count == 0) return null;
            CustomLinkedList<Publication> highestPublications = new CustomLinkedList<Publication>();
            for (int i = 1; i < 13; i++)
            {
                Publication highest = null;
                foreach (Publication publication in publications)
                {
                    if (highest != null)
                    {
                        if (publication.MonthlyEarning(i) > highest.MonthlyEarning(i))
                            highest = publication;
                    }
                    else
                    {
                        highest = publication;
                    }
                }
                if (highest.MonthlyEarning(i) > 0)
                {
                    highestPublications.Append(highest);
                }
                else
                {
                    highestPublications.Append(null);
                }
            }
            return highestPublications;
        }

        /// <summary>
        /// finds the publications that earn lower than the given ammount
        /// </summary>
        /// <param name="average">the publications with earnings lower than this will be added</param>
        /// <returns>a linked list that contains publications with yearly incomes below the given number</returns>
        public static CustomLinkedList<Publication> FindBelowAveragePublications(double average, CustomLinkedList<Publication> publications)
        {
            CustomLinkedList<Publication> belowAverage = new CustomLinkedList<Publication>();

            foreach (Publication publication in publications)
            {
                if (publication.YearlyEarnings < average)
                    belowAverage.Append(publication);
            }
            return belowAverage;
        }

        /// <summary>
        /// finds the first publication with the given name
        /// </summary>
        /// <param name="name">the name that will be searched for</param>
        /// <returns>the publication if it was found, null otherwise</returns>
        public static Publication FindPublicationByName(string name, CustomLinkedList<Publication> publications)
        {
            foreach (Publication publication in publications)
            {
                if (publication.Name.CompareTo(name) == 0)
                    return publication;
            }
            return null;
        }
    }
}