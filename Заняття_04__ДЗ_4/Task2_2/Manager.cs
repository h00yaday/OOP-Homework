using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_2
{
    internal class Manager : Worker
    {
        private const int MinFirstCalls = 1;
        private const int MaxFirstCalls = 11;
        private const int MinSecondCalls= 1;
        private const int MaxSecondCalls = 6;

        private readonly Random _random;

        public Manager(string name) : base(name)
        {
            Position = "Менеджер";
            _random = new Random();
        }
        public override void FillWorkDay()
        {
          int firstCallsCount = _random.Next(MinFirstCalls, MaxFirstCalls);
            for (int i = 0; i < firstCallsCount; i++)
            {
                Call();
            }
            Relax();
            int secondCallsCount = _random.Next(MinSecondCalls, MaxSecondCalls);
            for (int i = 0; i < secondCallsCount; i++)
            {
                Call();
            }
        }
    }
}      
