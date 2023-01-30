namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public class Queue<T> : IAbstractQueue<T>
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

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            var newNode = new Node(item);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;            
                }
                node.Next = newNode;
            }
            Count++;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();

            var oldHead = this.head;
            this.head = oldHead.Next;
            Count--;
            return oldHead.Element;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return this.head.Element;
        }

        public bool Contains(T item)
        {
            var node = this.head;
            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
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
                throw new InvalidOperationException("The Queue is empty");
            }
        }
    }
}