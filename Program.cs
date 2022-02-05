using System;
using System.Timers;

namespace ConsoleApp1
// События и обобщённые делегаты Action, Func
{
    public class CarArgs : EventArgs
    {
    }

    public class Car
    {
        private int _speed;

        public event EventHandler<CarArgs> TooFastDriving; // так можно объявить делегат с помощью event


        public void Start()
        {
            _speed = 10;
        }

        public void Accelerate()
        {
            _speed += 10;
            if (_speed > 80)
            {
                TooFastDriving?.Invoke(this, new CarArgs()); // вызываем делегат, когда это нужно     
            }
        }

        public void Stop()
        {
            _speed = 0;
        }
    }

    internal static class Program
    {
        private static Car _car;

        public static void Main(string[] args)
        {
            var timer = new Timer();
            timer.Elapsed += Timmer_Elapsed;
            timer.Interval = 5000;
            timer.Start();
            Console.ReadLine();


            _car = new Car();
            _car.TooFastDriving += HandleOnTooFast;


            _car.Start();
            for (var i = 0; i < 10; i++)
            {
                _car.Accelerate();
            }

            Console.WriteLine("снимаем ограничитель");
            _car.TooFastDriving -= HandleOnTooFast;
        }

        private static void Timmer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("handling timer elapsed event");
        }

        private static void HandleOnTooFast(object sender, CarArgs speed)
        {
            Console.WriteLine($"слишком быстро, ваша скорость = {speed} км/ч, я экстренно торможу");
            _car.Stop();
        }
    }
}