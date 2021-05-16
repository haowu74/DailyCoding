using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace Day010
{
    class Program
    {
        List<Tuple<Task, DateTime>> schedule = new List<Tuple<Task, DateTime>>();
        static void Main(string[] args)
        {
            Program program = new Program();
            Task t1 = new Task(() => {System.Console.WriteLine("t1");});
            Task t2 = new Task(() => {System.Console.WriteLine("t2");});
            Task t3 = new Task(() => {System.Console.WriteLine("t3");});
            program.AddTask(t1, DateTime.Now.AddMinutes(1));
            program.AddTask(t2, DateTime.Now.AddSeconds(30));
            program.AddTask(t3, DateTime.Now.AddSeconds(15));
            var taskWait = Task.Run(() => program.Scheduler());
            System.Console.WriteLine("The END");
            taskWait.Wait();
        }

        void AddTask(Task task, DateTime due)
        {
            var t = new Tuple<Task, DateTime>(task, due);
            this.schedule.Add(t);
        }

        void Scheduler()
        {
            while (this.schedule.Count > 0)
            {
                foreach(var t in this.schedule)
                {
                    if(t.Item2 < DateTime.Now)
                    {
                        if(t.Item1.Status == TaskStatus.Created)
                        {
                            t.Item1.Start();
                        }
                    }
                }
                this.schedule.RemoveAll(s => s.Item1.Status == TaskStatus.RanToCompletion);
                Thread.Sleep(100);
            }
        }
    }
}
