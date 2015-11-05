namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HashTableCustom<TK, TV> : IEnumerable<KeyValuePair<TK, TV>>
    {
        private const int CAPACITY = 8;
        private const double FIXEDPERCENTS = 0.75;

        private LinkedList<KeyValuePair<TK, TV>>[] elements;
        private ICollection<TK> keys;
        private int elementsCounter;

        public HashTableCustom(int capacity)
        {
            this.elements = new LinkedList<KeyValuePair<TK, TV>>[capacity];
            this.elementsCounter = 0;
            this.Count = 0;
            this.keys = new HashSet<TK>();
        }

        public HashTableCustom()
            : this(CAPACITY)
        {
        }

        public int Count { get; private set; }

        public ICollection<TK> Keys
        {
            get
            {
                return this.keys;
            }
        }

        public TV this[TK key]
        {
            get
            {
                TV value = default(TV);

                if (!this.Find(key, out value))
                {
                    throw new KeyNotFoundException("No such key can be found.");
                }

                return value;
            }

            set
            {
                this.Add(key, value);
            }
        }

        public void Add(TK key, TV value)
        {
            this.ResizeTable();

            this.keys.Add(key);

            var pairToAdd = new KeyValuePair<TK, TV>(key, value);
            var position = this.GetPosition(key);

            if (this.elements[position] == null)
            {
                this.elements[position] = new LinkedList<KeyValuePair<TK, TV>>();
                this.elements[position].AddFirst(pairToAdd);

                this.Count++;
            }
            else
            {
                this.Remove(key);

                if (this.elements[position].Count == 0)
                {
                    this.Count++;
                }

                this.elements[position].AddLast(pairToAdd);
            }

            this.elementsCounter++;
        }

        public void Remove(TK key)
        {
            var position = this.GetPosition(key);
            TV valueToRemove = default(TV);

            if (this.Find(key, out valueToRemove))
            {
                var pairToRemove = this.elements[position].First(x => x.Key.Equals(key));
                this.elements[position].Remove(pairToRemove);
                this.elementsCounter--;
                this.keys.Remove(key);

                if (this.elements[position].Count == 0)
                {
                    this.Count--;
                }
            }
        }

        public void Clear()
        {
            this.elements = new LinkedList<KeyValuePair<TK, TV>>[this.elements.Length];
            this.keys = new HashSet<TK>();
            this.Count = 0;
            this.elementsCounter = 0;
        }

        public bool Find(TK key, out TV value)
        {
            int position = this.GetPosition(key);
            if (this.elements[position] != null && this.elements[position].Count != 0)
            {
                foreach (var pair in this.elements[position])
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        return true;
                    }
                }
            }

            value = default(TV);
            return false;
        }

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
        {
            foreach (var list in this.elements)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var pair in this)
            {
                sb.AppendFormat($"TKey: {pair.Key}; TValue: {pair.Value}");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private int GetPosition(TK key)
        {
            return Math.Abs(key.GetHashCode() % this.elements.Length);
        }

        private void ResizeTable()
        {
            if (this.elementsCounter >= this.elements.Length * FIXEDPERCENTS)
            {
                var newCustomHashTable = new HashTableCustom<TK, TV>(this.elements.Length * 2);

                foreach (var pair in this)
                {
                    newCustomHashTable.Add(pair.Key, pair.Value);
                }

                this.elements = newCustomHashTable.elements;
            }
        }
    }
}