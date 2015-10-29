namespace _11.LinkedListImplementation
{
    public class LinkedList<T>
    {
        private Node head;

        public void AddNode(T data)
        {
            Node newNode = new Node();
            newNode.Next = this.head;
            newNode.Data = data;
            this.head = newNode;
        }

        public T GetFirstAdded()
        {
            T temp = default(T);

            Node current = this.head;
            while (current != null)
            {
                temp = current.Data;
                current = current.Next;
            }

            return temp;
        }

        private class Node
        {
            public Node Next { get; set; }

            public T Data { get; set; }
        }
    }
}