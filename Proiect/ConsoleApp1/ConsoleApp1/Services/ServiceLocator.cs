using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect.Services
{
    public static class ServiceLocator
    {
        private readonly static Dictionary<Type, object> services = new Dictionary<Type, object>();
        public static T GetService<T>()
        {
            return (T)services[typeof(T)]();
        }
        public static void Register<TImpl, TAbstraction>() where TImpl : TAbstraction
        {
            services[typeof(TAbstraction)] = () => Activator.CreateInstance<TImpl>();
        }
        public static void Reset()
        {
            services.Clear();
        }
    }
}
