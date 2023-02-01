namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public Node(T element)
            {
                Element = element;
                Next = null;
            }
        }

        public int Count { get; private set; }

        private Node head;

        public void AddFirst(T item)
        {
            var newNode = new Node(item, this.head);
            this.head = newNode;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var currentNode = this.head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }
            this.Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();
            return this.head.Element;
        }

        public T GetLast()
        {
            EnsureNotEmpty();
            var currentNode = this.head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Element;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();
            var removedNode = this.head;
            this.head = this.head.Next;
            this.Count--;

            return removedNode.Element;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();
            var result = this.head;
            if (this.Count == 1)
            {
                this.head = null;
            }
            else if (this.Count == 2)
            {
                result = this.head.Next;
                this.head.Next = null;
            }
            else
            {
                var currentNode = this.head;
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                result = currentNode.Next;
                currentNode.Next = null;
            }
            this.Count--;
            return result.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The list is empty!");
            }
        }
    }
}