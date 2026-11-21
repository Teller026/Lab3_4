using System;
using System.Linq;

namespace Lab3_4
{
    public delegate bool ContainsLettersDelegate(string input);

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PART 1: DELEGATES, ANONYMOUS METHOD & LAMBDA EXPRESSION ===");

            ContainsLettersDelegate anonymousChecker = delegate (string text)
            {
                if (string.IsNullOrEmpty(text)) return false;
                foreach (char c in text)
                {
                    if (char.IsLetter(c)) return true;
                }
                return false;
            };

            ContainsLettersDelegate lambdaChecker = text => !string.IsNullOrEmpty(text) && text.Any(char.IsLetter);

            string sample1 = "1234567890!@#";
            string sample2 = "12345a6789";

            Console.WriteLine($"String \"{sample1}\" contains letters (Anonymous method): {anonymousChecker(sample1)}");
            Console.WriteLine($"String \"{sample1}\" contains letters (Lambda expression): {lambdaChecker(sample1)}");
            Console.WriteLine($"String \"{sample2}\" contains letters (Anonymous method): {anonymousChecker(sample2)}");
            Console.WriteLine($"String \"{sample2}\" contains letters (Lambda expression): {lambdaChecker(sample2)}");

            Console.WriteLine("\n=== PART 2: CUSTOM QUEUE & EVENT HANDLING ===");

            CustomQueue<string> taskQueue = new CustomQueue<string>();
            QueueEventHandlerService consoleLogger = new QueueEventHandlerService("ConsoleLogger");
            QueueEventHandlerService auditMonitor = new QueueEventHandlerService("AuditMonitor");

            taskQueue.QueueCleared += consoleLogger.OnQueueClearedHandler;
            taskQueue.QueueCleared += auditMonitor.OnQueueClearedHandler;

            taskQueue.Enqueue("Task 1");
            taskQueue.Enqueue("Task 2");
            taskQueue.Enqueue("Task 3");
            taskQueue.PrintQueue();

            Console.WriteLine($"Dequeued: {taskQueue.Dequeue()}");
            Console.WriteLine($"Peek next: {taskQueue.Peek()}");
            taskQueue.PrintQueue();

            Console.WriteLine("\nCalling Clear() on queue:");
            taskQueue.Clear();

            Console.WriteLine("\nUnsubscribing AuditMonitor and testing automatic clear via Dequeue():");
            taskQueue.QueueCleared -= auditMonitor.OnQueueClearedHandler;
            taskQueue.Enqueue("Single Task");
            Console.WriteLine($"Dequeued: {taskQueue.Dequeue()}");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}