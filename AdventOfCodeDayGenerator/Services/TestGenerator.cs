using AdventOfCodeDayGenerator.ExtensionMethods;
using AdventOfCodeDayGenerator.Models.Interfaces;
using AdventOfCodeDayGenerator.Services.Interfaces;
using System.Text;

namespace AdventOfCodeDayGenerator.Services
{
    public class TestGenerator : ITestGenerator
    {
        public void GenerateTestForDay(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"using AdventOfCodeClient.interfaces;");
            stringBuilder.AppendLine($"using AdventOfCodeTest.Library.Helpers;");
            stringBuilder.AppendLine("using AdventOfCodeTest.Library.Interfaces;");
            stringBuilder.AppendLine($"using AdventOfCode2023.Solver.day{solverCreationModel.Day};");
            if (!string.IsNullOrEmpty(solverCreationModel.InputNamespace))
                stringBuilder.AppendLine($"using {solverCreationModel.InputNamespace};");

            stringBuilder.AppendLine();

            stringBuilder.AppendLine("namespace AdventOfCode2023.Tests"); // TODO: Paramaterize this
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"\tpublic class Day{solverCreationModel.Day.ToStringDay()}Tests : ISolverFactTests");
            stringBuilder.AppendLine("\t{");
            stringBuilder.AppendLine($"\t\tprivate readonly int _day = {solverCreationModel.Day.Value};");
            stringBuilder.AppendLine("\t\tprivate readonly string _sampleProblemInput = string.Empty;");
            stringBuilder.AppendLine("\t\tprivate readonly string? _sampleProblemOneInput = null;");
            stringBuilder.AppendLine("\t\tprivate readonly string? _sampleProblemTwoInput = null;");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t\tpublic int Day => _day;");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("\t\tpublic string SampleProblemOneInput => _sampleProblemOneInput ?? _sampleProblemInput;");
            stringBuilder.AppendLine("\t\tpublic string SampleProblemTwoInput => _sampleProblemTwoInput ?? _sampleProblemInput;");
            stringBuilder.AppendLine();

            stringBuilder.Append(GenerateAllTests(solverCreationModel));

            stringBuilder.AppendLine("\t}");
            stringBuilder.AppendLine("}");

            var file = Path.Combine(solverCreationModel.DayTestDirectory, $"Day{solverCreationModel.Day.ToStringDay()}Tests.cs");
            File.WriteAllText(file, stringBuilder.ToString());
        }

        private string GenerateAllTests(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(this.GenerateTestSampleInputParseProblemOneInputCorrectly(solverCreationModel));
            stringBuilder.AppendLine();
            stringBuilder.Append(this.GenerateTestSampleInputParseProblemTwoInputCorrectly(solverCreationModel));
            stringBuilder.AppendLine();
            stringBuilder.Append(this.GenerateTestSampleInputProducesCorrectResultForPartOne(solverCreationModel));
            stringBuilder.AppendLine();
            stringBuilder.Append(this.GenerateTestSampleInputProducesCorrectResultForPartTwo(solverCreationModel));
            stringBuilder.AppendLine();
            stringBuilder.Append(this.GenerateTestPartOneProducesCorrectResult(solverCreationModel));
            stringBuilder.AppendLine();
            stringBuilder.Append(this.GenerateTestPartTwoProducesCorrectResult(solverCreationModel));
            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }

        private string GenerateTestSampleInputParseProblemOneInputCorrectly(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("\t\t[Fact]");
            stringBuilder.AppendLine($"\t\tpublic void SampleInput_PartOne_ParsesCorrectly()");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.Append(GenerateTestSampleInputParseProlemXInputCorrectly(solverCreationModel, 1));
            stringBuilder.AppendLine("\t\t}");
            return stringBuilder.ToString();
        }

        private string GenerateTestSampleInputParseProblemTwoInputCorrectly(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("\t\t[Fact]");
            stringBuilder.AppendLine($"\t\tpublic void SampleInput_PartTwo_ParsesCorrectly()");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.Append(GenerateTestSampleInputParseProlemXInputCorrectly(solverCreationModel, 2));
            stringBuilder.AppendLine("\t\t}");
            return stringBuilder.ToString();
        }

        private string GenerateTestSampleInputParseProlemXInputCorrectly(ISolverCreationModel solverCreationModel, int problemPartNumber)
        {
            var stringBuilder = new StringBuilder();

            var problemPartNumberString = problemPartNumber == 2 ? "Two" : "One";

            var tabs = "\t\t\t";

            stringBuilder.AppendLine($"{tabs}//Arrange");
            stringBuilder.AppendLine($"{tabs}var inputParser = new Day{solverCreationModel.Day.ToStringDay()}InputParser();");
            stringBuilder.AppendLine($"{tabs}var expectedResult = new {solverCreationModel.InterfaceOrClassName}();");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{tabs}//Act");
            stringBuilder.AppendLine($"{tabs}var result = inputParser.ParseProblem{problemPartNumberString}Input(this.SampleProblem{problemPartNumberString}Input);");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{tabs}//Assert");
            stringBuilder.AppendLine($"{tabs}Assert.Equal(expectedResult, result);");

            return stringBuilder.ToString();
        } 

        private string GenerateTestSampleInputProducesCorrectResultForPartOne(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("\t\t[Fact]");
            stringBuilder.AppendLine($"\t\tpublic async Task SampleInput_ProducesCorrectResultForPartOne()");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.Append(this.GenerateTestSampleInputProducesCorrectResultForPartX(solverCreationModel, 1));
            stringBuilder.AppendLine("\t\t}");
            return stringBuilder.ToString();
        }

        private string GenerateTestSampleInputProducesCorrectResultForPartTwo(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("\t\t[Fact]");
            stringBuilder.AppendLine($"\t\tpublic async Task SampleInput_ProducesCorrectResultForPartTwo()");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.Append(this.GenerateTestSampleInputProducesCorrectResultForPartX(solverCreationModel, 2));
            stringBuilder.AppendLine("\t\t}");
            return stringBuilder.ToString();
        }

        private string GenerateTestPartOneProducesCorrectResult(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("\t\t[Fact]");
            stringBuilder.AppendLine($"\t\tpublic async Task PartOne_ProducesCorrectResult()");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.Append(this.GenerateTestPartXProducesCorrectResult(solverCreationModel, 1));
            stringBuilder.AppendLine("\t\t}");
            return stringBuilder.ToString();
        }

        private string GenerateTestPartTwoProducesCorrectResult(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("\t\t[Fact]");
            stringBuilder.AppendLine($"\t\tpublic async Task PartTwo_ProducesCorrectResult()");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.Append(this.GenerateTestPartXProducesCorrectResult(solverCreationModel, 2));
            stringBuilder.AppendLine("\t\t}");
            return stringBuilder.ToString();
        }

        private string GenerateTestPartXProducesCorrectResult(ISolverCreationModel solverCreationModel, int problemPartNumber)
        {
            var stringBuilder = new StringBuilder();

            var problemPartNumberString = problemPartNumber == 2 ? "Two" : "One";

            var tabs = "\t\t\t";

            stringBuilder.AppendLine($"{tabs}//Arrange");
            stringBuilder.AppendLine($"{tabs}var problemInput = InputFileReaderHelper.ReadFile(this.Day);");
            stringBuilder.AppendLine($"{tabs}var inputParser = new Day{solverCreationModel.Day.ToStringDay()}InputParser();");
            stringBuilder.AppendLine($"{tabs}var problemOutputReaderMock = A.Fake<IProblemOutputSender>();");
            stringBuilder.AppendLine($"{tabs}var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, problemInput);");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{tabs}var solver = new Day{solverCreationModel.Day.ToStringDay()}Solver(problemInputReader, problemOutputReaderMock, inputParser);");
            stringBuilder.AppendLine($"{tabs}var expectedResult = \"\";");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{tabs}//Act");
            stringBuilder.AppendLine($"{tabs}var result = await solver.SolvePart{problemPartNumberString}Async();");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{tabs}//Assert");
            stringBuilder.AppendLine($"{tabs}Assert.Equal(expectedResult, result);");

            return stringBuilder.ToString();
        }

        private string GenerateTestSampleInputProducesCorrectResultForPartX(ISolverCreationModel solverCreationModel, int problemPartNumber)
        {
            var stringBuilder = new StringBuilder();

            var problemPartNumberString = problemPartNumber == 2 ? "Two" : "One";

            var tabs = "\t\t\t";

            stringBuilder.AppendLine($"{tabs}//Arrange");
            stringBuilder.AppendLine($"{tabs}var inputParser = new Day{solverCreationModel.Day.ToStringDay()}InputParser();");
            stringBuilder.AppendLine($"{tabs}var problemOutputReaderMock = A.Fake<IProblemOutputSender>();");
            stringBuilder.AppendLine($"{tabs}var problemInputReader = InputReaderMockerHelper.CreateMock(this.Day, this.SampleProblem{problemPartNumberString}Input);");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{tabs}var solver = new Day{solverCreationModel.Day.ToStringDay()}Solver(problemInputReader, problemOutputReaderMock, inputParser);");
            stringBuilder.AppendLine($"{tabs}var expectedResult = \"\";");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{tabs}//Act");
            stringBuilder.AppendLine($"{tabs}var result = await solver.SolvePart{problemPartNumberString}Async();");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"{tabs}//Assert");
            stringBuilder.AppendLine($"{tabs}Assert.Equal(expectedResult, result);");

            return stringBuilder.ToString();
        }
    }
}
