using System;
// gebruik mijn eigen namespace
using NameSpaces.ExtraOne;
using NameSpaces.ExtraTwo;

namespace NameSpaces
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassTwo two = new ClassTwo();
            ClassOne one = new ClassOne(two);
            Console.WriteLine(one.First);
        }
    }
}
