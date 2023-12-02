using AdventOfCode2023.Exceptions;
using AdventOfCode2023.Models.Interfaces;
using ValueOf;

namespace AdventOfCode2023.Models
{
    public class Cube : ValueOf<string, Cube>, ICube
    {
        private const string _blue = "blue";
        private const string _red = "red";
        private const string _green = "green";
        private readonly string[] _possibleColors = { _blue, _red, _green };

        public override bool Equals(object? obj)
        {
            return obj is Cube cube &&
                   base.Equals(obj) &&
                   Value == cube.Value;
        }

        protected override bool Equals(ValueOf<string, Cube> other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override void Validate()
        {
            if(!_possibleColors.Contains(this.Value.ToLower()))
            {
                throw new InvalidCubeColorException($"Value {this.Value} is invalid must be {string.Join(',', _possibleColors)}");
            }
        }
    }
}
