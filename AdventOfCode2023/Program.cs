// See https://aka.ms/new-console-template for more information

using AdventOfCode2023.Solver.day1;
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
                .AddScoped<IDayOneInputParser, DayOneInputParser>()
                .AddScoped<IConfigurationService>(_ =>
                new ConfigurationService(configFilePath, Assembly.GetExecutingAssembly())))
    .Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

var problemSolverList = new List<ISolver>()
{
    provider.GetRequiredService<DayOneSolver>(),
};

var problemsToRun = new bool[] { true };
for (int i = 0; i < problemSolverList.Count(); i++)
{
    var currentDay = i + 1;
    if (problemsToRun[i])
    {
        var solver = problemSolverList[i];
        var resultOne = await solver.SolvePartOneAsync();
        var resultTwo = await solver.SolvePartTwoAsync();
        Console.WriteLine($"Day{currentDay} P1:{resultOne}");
        Console.WriteLine($"Day{currentDay} P2:{resultTwo}");
    }
}