// See https://aka.ms/new-console-template for more information
using AdventOfCodeDayGenerator.Models;
using AdventOfCodeDayGenerator.Services;
using System.Text.Json;
using System.Text.RegularExpressions;

var currentDirectory = Environment.CurrentDirectory;
var splitPath = currentDirectory.Split(Path.DirectorySeparatorChar);
var adventOfCodeYearRegex = @"AdventOfCode2[0-9]{3}";
int indexOfAdventOfCodeYear = -1;
var solverCreationModel = new SolverCreationModel();
var solverGeneratorConfigJsonFile = Path.Combine(currentDirectory, "Config", "SolverGeneratorConfig.json");
var solverGeneratorConfigJsonString = File.ReadAllText(solverGeneratorConfigJsonFile);
var solverGeneratorConfig = JsonSerializer.Deserialize<SolverGeneratorConfigurationModel>(solverGeneratorConfigJsonString);

for (var i = 0; i < splitPath.Length; i++)
{
    var directory = splitPath[i];
    if (Regex.IsMatch(directory, adventOfCodeYearRegex))
    {
        indexOfAdventOfCodeYear = i;
    }
}

var baseDirectory = string.Join(Path.DirectorySeparatorChar, splitPath.Take(indexOfAdventOfCodeYear + 1));
var testDirectory = Path.Combine(baseDirectory, "AdventOfCode2023.Tests");
var solverDirectory = Path.Combine(baseDirectory, splitPath[indexOfAdventOfCodeYear], "Solver");

solverCreationModel.Day = Day.From(solverGeneratorConfig.Day);
solverCreationModel.InputNamespace = solverGeneratorConfig.InputParserModelNamespace;
solverCreationModel.InterfaceOrClassName = solverGeneratorConfig.InputParserClassName;


if (!Directory.Exists(solverDirectory))
{
    Directory.CreateDirectory(solverDirectory);
}

var dayTestDirectory = Path.Combine(testDirectory, $"Day{solverCreationModel.Day}");
var dayDirectory = Path.Combine(solverDirectory, $"Day{solverCreationModel.Day}");
solverCreationModel.DayTestDirectory = dayTestDirectory;

if(Directory.Exists(dayDirectory))
{
    Console.WriteLine("Directory already exists, delete it manually and rerun");
    Environment.Exit(0);
}

if (!Directory.Exists(dayTestDirectory))
{
    Directory.CreateDirectory(dayTestDirectory);
}

Directory.CreateDirectory(dayDirectory);
solverCreationModel.DayDirectory = dayDirectory;
solverCreationModel.BaseNamespace = splitPath[indexOfAdventOfCodeYear];

var daySolverGenerater = new DaySolverGenerater();
daySolverGenerater.GenerateInputParser(solverCreationModel);
daySolverGenerater.GenerateSolver(solverCreationModel);

var testGenerater = new TestGenerator();
testGenerater.GenerateTestForDay(solverCreationModel);