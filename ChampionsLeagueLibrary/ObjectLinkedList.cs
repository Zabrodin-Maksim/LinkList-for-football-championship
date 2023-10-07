using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeagueLibrary
{
    public class ObjectLinkedList : ICollection, IEnumerable, IList
    {
        private Node head;
        private Node tail;
        private int count;

        private class Node
        {
            public object data { get; set; }
            public Node prev { get; set; }
            public Node next { get; set; }

            public Node(object data, Node prev, Node next)
            {
                this.data = data;
                this.prev = prev;
                this.next = next;
            }
        }

        public ObjectLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public object this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    Node current = head;
                    for (int i = 0; i < index; i++)
                    {
                        current = current.next;
                    }
                    return current.data;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index < count)
                {
                    Node current = head;
                    for (int i = 0; i < index; i++)
                    {
                        current = current.next;
                    }
                    current.data = value;
                }
            }
        }

        public int Add(object item)
        {
            Node newNode = new Node(item, null, null);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }

            count++;
            return count;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(object item)
        {
            Node current = head;
            while (current != null)
            {
                if (current.data.Equals(item))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                return;
            }
            if (index < 0 || index >= array.Length)
            {
                return;
            }
            if (array.Length - index < count)
            {
                return;
            }
            Node current = head;
            while (current != null)
            {
                array.SetValue(current.data, index);
                index++;
                current = current.next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }

        public int IndexOf(object item)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.data.Equals(item))
                {
                    return index;
                }
                index++;
                current = current.next;
            }
            return -1;
        }


        public void Insert(int index, object item)
        {
            if (index < 0 || index > Count) return;

            var newNode = new Node(item, null,null);

            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else if (index == 0)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            else if (index == Count)
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            else
            {
                var currentNode = head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.next;
                }

                newNode.next = currentNode.next;
                currentNode.next.prev = newNode;
                currentNode.next = newNode;
                newNode.prev = currentNode;
            }

            Count++;
        }

        public void Remove(object item)
        {
            var currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.data.Equals(item))
                {
                    if (currentNode == head)
                    {
                        head = currentNode.next;
                        if (head != null)
                        {
                            head.prev = null;
                        }
                        else
                        {
                            tail = null;
                        }
                    }
                    else if (currentNode == tail)
                    {
                        tail = currentNode.prev;
                        tail.next = null;
                    }
                    else
                    {
                        currentNode.prev.next = currentNode.next;
                        currentNode.next.prev = currentNode.prev;
                    }

                    Count--;
                }

                currentNode = currentNode.next;
            }

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) return;

            if (Count == 1)
            {
                head = null;
                tail = null;
            }
            else if (index == 0)
            {
                head = head.next;
                head.prev = null;
            }
            else if (index == Count - 1)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                var currentNode = head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.next;
                }

                currentNode.next = currentNode.next.next;
                currentNode.next.prev = currentNode;
            }

            Count--;
        }
    }
}
