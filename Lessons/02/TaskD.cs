﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Set capacity of ThreadPool to 10 and start 15 tasks. Let them run at least 1000 miliseconds. 
    /// Print out the time used for creation of each task.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            ThreadPool.SetMaxThreads(10, 10);
            //storage for tasks
            var tasks = new Task[15];

            var stopwatch = new Stopwatch();

            for (int i = 0; i < tasks.Length; i++)
            {
                stopwatch.Restart();
                var tmp = i;

                tasks[i] = Task.Run(() =>
                {
                    Thread.Sleep(1000);

                    Console.WriteLine("Task {0} created", tmp);
                });

                stopwatch.Stop();
                Console.WriteLine("Elapsed time for thread {0}: {1}, ticks: {2}", i, stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);
            }
        }
    }
}