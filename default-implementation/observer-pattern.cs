using System;
using System.Collections.Generic;

namespace AnaliseDeSistemas
{
    interface IObserver
    {
        void DoSomething(string @event);
    }

    class SomeInterestingClass
    {
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void NotifyObservers(string @event)
        {
            observers.ForEach(o => o.DoSomething(@event));
        }

        public void ActionA()
        {
            NotifyObservers("action A");
        }

        public void ActionB()
        {
            NotifyObservers("action B");
        }

        public void Work()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Im interesting and Im gonna do something...");

                if (new Random().Next(2) == 0)
                    ActionA();
                else
                    ActionB();

                Console.WriteLine();
            }
        }
    }

    class SomeCuriousClass : IObserver
    {
        private string name;

        public SomeCuriousClass(string name)
        {
            this.name = name;
        }

        public void DoSomething(string @event)
        {
            Console.WriteLine($"observer {@name} handled event {@event}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var interesting = new SomeInterestingClass();

            interesting.AddObserver(new SomeCuriousClass("one"));
            interesting.AddObserver(new SomeCuriousClass("two"));
            interesting.AddObserver(new SomeCuriousClass("three"));

            interesting.Work();
        }
    }
}
