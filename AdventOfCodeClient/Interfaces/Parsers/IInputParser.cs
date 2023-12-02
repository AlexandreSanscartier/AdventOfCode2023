namespace AdventOfCodeClient.Interfaces.Parsers
{
    public interface IInputParser<out T>
    {
        T Parse(string input);

        T ParseProblemOneInput(string input);

        T ParseProblemTwoInput(string input);
    }
}
