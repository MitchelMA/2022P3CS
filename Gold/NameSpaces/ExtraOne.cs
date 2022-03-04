using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSpaces.ExtraOne
{
    class ClassOne
    {
        public ExtraTwo.ClassTwo First { get; }

        public ClassOne(ExtraTwo.ClassTwo first)
        {
            this.First = first;
        }
    }
}
