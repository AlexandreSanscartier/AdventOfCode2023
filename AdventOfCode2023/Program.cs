// See https://aka.ms/new-console-template for more information

using AdventOfCode2023.Solver.day1;
using AdventOfCode2023.Solver.day10;
using AdventOfCode2023.Solver.day2;
using AdventOfCode2023.Solver.day3;
using AdventOfCode2023.Solver.day4;
using AdventOfCode2023.Solver.day5;
using AdventOfCode2023.Solver.day6;
using AdventOfCode2023.Solver.day7;
using AdventOfCode2023.Solver.day8;
using AdventOfCode2023.Solver.day9;
using AdventOfCodeClient;
using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.interfaces.services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var configFilePath = Path.Combine(Environment.CurrentDirectory, "config", "adventofcode.json");
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddScoped<IProblemInputReader, ProblemInputReader>()
                .AddScoped<IProblemOutputSender, ProblemOutputSender>()
                .AddScoped<IProblemInputCache, ProblemInputCache>()
                .AddScoped<DayOneSolver>()
                .AddScoped<DayTwoSolver>()
                .AddScoped<DayThreeSolver>()
                .AddScoped<DayFourSolver>()
                .AddScoped<DayFiveSolver>()
                .AddScoped<DaySixSolver>()
                .AddScoped<DaySevenSolver>()
                .AddScoped<DayEightSolver>()
                .AddScoped<DayNineSolver>()
                .AddScoped<DayTenSolver>()
                .AddScoped<IDayOneInputParser, DayOneInputParser>()
                .AddScoped<IDayTwoInputParser, DayTwoInputParser>()
                .AddScoped<IDayThreeInputParser, DayThreeInputParser>()
                .AddScoped<IDayFourInputParser, DayFourInputParser>()
                .AddScoped<IDayFiveInputParser, DayFiveInputParser>()
                .AddScoped<IDaySixInputParser, DaySixInputParser>()
                .AddScoped<IDaySevenInputParser, DaySevenInputParser>()
                .AddScoped<IDayEightInputParser, DayEightInputParser>()
                .AddScoped<IDayNineInputParser, DayNineInputParser>()
                .AddScoped<IDayTenInputParser, DayTenInputParser>()
                .AddScoped<IConfigurationService>(_ =>
                new ConfigurationService(configFilePath, Assembly.GetExecutingAssembly())))
    .Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

var problemSolverList = new List<ISolver>()
{
    provider.GetRequiredService<DayOneSolver>(),
    provider.GetRequiredService<DayTwoSolver>(),
    provider.GetRequiredService<DayThreeSolver>(),
    provider.GetRequiredService<DayFourSolver>(),
    provider.GetRequiredService<DayFiveSolver>(),
    provider.GetRequiredService<DaySixSolver>(),
    provider.GetRequiredService<DaySevenSolver>(),
    provider.GetRequiredService<DayEightSolver>(),
    provider.GetRequiredService<DayNineSolver>(),
    provider.GetRequiredService<DayTenSolver>(),
};

var problemsToRun = new bool[] { false, false, false, false, false, false, false, false, false, true };
for (int i = 0; i < problemSolverList.Count(); i++)
{
    var currentDay = i + 1;
    if (problemsToRun[i])
    {
        var solver = problemSolverList[i];
        var resultOne = await solver.SolvePartOneAsync();
        //var resultTwo = await solver.SolvePartTwoAsync();
        Console.WriteLine($"Day{currentDay} P1:{resultOne}");
        //Console.WriteLine($"Day{currentDay} P2:{resultTwo}");
    }
}