using AdventOfCodeDayGenerator.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDayGenerator.Services.Interfaces
{
    public interface IDaySolverGenerater
    {
        void GenerateInputParser(ISolverCreationModel solverCreationModel);

        void GenerateSolver(ISolverCreationModel solverCreationModel);
    }
}
