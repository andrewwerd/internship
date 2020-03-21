using System;

namespace ISP
{
    // Не соотвествует ISP
    interface ICarInterface { 
        public void Engine_start();
        public void Accelerate();
        public void Engine_stop();
        public void On_conditioner();
        public void Off_conditioner();
    }
    public class Engine: ICarInterface
    {
        public void Engine_start() {
            Console.WriteLine("Wrum-wrum");
        }
        public void Accelerate()
        {
            Console.WriteLine("Wjjjjjjjjj");
        }
        public void Engine_stop()
        {
            Console.WriteLine("squeak");
        }
        public void On_conditioner()
        {
            throw new NotImplementedException();
        }
        public void Off_conditioner()
        {
            throw new NotImplementedException();
        }

    }
    public class Conditioner : ICarInterface
    {
        public void Engine_start()
        {
            throw new NotImplementedException();
        }
        public void Accelerate()
        {
            throw new NotImplementedException();
        }
        public void Engine_stop()
        {
            throw new NotImplementedException();
        }
        public void On_conditioner()
        {
            Console.WriteLine("Juuuuuuuu");
        }
        public void Off_conditioner()
        {
            Console.WriteLine("Pishk");
        }

    }
    // Соответсвует ISP
    interface IEngineInterface{
        public void Engine_start();
        public void Accelerate();
        public void Engine_stop();
    }
    interface IConditionerInterface{
        public void On_conditioner();
        public void Off_conditioner();
    }
    public class newEngine : IEngineInterface
    {
        public void Engine_start()
        {
            Console.WriteLine("Wrum-wrum");
        }
        public void Accelerate()
        {
            Console.WriteLine("Wjjjjjjjjj");
        }
        public void Engine_stop()
        {
            Console.WriteLine("squeak");
        }

    }
    public class newConditioner : IConditionerInterface
    {
        public void On_conditioner()
        {
            Console.WriteLine("Juuuuuuuu");
        }
        public void Off_conditioner()
        {
            Console.WriteLine("Pishk");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            newEngine engine = new newEngine();
            engine.Engine_start();
            engine.Accelerate();
            engine.Engine_stop();
        }
    }
}
