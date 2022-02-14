using System;

namespace OverErving.Animals
{
    abstract class Animal
    {
        protected bool isFed = false;

        public void Feed()
        {
            isFed = true;
        }
    }

    class Horse : Animal
    {
        public bool Status()
        {
            return isFed;
        }
    }
}