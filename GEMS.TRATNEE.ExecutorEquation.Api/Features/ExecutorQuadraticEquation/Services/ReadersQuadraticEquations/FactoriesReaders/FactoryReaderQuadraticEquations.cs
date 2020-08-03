using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Enums;
using GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Views;
using System;
using System.IO;

namespace GEMS.TRATNEE.ExecutorEquation.Api.Features.ExecutorQuadraticEquation.Services.ReadersQuadraticEquations.FactoriesReaders
{
    internal class FactoryReaderQuadraticEquations : IFactoryReaderQuadraticEquations
    {
        private const string DefaultPathToFile = "Features/ExecutorQuadraticEquation/config/FileWithValidData.txt";
        private readonly ISelectionReaderEquations _selectionReaderEquations;

        public FactoryReaderQuadraticEquations(ISelectionReaderEquations selectionReaderEquations)
        {
            _selectionReaderEquations = selectionReaderEquations;
        }

        public IReaderQuadraticEquations CreateReaderQuadraticEquations() 
        {
            var selectionReader = _selectionReaderEquations.SelectMethodReadingEquations();
            if (selectionReader == TypesReadersEquations.CONSOLE)
            {
                return new ConsoleReaderQuadraticEquations();
            }
            
            Console.WriteLine($"Введите путь к файлу или нажмите Enter, чтобы использовать путь поумолчанию ({DefaultPathToFile}):");
            var path = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(path)) 
            {
                return new FileReaderQuadraticEquations(DefaultPathToFile);
            }

            if (Directory.Exists(path))
            {
                return new FileReaderQuadraticEquations(path);
            }

            throw new DirectoryNotFoundException($"Файл не найден по пути {path}");
        }
    }
}
