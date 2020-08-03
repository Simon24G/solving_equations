using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Factories;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Processes;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ExecutorQuadraticEquation;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations.FactoriesReaders;
using System;

namespace GEMS.TRATNEE.ExecutorEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            var selectionReaderEquations = new SelectionReaderEquations();
            var factory = new FactoryReaderQuadraticEquations(selectionReaderEquations);
            var executor = new ExecutorQuadraticEquation();
            
            var processSolvingQuadraticEquations = new ProcessSolvingQuadraticEquations(executor, factory);
            processSolvingQuadraticEquations.Run();

            Console.WriteLine("Для заверщения нажмите Enter:");
            Console.ReadLine();
        }
    }
}
