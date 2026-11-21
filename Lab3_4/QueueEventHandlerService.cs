using System;

namespace Lab3_4
{
    public class QueueEventHandlerService
    {
        private readonly string _handlerName;

        public QueueEventHandlerService(string handlerName)
        {
            _handlerName = handlerName;
        }

        public void OnQueueClearedHandler(object sender, QueueEventArgs e)
        {
            string senderType = sender != null ? sender.GetType().Name : "Unknown";
            Console.WriteLine($"[{_handlerName}] Event received from {senderType} at {e.Timestamp:HH:mm:ss}: {e.Message} (Items affected: {e.RemovedItemsCount})");
        }
    }
}