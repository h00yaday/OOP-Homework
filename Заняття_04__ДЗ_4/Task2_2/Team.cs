using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2
{
    internal class Team
    {
        private readonly List<Worker> _workers;
        public string Name { get; private set; }
        public Team(string name)
        {
            Name = name;
            _workers = new List<Worker>();
        }
        public void AddWorker(Worker worker)
        {
            _workers.Add(worker);
        }
        public void ShowTeamInfo()
        {
            Console.WriteLine($"Команда: {Name}");
            foreach (Worker worker in _workers)
            {
                Console.WriteLine(worker.Name);
            }
        }
        public void ShowDetailedTeamInfo()
        {
            Console.WriteLine($"Команда: {Name}");
            foreach (Worker worker in _workers)
            {
                Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay}");
            }
        }
    }
}