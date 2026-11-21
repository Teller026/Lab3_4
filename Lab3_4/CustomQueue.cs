using System;
using System.Collections.Generic;

namespace Lab3_4
{
    public class CustomQueue<T>
    {
        private readonly Queue<T> _items;

        public event EventHandler<QueueEventArgs> QueueCleared;

        public int Count => _items.Count;

        public CustomQueue()
        {
            _items = new Queue<T>();
        }

        public CustomQueue(IEnumerable<T> collection)
        {
            _items = new Queue<T>(collection);
        }

        public void Enqueue(T item)
        {
            _items.Enqueue(item);
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = _items.Dequeue();
            if (_items.Count == 0)
            {
                OnQueueCleared(new QueueEventArgs("Queue became empty after removing the last element.", 1));
            }
            return item;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
            return _items.Peek();
        }

        public void Clear()
        {
            int countBeforeClear = _items.Count;
            _items.Clear();
            OnQueueCleared(new QueueEventArgs("Queue was explicitly cleared.", countBeforeClear));
        }

        protected virtual void OnQueueCleared(QueueEventArgs e)
        {
            QueueCleared?.Invoke(this, e);
        }

        public void PrintQueue()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }
            Console.WriteLine("Queue elements: " + string.Join(", ", _items));
        }
    }
}