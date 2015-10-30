namespace _12.Stack
{
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable
    {
        private int capacity = 16;
        private T[] items;

        public Stack()
        {
            this.items = new T[this.capacity];
            this.Count = 0;
        }

        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public int Count { get; set; }

        public void Push(T value)
        {
            if (this.Count + 1 > this.Capacity)
            {
                T[] currentItems = this.items;

                this.Capacity *= 2;
                this.items = new T[this.Capacity];

                for (var i = 0; i < currentItems.Length; i++)
                {
                    this.items[i] = currentItems[i];
                }

                this.Count = currentItems.Length;
                this.items[this.Count] = value;
                ++this.Count;
            }
            else
            {
                this.items[this.Count] = value;
                ++this.Count;
            }
        }

        public T Pop()
        {
            --this.Count;
            return this.items[this.Count];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
