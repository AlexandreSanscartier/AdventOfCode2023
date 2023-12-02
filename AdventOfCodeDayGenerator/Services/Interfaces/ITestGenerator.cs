using AdventOfCodeDayGenerator.Models.Interfaces;

namespace AdventOfCodeDayGenerator.Services.Interfaces
{
    public interface ITestGenerator
    {
        void GenerateTestForDay(ISolverCreationModel solverCreationModel);
    }
}
