namespace AdventOfCode2023.Models.Interfaces.Engine
{
    public interface IEngineSchematic
    {
        int Rows { get; set; }

        int Columns { get; set; }  

        List<IEngineSchematicPart> Parts { get; set; }

        IEngineSchematicPart? GetPartAtPosition(IPosition position);
    }
}
