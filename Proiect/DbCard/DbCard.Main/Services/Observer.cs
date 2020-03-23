using System;
using System.Collections.Generic;
using Proiect.Models;

namespace Proiect.Services
{
    public interface IObserver
    {
        void Update(ISubject partner);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}