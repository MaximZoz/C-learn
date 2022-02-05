using System;
using System.Text;

namespace ConsoleApp1
// ДЕЛЕГАТЫ
{
    public class Car
    {
        private int _speed = 0;

        public delegate void
            TooFast(int currentSpeed); // объявляем делегат который описывает метод, который будет вызываться 


        private TooFast _tooFast; // заносим делегат в приватную переменную класса 

        public void Start()
        {
            _speed = 10;
        }

        public void Accelerate()
        {
            _speed += 10;
            if (_speed > 80)
            {
                _tooFast(_speed); // вызываем делегат, когда это нужно
            }
        }

        public void Stop()
        {
            _speed = 0;
        }

        public void RegisterOnTooFast(TooFast tooFast) // метод обработчик делегата
        {
            this._tooFast = tooFast; // запоминаем делегат в филду
        }
    }

    internal static class Program
    {
        private static Car _car;

        public static void Main(string[] args)
        {
            _car = new Car();
            _car.RegisterOnTooFast(HandleOnTooFast);

            _car.Start();
            for (var i = 0; i < 10; i++)
            {
                _car.Accelerate();
            }
        }

        private static void HandleOnTooFast(int speed)
        {
            Console.WriteLine($"слишком быстро, ваша скорость = {speed} км/ч, я экстренно торможу");
            _car.Stop();
        }
    }
}