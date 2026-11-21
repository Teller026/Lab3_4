using System;

namespace Lab3_4
{
    public class QueueEventArgs : EventArgs
    {
        public string Message { get; }
        public int RemovedItemsCount { get; }
        public DateTime Timestamp { get; }

        public QueueEventArgs(string message, int removedItemsCount)
        {
            Message = message;
            RemovedItemsCount = removedItemsCount;
            Timestamp = DateTime.Now;
        }
    }
}