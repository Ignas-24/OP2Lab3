using System;
using System.Collections;

namespace OP2Lab3
{
    public class CustomLinkedList<T> : IEnumerable where T : IComparable<T>, IEquatable<T>
    {
        private class Node
        {
            public Node Next;
            public T Data;
            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
        private Node head; // first element
        private Node tail; // last element
        /// <summary>
        /// the total number of elements in the list
        /// </summary>
        public int Count { get; private set; }
        public CustomLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// add an element to the end of the list
        /// </summary>
        /// <param name="data">the data that will be added as a node to the list</param>
        public void Append(T data)
        {
            Node node = new Node(data, null);
            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            Count++;
        }
        /// <summary>
        /// returns an enumerator that iterates through the list
        /// </summary>
        /// <returns>an enumerator of the list</returns>
        public IEnumerator GetEnumerator()
        {
            Node curr = head;
            while (curr != null)
            {
                yield return curr.Data;
                curr = curr.Next;
            }
        }
        /// <summary>
        /// gets the first element in the list
        /// </summary>
        /// <returns>the first element</returns>
        public T GetFirst()
        {
            if (Count == 0) return default(T);
            return head.Data;
        }
        /// <summary>
        /// sorts the list in ascending order
        /// </summary>
        public void Sort()
        {
            if (Count < 2) return;
            bool flag = true;
            while (flag)
            {
                flag = false;
                Node current = head;
                while (current.Next != null)
                {
                    if ((current.Data != null && current.Next.Data != null) && (current.Data.CompareTo(current.Next.Data) > 0))
                    {
                        flag = true;
                        (current.Next.Data, current.Data) = (current.Data, current.Next.Data);
                    }
                    current = current.Next;
                }
            }
        }
    }
}