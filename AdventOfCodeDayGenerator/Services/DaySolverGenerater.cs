using AdventOfCodeDayGenerator.Models.Interfaces;
using AdventOfCodeDayGenerator.Services.Interfaces;
using System.Text;

namespace AdventOfCodeDayGenerator.Services
{
    public class DaySolverGenerater : IDaySolverGenerater
    {
        public void GenerateInputParser(ISolverCreationModel solverCreationModel)
        {
            this.GenerateInputParserInterface(solverCreationModel);
            this.GenerateInputParserClass(solverCreationModel);
        }

        public void GenerateSolver(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("using AdventOfCodeClient.interfaces;");
            stringBuilder.AppendLine("using AdventOfCodeClient.Solvers;");
            if (!string.IsNullOrEmpty(solverCreationModel.InputNamespace))
                stringBuilder.AppendLine($"using {solverCreationModel.InputNamespace};");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"namespace {solverCreationModel.BaseNamespace}.Solver.day{solverCreationModel.Day}");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"\tpublic class {solverCreationModel.SolverClassName} : BaseSolver<{solverCreationModel.InterfaceOrClassName}>");
            stringBuilder.AppendLine("\t{");
            stringBuilder.AppendLine($"\t\tpublic {solverCreationModel.SolverClassName}(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, {solverCreationModel.InputParserInterfaceName} inputParser):");
            stringBuilder.AppendLine("\t\t\tbase(problemInputReader, problemOutputSender, inputParser)");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.AppendLine("\t\t}");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine($"\t\tpublic override int Day => {solverCreationModel.Day};");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine($"\t\tpublic override string SolvePartOne({solverCreationModel.InterfaceOrClassName} input)");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.AppendLine("\t\t\t// Insert code here that solves part one of the problem");
            stringBuilder.AppendLine("\t\t\tthrow new MissingMethodException();");
            stringBuilder.AppendLine("\t\t}");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine($"\t\tpublic override string SolvePartTwo({solverCreationModel.InterfaceOrClassName} input)");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.AppendLine("\t\t\t// Insert code here that solves part two of the problem");
            stringBuilder.AppendLine("\t\t\tthrow new MissingMethodException();");
            stringBuilder.AppendLine("\t\t}");
            stringBuilder.AppendLine("\t}");
            stringBuilder.AppendLine("}");

            var solverFileDirectory = Path.Join(solverCreationModel.DayDirectory, $"{solverCreationModel.SolverClassName}.cs");
            File.WriteAllText(solverFileDirectory, stringBuilder.ToString());
        }

        private void GenerateInputParserClass(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(solverCreationModel.InputNamespace))
                stringBuilder.AppendLine($"using {solverCreationModel.InputNamespace};");
            stringBuilder.AppendLine("using AdventOfCodeClient.Parsers;");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"namespace {solverCreationModel.BaseNamespace}.Solver.day{solverCreationModel.Day}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"\tpublic class {solverCreationModel.InputParserClassName} : BaseInputParser<{solverCreationModel.InterfaceOrClassName}>, {solverCreationModel.InputParserInterfaceName}");
            stringBuilder.AppendLine("\t{");
            stringBuilder.AppendLine($"\t\tpublic override {solverCreationModel.InterfaceOrClassName} Parse(string input)");
            stringBuilder.AppendLine("\t\t{");
            stringBuilder.AppendLine("\t\t\t// Insert code here that parses the input");
            stringBuilder.AppendLine("\t\t\tthrow new MissingMethodException();");
            stringBuilder.AppendLine("\t\t}");
            stringBuilder.AppendLine("\t}");
            stringBuilder.AppendLine("}");

            var dayInputClassFilePath = Path.Join(solverCreationModel.DayDirectory, $"{solverCreationModel.InputParserClassName}.cs");
            File.WriteAllText(dayInputClassFilePath, stringBuilder.ToString());
        }

        private void GenerateInputParserInterface(ISolverCreationModel solverCreationModel)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("using AdventOfCodeClient.Interfaces.Parsers;");
            if (!string.IsNullOrEmpty(solverCreationModel.InputNamespace))
                stringBuilder.AppendLine($"using {solverCreationModel.InputNamespace};");
            stringBuilder.AppendLine();

            stringBuilder.AppendLine($"namespace {solverCreationModel.BaseNamespace}.Solver.day{solverCreationModel.Day}");

            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"\tpublic interface {solverCreationModel.InputParserInterfaceName} : IInputParser<{solverCreationModel.InterfaceOrClassName}>");
            stringBuilder.AppendLine("\t{");
            stringBuilder.AppendLine("\t}");
            stringBuilder.AppendLine("}");

            var dayInputInterfaceFilePath = Path.Join(solverCreationModel.DayDirectory, $"{solverCreationModel.InputParserInterfaceName}.cs");
            File.WriteAllText(dayInputInterfaceFilePath, stringBuilder.ToString());
        }

        private string GenerateTabs(int amount)
        {
            var returnString = string.Empty;
            for(int i = 0; i < amount; i++)
            {
                returnString += "\t";
            }
            return returnString;
        }
    }
}
