namespace _11.LinkedListImplementation
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable
    {
        public LinkedList()
        {
            this.FirstElement = null;
            this.Count = 0;
            this.LastElement = null;
        }

        public ListItem<T> LastElement { get; set; }

        public ListItem<T> FirstElement { get; set; }

        public int Count { get; set; }

        public void Add(T value)
        {
            var nodeToAdd = new ListItem<T>(value);

            if (this.FirstElement == null)
            {
                this.FirstElement = nodeToAdd;
                this.LastElement = this.FirstElement;
                ++this.Count;
                return;
            }

            ListItem<T> newItem = this.FirstElement;
            while (newItem.NextItem != null)
            {
                newItem = newItem.NextItem;
            }

            newItem.NextItem = nodeToAdd;
            this.LastElement = newItem.NextItem;
            ++this.Count;
        }

        /// <summary>
        /// Search for value in the Linked List and removes the first occurance
        /// </summary>
        /// <param name="value">value to remove</param>
        public void Remove(T value)
        {
            var tempNode = this.FirstElement;

            if (tempNode.Value.Equals(value))
            {
                this.FirstElement = this.FirstElement.NextItem;
                --this.Count;
            }    
        }

        public T GetFirst()
        {
            return this.FirstElement.Value;
        }

        public T GetLast()
        {
            return this.LastElement.Value;
        }

        public ListItem<T> GetFirstNode()
        {
            return this.FirstElement;
        }

        public ListItem<T> GetLastNode()
        {
            return this.LastElement;
        }

        public bool Contains(T value)
        {
            var tempNode = this.FirstElement;

            while (tempNode != null)
            {
                if (tempNode.Value.Equals(value))
                {
                    return true;
                }

                tempNode = tempNode.NextItem;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> newItem = this.FirstElement;

            while (newItem != null)
            {
                yield return newItem.Value;
                newItem = newItem.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}