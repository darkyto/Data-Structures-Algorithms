namespace _13.Queue
{
    using System;
    using System.Collections.Generic;

    public class Queue<T>
    {
        private LinkedList<T> items;

        public Queue()
        {
            this.items = new LinkedList<T>();
        }

        public void Enqueue(T value)
        {
            if (this.items.First == null)
            {
                this.items.AddFirst(value);
                return;
            }

            this.items.AddBefore(this.items.First, value);
        }

        public T Dequeue()
        {
            if (this.items.Count > 0)
            {
                var value = this.items.Last.Value;
                this.items.RemoveLast();

                return value;
            }
            else
            {
                throw new ArgumentNullException("Nothing to pop from queue");
            }
        }
    }
}
