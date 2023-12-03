﻿using AdventOfCode2023.Models.Interfaces;

namespace AdventOfCode2023.Models
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position()
        {
            
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IPosition Add(IPosition position)
        {
            return new Position()
            {
                X = this.X + position.X,
                Y = this.Y + position.Y
            };
        }
    }
}
