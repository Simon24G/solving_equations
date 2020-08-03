using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Helpers;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations.FactoriesReaders;
using System;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Processes
{
    internal class ProcessSolvingQuadraticEquations
    {
        private readonly IExecutorQuadraticEquation _executorQuadraticEquation;
        private readonly IFactoryReaderQuadraticEquations _factoryReaderQuadraticEquations;

        public ProcessSolvingQuadraticEquations(IExecutorQuadraticEquation executorQuadraticEquation, IFactoryReaderQuadraticEquations factoryReaderQuadraticEquations)
        {
            _executorQuadraticEquation = executorQuadraticEquation;
            _factoryReaderQuadraticEquations = factoryReaderQuadraticEquations;
        }

        public void Run() 
        {
            using var readerQuadraticEquation = _factoryReaderQuadraticEquations.CreateReaderQuadraticEquations();
            var equations = readerQuadraticEquation.Read();
            
            foreach (var equation in equations)
            {
                var solutions = _executorQuadraticEquation.Execute(equation.A, equation.B, equation.C);
                Console.WriteLine(equation.GetViewSolution(solutions));
            }
        }
    }
}
