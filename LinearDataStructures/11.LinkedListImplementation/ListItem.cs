namespace _11.LinkedListImplementation
{
    /// <summary>
    /// Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>).
    /// </summary>
    /// <typeparam name="T"> item value</typeparam>
    public class ListItem<T>
    {
        public ListItem(T value, ListItem<T> nextItem = null)
        {
            this.Value = value;
            this.NextItem = nextItem;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }

        public ListItem<T> GetNextNode()
        {
            return this.NextItem;
        }
    }
}
