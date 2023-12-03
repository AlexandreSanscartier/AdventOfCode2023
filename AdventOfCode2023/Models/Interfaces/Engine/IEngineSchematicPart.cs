using AdventOfCode2023.Models.Enum;

namespace AdventOfCode2023.Models.Interfaces.Engine
{
    public interface IEngineSchematicPart
    {
        IPosition Position { get; set; }

        EngineSchematicPartType EngineSchematicPartType { get; set; }

        object Value { get; set; }
    }
}
