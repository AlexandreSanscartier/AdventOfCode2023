namespace AdventOfCodeTest.Library.Interfaces
{
    public interface ISolverFactTests
    {
        string SampleProblemOneInput { get; }
        string SampleProblemTwoInput { get; }

        void SampleInput_PartOne_ParsesCorrectly();

        void SampleInput_PartTwo_ParsesCorrectly();

        Task SampleInput_ProducesCorrectResultForPartOne();

        Task SampleInput_ProducesCorrectResultForPartTwo();
    }
}
