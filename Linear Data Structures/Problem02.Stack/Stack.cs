namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
                this.Next = null;
            }
        }

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            var newNode = new Node(item, this.top);

            this.top = newNode;
            this.Count++;
        }

        public T Pop()
        {
            EnsureNotEmpty();
            var oldTop = this.top;
            this.top = oldTop.Next;
            Count--;

            return oldTop.Element;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return this.top.Element;
        }

        public bool Contains(T item)
        {
            var current = this.top;

            while (current != null)
            {
                if (current.Element.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.top;

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
            if (this.top == null)
            {
                throw new InvalidOperationException("The stack is empty");
            }
        }
    }
}