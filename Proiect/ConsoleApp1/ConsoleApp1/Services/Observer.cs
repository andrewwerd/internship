using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect.Services
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class Subject : ISubject
    {
        // Для удобства в этой переменной хранится состояние Издателя,
        // необходимое всем подписчикам.
        public int State { get; set; } = -0;

        // Список подписчиков. В реальной жизни список подписчиков может
        // храниться в более подробном виде (классифицируется по типу события и
        // т.д.)
        private List<IObserver> _observers = new List<IObserver>();

        // Методы управления подпиской.
        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);        
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        // Обычно логика подписки – только часть того, что делает Издатель.
        // Издатели часто содержат некоторую важную бизнес-логику, которая
        // запускает метод уведомления всякий раз, когда должно произойти что-то
        // важное (или после этого).
        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important.");
            this.State = new Random().Next(0, 10);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }

    // Конкретные Наблюдатели реагируют на обновления, выпущенные Издателем, к
    // которому они прикреплены.
    class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }

    class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }
}
