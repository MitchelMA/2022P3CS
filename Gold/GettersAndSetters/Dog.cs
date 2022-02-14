using System;

namespace GettersAndSetters
{
    class Dog
    {
        private Ball currentBall;
        public void FetchBall(Ball ball)
        {
            currentBall = ball;
        }
        public Ball GiveBall()
        {
            if (currentBall == null)
                Console.WriteLine("Er is geen bal");

            Ball tmp = currentBall;
            currentBall = null;
            return tmp;
        }
    }
}