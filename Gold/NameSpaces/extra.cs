using System;

namespace NameSpaces.extraOne
{
    class ClassOne
    {
        public extraTwo.ClassTwo First { get; }

        public ClassOne(extraTwo.ClassTwo first)
        {
            this.First = first;
        }
    }
}
namespace NameSpaces.extraTwo
{
    class ClassTwo { }
}