using System;
using System.Collections;
using System.Collections.Generic;

namespace net1
{
    class clientGroup<T> : ICollection<T> where T : Client, IClonable
    {
        public delegate List<T> Del(List<T> newList);

        public Del del;

        public clientGroup(Del newDel)
        {
            del = newDel;
        }

        private List<T> clients = new List<T>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return clientEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return clientEnumerator();
        }

        public void Sort()
        {
            clients = del(clients);
        }

        public bool Contains(T item)
        {
            bool found = false;

            foreach (T t in clients)
            {
                if (t.Equals(item))
                {
                    found = true;
                }
            }

            return found;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {

            clients.Add(item);
        }

        public void Clear()
        {
            clients.Clear();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < clients.Count; i++)
            {
                array[i + arrayIndex] = clients[i];
            }
        }

        public int Count
        {
            get
            {
                return clients.Count;
            }
        }

        public T this[int index]
        {
            get { return (T)clients[index]; }
            set { clients[index] = value; }
        }

        public IEnumerator<T> clientEnumerator()
        {
            for (int i = 0; i < clients.Count; i++)
            {
                yield return clients[i];
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}