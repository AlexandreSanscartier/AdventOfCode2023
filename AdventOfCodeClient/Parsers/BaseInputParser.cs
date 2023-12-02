using AdventOfCodeClient.Interfaces.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeClient.Parsers
{
    public abstract class BaseInputParser<T> : IInputParser<T>
    {
        public abstract T Parse(string input);

        public virtual T ParseProblemOneInput(string input)
        {
            return this.Parse(input);
        }

        public virtual T ParseProblemTwoInput(string input)
        {
            return this.Parse(input);
        }
    }
}
