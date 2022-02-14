using System;

namespace GettersAndSetters
{
    class Program
    {
        static void Main(string[] args)
        {
            Ball myBall = new Ball();
            Dog myDog = new Dog();
            myDog.FetchBall(myBall);
            Console.WriteLine(myDog.GiveBall());
            Console.WriteLine(myDog.GiveBall());
        }
    }
}
