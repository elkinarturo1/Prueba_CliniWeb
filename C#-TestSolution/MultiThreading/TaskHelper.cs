using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    // TODO: complete this class implementation
    public class TaskHelper
    {

        private static ConcurrentDictionary<int, bool> runningTasks = new ConcurrentDictionary<int, bool>();

        private static ConcurrentDictionary<int, Task> runningTasks2 = new ConcurrentDictionary<int, Task>();
        private static ConcurrentDictionary<int, Action> taskQueues = new ConcurrentDictionary<int, Action>();
                
        private static bool isTaskRunning = false;
        

        public static void RunTaskAsync(int taskId, Action task)
        {            

            if (runningTasks.ContainsKey(taskId))
            {
                Console.WriteLine($"La tarea con ID {taskId} ya está en ejecución.");
                return;
            }
            else
            {
               
                Task.Factory.StartNew(() =>
                {
                    isTaskRunning = true;
                    try
                    {
                        Console.WriteLine($"Iniciando la tarea con ID {taskId}...");
                        task();
                    }
                    finally
                    {
                        isTaskRunning = false;
                        Console.WriteLine($"La tarea con ID {taskId} ha finalizado.");
                    }
                });

            }
          
        }

        public static void RunTaskAsync2(int taskId, Action task)
        {
            if (runningTasks.ContainsKey(taskId))
            {
                taskQueues[taskId] = task;
                Console.WriteLine($"La tarea con ID {taskId} ya está en ejecución. Encolando...");
                return;
            }

            Task.Factory.StartNew(() =>
            {
                if (taskQueues.ContainsKey(taskId))
                {
                    Console.WriteLine($"Iniciando la tarea en cola con ID {taskId}...");
                    Action queuedTask = taskQueues[taskId];
                    taskQueues.TryRemove(taskId, out _); // Remover de la cola

                    try
                    {
                        queuedTask();
                    }
                    finally
                    {
                        Console.WriteLine($"La tarea en cola con ID {taskId} ha finalizado.");
                    }
                }
                else
                {
                    isTaskRunning = true;

                    try
                    {
                        Console.WriteLine($"Iniciando la tarea con ID {taskId}...");
                        task();
                    }
                    finally
                    {
                        isTaskRunning = false;
                        Console.WriteLine($"La tarea con ID {taskId} ha finalizado.");
                    }
                }
            });
        }

    }
}
