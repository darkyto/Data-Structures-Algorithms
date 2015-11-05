using System.Collections;

namespace HashSet
{
    using System;
    using System.Collections.Generic;
    using HashTable;

    public class HashSetCustom<T> : IEnumerable<T>
    {
        private readonly HashTableCustom<int, T> _elements;

        public HashSetCustom()
        {
            this._elements = new HashTableCustom<int, T>();
        }

        public int Count
        {
            get
            {
                return this._elements.Count;
            }
        }

        public void Add(T element)
        {
            this._elements.Add(element.GetHashCode(), element);
        }

        public void Remove(T element)
        {
            this._elements.Remove(element.GetHashCode());
        }

        public void Clear()
        {
            this._elements.Clear();
        }

        public T Find(T element)
        {
            T elementToReturn;

            if (this._elements.Find(element.GetHashCode(), out elementToReturn))
            {
                return elementToReturn;
            }

            return default(T);
        }

        public HashSetCustom<T> IntersectsWith(HashSetCustom<T> other)
        {
            var result = new HashSetCustom<T>();

            foreach (var myNode in this)
            {
                foreach (var otherNode in other)
                {
                    if (myNode.Equals(otherNode))
                    {
                        result.Add(myNode);
                    }
                }
            }

            return result;
        }

        public HashSetCustom<T> Union(HashSetCustom<T> other)
        {
            var result = new HashSetCustom<T>();

            foreach (var myNode in this)
            {
                result.Add(myNode);
            }

            foreach (var otherNode in other)
            {
                result.Add(otherNode);
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this._elements)
            {
                yield return pair.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}
