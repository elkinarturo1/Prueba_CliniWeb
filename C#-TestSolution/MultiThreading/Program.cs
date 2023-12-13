using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    /*
     * The goal of this exercise is to complete a thread safe implementation of TaskHelper class.
     * 
     * Implement "RunTaskAsync" method that it will run a task async, but it will not allow to run a task with the same id at the same time.
     * If a task with the same Id is running, the task will be skipped. 
     * So for example, if you call RunTaskAsync twice with the same taskId, the second time the task will be skipped if at that moment the first one is still running.     
     * 
     * 
     * Implement a second method "RunTaskAsync2" that it will work simillar to the first one, with the difference that if a task with the same Id is running, it will
     * wait until that task completes before executing the new one.
     * So for example, if I call RunTaskAsync2 twice with the same taskId, the second time the task will wait for the first one to complete before running again.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();

            // This is just a simple way to test the implementation of these methods.
            for (int i = 0; i < 10; i++)
            {
                var taskId = rnd.Next(1, 3);

                TaskHelper.RunTaskAsync(1, () =>
                {
                    Console.WriteLine(string.Format("Run Task {0}", taskId));
                    Thread.Sleep(3000); // Simulación de una tarea
                    Console.WriteLine("Tarea {0} terminada.", taskId);
                });

                TaskHelper.RunTaskAsync2(1, () =>
                {
                    Console.WriteLine(string.Format("Run Task {0}", taskId));
                    Thread.Sleep(3000); // Simulación de una tarea
                    Console.WriteLine("Tarea {0} terminada.", taskId);
                });
            }

            Console.ReadKey();
        }
    }
}
