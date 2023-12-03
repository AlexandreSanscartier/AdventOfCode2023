using AdventOfCode2023.Models.Enum;
using AdventOfCode2023.Models.Interfaces;
using AdventOfCode2023.Models.Interfaces.Engine;

namespace AdventOfCode2023.Models.Engine
{
    public class EngineSchematicPart : IEngineSchematicPart
    {
        private object _value;
        public IPosition Position { get; set; }
        public EngineSchematicPartType EngineSchematicPartType { get; set; }
        public object Value
        {
            get
            {
                return EngineSchematicPartType switch
                {
                    EngineSchematicPartType.Number => int.Parse($"{_value}"),
                    EngineSchematicPartType.Symbol or EngineSchematicPartType.NonSymbol or _ => _value
                };
            }
            set
            {
                _value = value;
            }
        }
        public override bool Equals(object? obj)
        {
            return obj is EngineSchematicPart part &&
                   part.Position.X == Position.X &&
                   part.Position.Y == Position.Y &&
                   EngineSchematicPartType == part.EngineSchematicPartType &&
                   Value.Equals(part.Value);
        }
    }
}
