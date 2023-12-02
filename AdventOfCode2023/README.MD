# Advent Calendar 2022

[Participate in Advent of code](https://adventofcode.com)

This contains my solutions for [Advent of code 2023](https://adventofcode.com/2023). Solutions are overengineered on purpose as my goal is not to chase stars, but rather to architect the code is such a way that it could theoretically be reused to solve similar problems. The code is not perfect but it's mine ;)!

## Features

I learnt my lesson fromt last year having to write a bunch of boilerplate code which removed a lot of the fun and added a lot of friction to actually solving the problems.
- The ability to automatically grab the day's input
- Unit tests for every problem including the sample data given to everyone
- I've created a generator class to create all the boiler plate code I need for solving problems in my own framework.
- This includes creating the InputParser interface and class and the Solver for the day.
- Thie includes creating the tests that I use to test the sample input and then add the results of the day to.

### New From 2023
- Replaced the Moq testing framework with [FakeItEasy](https://fakeiteasy.github.io/)

## How to Use

If you want to go ahead and use this as a starting framework to solve your own advent of code 2023 there are a few steps to follow:

1. Add your session key to the ==adventofcode.json== [how do I find my session cookie?](#How-do-I-find-my-session-cookie?)
2. Configure the ==SolverGeneratorConfig.json== with the correct information for the day.

### How do I use the solution generator?
There are three important variables in ==SolverGeneratorConfig.json== file.
1. **Day** The day you want to generate the boilerplate code fore
2. **InputParserModelNamespace** The namespace in the project that contains your desired input formate.
3. **InputParserClassName** The name of the class that you want to format your input in

**Example**
Say in my main project I have the following class:
```
namespace AdventOfCode2023.Models
{
    public class Input
    {
        Guid Key { get; set; }
    }
}
```

To generate the boilerplate for this input (say on day 10) I would have
```
{
  "Day": 10,
  "InputParserModelNamespace": "AdventOfCode2023.Models",
  "InputParserClassName": "Input"
}
```

The output would be the following

**Day10/IDayTenInputParser.cs**
```
using AdventOfCodeClient.Interfaces.Parsers;
using AdventOfCode2023.Models;

namespace AdventOfCode2023.Solver.day10
{
	public interface IDayTenInputParser : IInputParser<Input>
	{
	}
}
```

**Day10/DayTenInputParser.cs**
```
using AdventOfCode2023.Models;
using AdventOfCodeClient.Parsers;

namespace AdventOfCode2023.Solver.day10

{
	public class DayTenInputParser : BaseInputParser<Input>, IDayTenInputParser
	{
		public override Input Parse(string input)
		{
			// Insert code here that parses the input
			throw new MissingMethodException();
		}
	}
}
```

**Day10/DayTenSolver.cs**
```
using AdventOfCodeClient.interfaces;
using AdventOfCodeClient.Solvers;
using AdventOfCode2023.Models;

namespace AdventOfCode2023.Solver.day10
{
	public class DayTenSolver : BaseSolver<Input>
	{
		public DayTenSolver(IProblemInputReader problemInputReader, IProblemOutputSender problemOutputSender, IDayTenInputParser inputParser):
			base(problemInputReader, problemOutputSender, inputParser)
		{
		}

		public override int Day => 10;

		public override string SolvePartOne(Input input)
		{
			// Insert code here that solves part one of the problem
			throw new MissingMethodException();
		}

		public override string SolvePartTwo(Input input)
		{
			// Insert code here that solves part two of the problem
			throw new MissingMethodException();
		}
	}
}
```

### How do I find my session cookie?
Google Chrome:
- Go to adventofcode.com
- Make sure you are logged in
- Right click and select "Inspect"
- Select the "Application" tab
- In the tree on the left, select "Storage" → "Cookies" → "https://adventofcode.com"
- You should see a table of cookies, find the row with "session" as name
- Double click the row in the "Value" column to select the value of the cookie
- Press CTRL + C or right click and select "Copy" to copy the cookie
- Paste it into your configuration file or on the command line

Feel free to open any issues if you find any though since this is a personal project I can't make any promises to when I will get to them.

Thanks for visiting!
