using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Exceptios;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Factories;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Processes;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ExecutorQuadraticEquation;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations.FactoriesReaderQuadraticEquations;
using System;
using System.IO;

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
            try
            {
                processSolvingQuadraticEquations.Run();
            }
            catch(DirectoryNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (InvalidDataFotParametersException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Неожиданное исключение:");
                Console.WriteLine(ex);
            }
            Console.WriteLine("Для заверщения нажмите Enter:");
            Console.ReadLine();
        }
    }
}
